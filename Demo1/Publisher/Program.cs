using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCSUG.CSDemo1.Publisher
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
                    channel.ExchangeDeclare("inventory", ExchangeType.Topic);
                    Console.WriteLine("Connected to the queue.  Type in an order ID to continue or pass 'q' to quit...");
                    string input = Console.ReadLine();
                    while (input != "q")
                    {
                        byte[] msgBytes = ASCIIEncoding.ASCII.GetBytes(input);
                        channel.BasicPublish("inventory", "*", null, msgBytes);
                        Console.WriteLine("Order {0} sent", input);
                        input = Console.ReadLine();
                    }  
                }
            }
        }
    }
}
