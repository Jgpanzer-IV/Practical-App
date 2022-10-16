using MQTTnet.Client;
using MQTTnet;
using System.Text;

public class Program{

    public static async Task Main(){


        var mqttFactory = new MqttFactory();
         //string my_Broker = "localhost";
        string hiveM_Broker = "broker.hivemq.com";
        int hiveM_Port = 1883;
        
        using(var mqttClient = mqttFactory.CreateMqttClient()){

            // Create client option
            var mqttClientOption = new MqttClientOptionsBuilder()
                .WithTcpServer(hiveM_Broker,hiveM_Port)
                .Build();

            // Set Message handler 
            mqttClient.ApplicationMessageReceivedAsync += e => {

                // Perform operation here
                Console.WriteLine("\n     ------ +++  Catched incomming message +++ ---------");
                string message = Encoding.ASCII.GetString(e.ApplicationMessage.Payload);
                Console.WriteLine(message);

                return Task.CompletedTask;
            };

            mqttClient.DisconnectedAsync += e => {
                
                Console.WriteLine(" ~~~Disconnected~~~");
                Console.WriteLine(" ~~~Shutinh down the server~~~");

                return Task.CompletedTask;
            };


            // Making connection to the server using clientOption.
            await mqttClient.ConnectAsync(mqttClientOption,CancellationToken.None);
            Console.WriteLine("Connected to the server.");

            // Create Subscribe option connect to the subscribe.
            var mqttSubscribeOption = mqttFactory.CreateSubscribeOptionsBuilder()
                .WithTopicFilter(f => {f.WithTopic("myTopic");})
                .Build();

            // subscribe to the server with option
            await mqttClient.SubscribeAsync(mqttSubscribeOption,CancellationToken.None);
            
            Console.WriteLine("Connected to the mqtt server with topic:MyMQTTServer.");
            Console.WriteLine("Press any key to stop.");
            Console.ReadKey();

            // Call these two in stop or end of the line.
            // These will release and resetting the consumed resources.
            await mqttClient.DisconnectAsync();
            mqttClient.Dispose();
        }

    }

}