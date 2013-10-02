using RabbitMQ.Client;
using RabbitMQ.Client.MessagePatterns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCSUG.CSDemo2.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory();
            factory.Protocol = Protocols.AMQP_0_9;
            factory.HostName = "localhost";
            factory.Port = AmqpTcpEndpoint.UseDefaultPort;

            using (var con = factory.CreateConnection())
            {                
                using (var channel = con.CreateModel())
                {
                    SimpleRpcClient client = new SimpleRpcClient(channel, "test");

                    Console.WriteLine("Connected to the queue.  Type in a product name to submit an order or type 'q' + <ENTER> to quit...");
                    string productName = Console.ReadLine();
                    while (productName != "q")
                    {
                        byte[] body = ASCIIEncoding.ASCII.GetBytes(productName);
                        Console.WriteLine("Submitting order for product '{0}'...", productName);
                        var responseBody = client.Call(body);
                        string response = ASCIIEncoding.ASCII.GetString(responseBody);
                        Console.WriteLine("Response recieved.  Order ID: {0}", response);

                        productName = Console.ReadLine();
                    } 

                   
                }
            }
        }
    }
}
