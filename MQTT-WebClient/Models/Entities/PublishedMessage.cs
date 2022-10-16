namespace MQTT_WebClient.Model.Entity;

public class PublishedMessage{

    public long Id {get;set;}
    public string Message {get;set;} = string.Empty;
    public DateTime PublishTime {get;set;}

    public string ServerUrl {get;set;} = string.Empty;
    public string? ServerPort {get;set;}
}