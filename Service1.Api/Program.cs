using FluentValidation.AspNetCore;
using MassTransit;
using Serilog;
using Service1.Api;
using Service1.Api.Application;
using Service1.Api.Application.Services;
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

    builder.Services.AddControllers()
        .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<Program>());

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
        x.AddBus(provider => Bus.Factory.CreateUsingRabbitMq(config =>
        {
            config.Host(new Uri(AppOptions.RabbitMqRootUri), h =>
            {
                h.Username(AppOptions.RabbitMqUser);
                h.Password(AppOptions.RabbitMqPassword);
            });
        }));
    });
    builder.Services.AddMassTransitHostedService();

    builder.Services.AddScoped<IUserService>(x =>
        new UserService(x.GetRequiredService<IBus>(),
        x.GetRequiredService<ILogger<UserService>>(),
        $"{AppOptions.RabbitMqRootUri}/{AppOptions.RabbitMqQueueUri}"
        ));


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