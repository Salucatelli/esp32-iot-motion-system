using backend.Services;
using gateway.Hubs;
using RabbitMQ.Client;

var builder = WebApplication.CreateBuilder(args);

var rabbitHost = builder.Configuration["RABBITMQ_HOST"] ?? "localhost";
var rabbitUser = builder.Configuration["RABBITMQ_USER"] ?? "user";
var rabbitPass = builder.Configuration["RABBITMQ_PASS"] ?? "pass";
var corsOrigin = builder.Configuration["CORS_ORIGIN"] ?? "http://127.0.0.1:5500";

// Adds signalR
builder.Services.AddSignalR();

// RabbitMQ
builder.Services.AddSingleton<IConnectionFactory>(sp =>
    new ConnectionFactory() { 
        HostName = rabbitHost,
        UserName = rabbitUser,
        Password = rabbitPass
    });
builder.Services.AddHostedService<RabbitMqListener>();

// Adiciona CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        policy =>
        {
            policy.WithOrigins(corsOrigin)
                  .AllowAnyHeader()
                  .AllowAnyMethod()
                  .AllowCredentials(); // necessário para SignalR
        });
});

var app = builder.Build();

// Usa CORS antes do MapHub
app.UseCors("AllowFrontend");

app.MapHub<EspHub>("/espHub");

app.Run();
