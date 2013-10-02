using RabbitMQ.Client;
using RabbitMQ.Client.MessagePatterns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCSUG.CSDemo1.Subscriber
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
                    var queue = channel.QueueDeclare();
                    channel.QueueBind(queue.QueueName, "inventory", "*");
                    
                    var consumer = new SubscriptionConsumer();
                    Console.WriteLine("Receiving orders.  Press any key to quit...");
                    channel.BasicConsume(queue.QueueName, true, consumer);
                    Console.ReadKey();
                }
            }
        }
    }
}
