using AutoMapper;
using GreenPipes;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Service2.Api;
using Service2.Api.Infrastructure.Mapping;
using Service2.Api.Infrastructure.Services;
using Service2.Api.Infrastructure.Services.Interfaces;
using Service2.Api.IntegrationEvents.MassTransitHandling;
using Service2.Api.StartupTasks;
using Service2.Application.Commands.Users;
using Service2.Domain;
using Service2.Infrastructure.Database;
using Service2.Infrastructure.Repositories;
using System.Reflection;

// https://github.com/serilog/serilog-aspnetcore
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

try
{
    Log.Information("Starting web application");
    var builder = WebApplication.CreateBuilder(args);
    builder.Services.AddSerilog();

    // Add services to the container.

    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen(option =>
    {
        var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFilename);
        option.IncludeXmlComments(xmlPath);
    });

    AppOptions.Configure(builder.Configuration);
    builder.Services.AddMassTransit(x =>
    {
        x.AddConsumer<UserCreatedConsumer>();
        x.AddBus(provider => Bus.Factory.CreateUsingRabbitMq(cfg =>
        {
            cfg.Host(new Uri(AppOptions.RabbitMqRootUri), h =>
            {
                h.Username(AppOptions.RabbitMqUser);
                h.Password(AppOptions.RabbitMqPassword);
            });
            cfg.ReceiveEndpoint(AppOptions.RabbitMqQueueUri, ep =>
            {
                ep.PrefetchCount = 16;
                ep.UseMessageRetry(r => r.Interval(2, 100));
                ep.ConfigureConsumer<UserCreatedConsumer>(provider);
            });
        }));
    });
    builder.Services.AddMassTransitHostedService();

    // Медиатор ищет обработчики в этих сборках.
    var assemblies = new Assembly[]
    {
        typeof(Program).GetTypeInfo().Assembly,
        typeof(UserCreateOrUpdateCommand).GetTypeInfo().Assembly,
    };
    builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(assemblies));

    builder.Services.AddDbContextFactory<Service2Context>(opt => opt.UseNpgsql(AppOptions.DefaultConnection));
    // Инициализация БД.
    builder.Services.AddHostedService<DatabaseInitialization>();

    // Services.
    builder.Services.AddScoped<IOrganizationService, OrganizationService>();
    builder.Services.AddScoped<IUserService, UserService>();

    // Repositories.
    builder.Services.AddScoped<IUserRepository, UserRepository>();
    builder.Services.AddScoped<IOrganizationRepository, OrganizationRepository>();

    var config = new MapperConfiguration(cfg =>
    {
        cfg.AddProfile<DomainToModelProfile>();
    });
    builder.Services.AddSingleton<IMapper>(new Mapper(config));


    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    //app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Application terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}