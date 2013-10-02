using PCSUG.CSDemo2.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCSUG.CSDemo2.Service
{
    public class InventoryService : IInventoryService
    {
        public void SubmitOrder(OrderRequest request)
        {            
            string productName = request.Product;
            Console.WriteLine("Order recieved for product name '{0}'", productName);
        }
    }
}
