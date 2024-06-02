using GreenPipes;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Service2.Api;
using Service2.Api.Consumers;
using Service2.Api.StartupTasks;
using Service2.Infrastructure.Postgres;
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
            cfg.ReceiveEndpoint(AppOptions.RabbitMqQueueUri /*"usersQueue"*/, ep =>
            {
                ep.PrefetchCount = 16;
                ep.UseMessageRetry(r => r.Interval(2, 100));
                ep.ConfigureConsumer<UserCreatedConsumer>(provider);
            });
        }));
    });
    builder.Services.AddMassTransitHostedService();

    builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

    builder.Services.AddDbContextFactory<Service2Context>(opt => opt.UseNpgsql(AppOptions.DefaultConnection));
    // Инициализация БД.
    builder.Services.AddHostedService<DatabaseInitialization>();

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