using RabbitMQ.Client;
using RabbitMQ.Client.MessagePatterns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCSUG.CSDemo2.Service
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
                    channel.QueueDeclare("test", false, false, false, null);
                    var consumer = new Subscription(channel, "test");

                    var server = new MySimpleRpcServer(consumer);
                    var t = Task.Factory.StartNew(server.MainLoop);

                    Console.WriteLine("Service started.  Press any key to quit...");
                    Console.ReadKey();
                    server.Close();
                    t.Wait();
                }
            }
        }
    }
}
