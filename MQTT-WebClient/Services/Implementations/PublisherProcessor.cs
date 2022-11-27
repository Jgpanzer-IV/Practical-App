using Microsoft.EntityFrameworkCore;
using MQTT_WebClient.Database;
using MQTT_WebClient.Services.Interfaces;
using MQTTnet;
using MQTTnet.Client;

namespace MQTT_WebClient.Services.Implementations;

public class PublishProcessor : IPublisherProcessor{

    private readonly DbContextOptions<ApplicationDbContext> _dbContext;

    private MqttFactory _mqttFactory;
    private IMqttClient _mqttClient;
 

    public PublishProcessor(DbContextOptions<ApplicationDbContext> dbContext)
    {
        _dbContext = dbContext;
        _mqttFactory = new MqttFactory();
        _mqttClient = _mqttFactory.CreateMqttClient();
    }

    ~PublishProcessor(){
        _mqttClient.Dispose();
    }

    public async Task InitializeConnectionAsync(string broker, int port){
        
        // Create clietn option to configure the server and port that will be connected.
        var mqttClientOption = new MqttClientOptionsBuilder()
            .WithTcpServer(broker,port)
            .Build();
        // Connect to the specified server and port
        await _mqttClient.ConnectAsync(mqttClientOption,CancellationToken.None);
        // Set background task to hanble the disconnection.
        _mqttClient.DisconnectedAsync += e => DisconnectHandlerAsync();
    }

    public async Task PublishMessageAsync(string message, string topic){
        // Build the message and configure the topic to be sent.
        var applicationMessage = new MqttApplicationMessageBuilder()
            .WithTopic(topic)
            .WithPayload(message)
            .Build();
        // publish the message 
        await _mqttClient.PublishAsync(applicationMessage,CancellationToken.None);
    }

    private Task DisconnectHandlerAsync(){
        Console.WriteLine(" ~~~ Disconnected ~~~");
        Console.WriteLine(" ~~~ Doing dispose connection ~~~");
        return Task.CompletedTask;
    }

}