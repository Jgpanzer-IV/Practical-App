namespace MQTT_WebClient.Services.Interfaces;

public interface IPublisherProcessor{

    Task InitializeConnectionAsync(string broker, int port);
    Task PublishMessageAsync(string message, string topic);
}