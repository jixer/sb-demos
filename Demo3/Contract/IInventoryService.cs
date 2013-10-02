using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace PCSUG.CSDemo2.Contract
{
    [ServiceContract()]
    public interface IInventoryService
    {
        [OperationContract(IsOneWay=true)]
        void SubmitOrder(OrderRequest request);
    }
}
