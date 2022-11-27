using System.Text;
using System.Text.Encodings;
using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Exceptions;



public class Program{


    public static async Task Main(){

        var mqttFactory = new MqttFactory();
        //string my_Broker = "localhost";
        string hiveM_Broker = "broker.hivemq.com";
        int hiveM_Port = 1883;

        using(var mqttClient = mqttFactory.CreateMqttClient()){
            
            // Create option for mqtt client that is set the broker and port.
            var mqttClientOption = new MqttClientOptionsBuilder()
                .WithTcpServer(hiveM_Broker,hiveM_Port)
                .Build();
            
            // Connect to the Broker with specified port.
            await mqttClient.ConnectAsync(mqttClientOption,CancellationToken.None);
            
            // Set the background account
            mqttClient.DisconnectedAsync += e => {
                Console.WriteLine(" ~~~ Disconnected ~~~");
                Console.WriteLine(" ~~~ Doing dispose connection ~~~");
                return Task.CompletedTask;
            };
         
            // Publishing message inside looping using MqttApplicationMessageBuilder() 
            while(true){
                Console.Write("Enter message to be published to the mqtt server [exit to stop] : ");
                string? message = Console.ReadLine();
                if (message == "exit")
                    break;
                    
                var applicationMessage = new MqttApplicationMessageBuilder()
                    .WithTopic("myTopic")
                    .WithPayload(message)
                    .Build();

                await mqttClient.PublishAsync(applicationMessage,CancellationToken.None);
            }
           

            

            await mqttClient.DisconnectAsync();

            Console.WriteLine("MQTT Public message to MyMQTTServer topic successfully.");

        }
    }

}