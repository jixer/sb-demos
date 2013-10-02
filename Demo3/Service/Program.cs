using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace PCSUG.CSDemo2.Service
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var host = new ServiceHost(typeof(InventoryService)))
            {
                host.Faulted += Handle_Fault;
                host.Open();                

                Console.WriteLine("Service started.  Press any key to quit...");
                Console.ReadKey(); 
            }
        }

        private static void Handle_Fault(object sender, EventArgs e)
        {
            int i = 0;
        }
    }
}
