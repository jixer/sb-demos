using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PCSUG.CSDemo1.Subscriber
{
    public class SubscriptionConsumer : IBasicConsumer
    {
        public void HandleBasicCancel(string consumerTag)
        {
            throw new NotImplementedException();
        }

        public void HandleBasicCancelOk(string consumerTag)
        {
            throw new NotImplementedException();
        }

        public void HandleBasicConsumeOk(string consumerTag)
        {
            return;
        }

        public void HandleBasicDeliver(string consumerTag, ulong deliveryTag, bool redelivered, string exchange, string routingKey, IBasicProperties properties, byte[] body)
        {
            string msg = ASCIIEncoding.ASCII.GetString(body);
            Console.WriteLine("Order Received: {0}", msg);
        }

        public void HandleModelShutdown(IModel model, ShutdownEventArgs reason)
        {
            return;
        }

        public IModel Model
        {
            get { throw new NotImplementedException(); }
        }
    }
}
