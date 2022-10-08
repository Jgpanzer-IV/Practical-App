using static System.Console;
using MQTTnet;
using MQTTnet.Server;

/*

    This will start a simple MQTT server which will accept any TCP connection.

*/

public class Program
{
    public static async Task Main(string[] args)
    {

        var mqttFactory = new MqttFactory();

        // Setting Server option
        var mqttServerOptions = new MqttServerOptionsBuilder()
            // The endpoint is set to localhost
            .WithDefaultEndpoint()
            // The port is set to 1866
            .WithDefaultEndpointPort(1886)
            .Build();

        // Create server object with server option
        using (var mqttServer = mqttFactory.CreateMqttServer(mqttServerOptions))
        {

            await mqttServer.StartAsync();

            WriteLine("Press any key to exit.");
            ReadKey();

            await mqttServer.StopAsync();
        }
    }
}