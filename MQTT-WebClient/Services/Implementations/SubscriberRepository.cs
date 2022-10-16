using MQTT_WebClient.Model.Entity;
using MQTT_WebClient.Services.Interfaces;
using MQTT_WebClient.Database;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace MQTT_WebClient.Services.Implementations;

public class SubscriberRepository : ISubscriberRepository
{

    private readonly ApplicationDbContext _dbContext;
    public SubscriberRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<SubscribedMessage?> CreateAsync(string newMessage)
        => Task.Run(() => {
            if (_dbContext.SubscribedMessages == null)
                return null;
            SubscribedMessage newEntity = new(){
                Message = newMessage,
                ServerUrl = "broker.hivemq.com",
                ServerPort = "1883",
                SubscribTime = DateTime.Now,
            }; 
            SubscribedMessage createdEntity = _dbContext.SubscribedMessages.Add(newEntity).Entity;
            int result = _dbContext.SaveChanges();
            return (result >= 1)? createdEntity:null;
        });


    public Task<bool> DeleteAsync(int id)
        => Task.Run(() => {
            if (_dbContext.SubscribedMessages == null)
                return false;
            SubscribedMessage deletedEntity = _dbContext.SubscribedMessages.First(e => e.Id == id);
            _dbContext.SubscribedMessages.Remove(deletedEntity);
            int result = _dbContext.SaveChanges();
            return (result != 0)? true:false;
        });

    public Task<IList<SubscribedMessage>?> RetrieveAsync()
        => Task.Run(() => {
            if (_dbContext.SubscribedMessages == null)
                return null;
            IList<SubscribedMessage>? retrievedEntity = _dbContext.SubscribedMessages.AsNoTracking().ToList();
            return (retrievedEntity.Count != 0)? retrievedEntity:null;
        });

    public Task<SubscribedMessage?> RetrieveByIdAsync(int id)
        => Task.Run(() => _dbContext.SubscribedMessages?.FirstOrDefault(e => e.Id == id)); 
    
    public Task<SubscribedMessage?> UpdateAsync(SubscribedMessage existsMessage)
        => Task.Run(() => {
            if (_dbContext.SubscribedMessages == null)
                return null;
            SubscribedMessage? updatedEntity = _dbContext.SubscribedMessages.Update(existsMessage).Entity;
            int result = _dbContext.SaveChanges();
            return (result == 1)? updatedEntity:null;
        });
}