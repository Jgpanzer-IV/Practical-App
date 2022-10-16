namespace MQTT_WebClient.Services.Interfaces;

public interface ISubscribeProcessor{
        
        Task InitializationAsync(string broker, int port);
        Task ProcessMessageAsync(string message);
        Task DisconnectedAsync();

}