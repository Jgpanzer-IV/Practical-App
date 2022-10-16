using System.Text;
using MQTT_WebClient.Services.Interfaces;
using MQTTnet;
using MQTTnet.Client;
using Microsoft.EntityFrameworkCore;
using MQTT_WebClient.Database;
using MQTT_WebClient.Model.Entity;

namespace MQTT_WebClient.Services.Implementations;

public class SubscribeProcessor : ISubscribeProcessor
{
    private readonly DbContextOptions<ApplicationDbContext> _dbContext;
    MqttFactory _mqttFactory;
    IMqttClient _mqttClient;
    private string connectedBroker = string.Empty;
    private int connectedPort;

    public SubscribeProcessor(DbContextOptions<ApplicationDbContext> dbContext) {
        _dbContext = dbContext;
        _mqttFactory = new MqttFactory();
        _mqttClient = _mqttFactory.CreateMqttClient();
       
        _mqttClient.ApplicationMessageReceivedAsync += e 
            => ProcessMessageAsync(Encoding.ASCII.GetString(e.ApplicationMessage.Payload));

    }

    ~SubscribeProcessor(){
        _mqttClient.Dispose();
    }

    public async Task InitializationAsync(string broker, int port){
        
        connectedBroker = broker;
        connectedPort = port;

        var option = new MqttClientOptionsBuilder()
            .WithTcpServer(connectedBroker,connectedPort)
            .Build();
        await _mqttClient.ConnectAsync(option,CancellationToken.None);
        var subscribeOption =  _mqttFactory.CreateSubscribeOptionsBuilder()
                .WithTopicFilter(f => {f.WithTopic("myTopic");})
                .Build();
        await _mqttClient.SubscribeAsync(subscribeOption,CancellationToken.None);
    }

    public Task DisconnectedAsync()
    {
        // Perform any operation after the server disconnected.
        Console.WriteLine("Disconnected");
        return Task.CompletedTask;
    }

    public async Task ProcessMessageAsync(string message)
    {
        // Perform any operation after receieved message.
        Console.WriteLine("Got new message : "+message);
        SubscribedMessage newMessage = new(){
            Message = message,
            ServerUrl = connectedBroker,
            ServerPort = Convert.ToString(connectedPort),
            SubscribTime = DateTime.Now
        };
        await using var representDb = new ApplicationDbContext(_dbContext);
        if (representDb.SubscribedMessages != null){
            representDb.SubscribedMessages.Add(newMessage);
            int result = await representDb.SaveChangesAsync();
            Console.WriteLine((result >= 1)? "New message saved successfully.":"Failed to add the new message");
        }else
            Console.WriteLine("[-] Cannot access to the entity.");
    }


    
}