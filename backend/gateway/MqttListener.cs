namespace backend.Services;

using gateway.Hubs;
using Microsoft.AspNetCore.SignalR;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

public class RabbitMqListener : BackgroundService
{
    private readonly IConnectionFactory _factory;
    private readonly IHubContext<EspHub> _hubContext;

    public RabbitMqListener(IConnectionFactory factory, IHubContext<EspHub> hubContext)
    {
        _factory = factory;
        _hubContext = hubContext;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var queueName = "motion_sensor";

        using var connection = await _factory.CreateConnectionAsync();
        using var channel = await connection.CreateChannelAsync();

        //If the connection is open, print a message to the console
        if (connection.IsOpen)
            Console.WriteLine("Conexão com RabbitMQ estabelecida!");

        // create the queue and bind it to the same MQTT from the Raspberry Pi Pico W
        await channel.QueueDeclareAsync(queueName, durable: false, exclusive: false, autoDelete: false);
        await channel.QueueBindAsync(queueName, exchange: "amq.topic", routingKey: "esp");

        var consumer = new AsyncEventingBasicConsumer(channel);
        consumer.ReceivedAsync += async (model, ea) =>
        {
            var message = Encoding.UTF8.GetString(ea.Body.ToArray());
            Console.WriteLine($"Mensagem recebida: {message}");

            // envia para todos os clientes Angular/React conectados
            await _hubContext.Clients.All.SendAsync("ReceiveMessage", message);
        };

        await channel.BasicConsumeAsync(queueName, autoAck: true, consumer: consumer);

        await Task.Delay(Timeout.Infinite, stoppingToken); // mantém rodando
    }
}