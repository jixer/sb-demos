using RabbitMQ.Client.MessagePatterns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PCSUG.CSDemo2.Service
{
    public class MySimpleRpcServer : SimpleRpcServer
    {
        public MySimpleRpcServer(Subscription consumer)
            : base(consumer)
        {

        }

        public override byte[] HandleCall(bool isRedelivered, RabbitMQ.Client.IBasicProperties requestProperties, byte[] body, out RabbitMQ.Client.IBasicProperties replyProperties)
        {
            string productName = ASCIIEncoding.ASCII.GetString(body);
            Console.WriteLine("Received order for producted named '{0}'", productName);
            string orderId = Guid.NewGuid().ToString();
            replyProperties = requestProperties;
            byte[] respBody = ASCIIEncoding.ASCII.GetBytes(orderId);
            return respBody;
        }
    }
}
