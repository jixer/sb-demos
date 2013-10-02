using PCSUG.CSDemo2.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace PCSUG.CSDemo2.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var factory = new System.ServiceModel.ChannelFactory<IInventoryService>("IInventoryService"))
            {
                factory.Faulted += Handle_Fault;
                var client = factory.CreateChannel();


                Console.WriteLine("Connected to the queue.  Type in a product name to submit an order or type 'q' + <ENTER> to quit...");
                string productName = Console.ReadLine();
                while (productName != "q")
                {
                    var req = new OrderRequest { Product = productName };
                    client.SubmitOrder(req);
                    Console.WriteLine("Order for product '{0}' submitted...", productName);
                    productName = Console.ReadLine();
                } 
            }
        }

        private static void Handle_Fault(object sender, EventArgs e)
        {
            int i = 0;
        }
    }
}
