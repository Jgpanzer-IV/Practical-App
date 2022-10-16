using MQTT_WebClient.Model.Entity;

namespace MQTT_WebClient.Services.Interfaces;

public interface ISubscriberRepository{

    Task<IList<SubscribedMessage>?> RetrieveAsync();
    Task<SubscribedMessage?> RetrieveByIdAsync(int id);
    Task<SubscribedMessage?> CreateAsync(string newMessage);
    Task<SubscribedMessage?> UpdateAsync(SubscribedMessage existsMessage);
    Task<bool> DeleteAsync(int id);
}