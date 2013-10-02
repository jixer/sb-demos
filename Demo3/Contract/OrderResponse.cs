using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PCSUG.CSDemo2.Contract
{
    [DataContract]
    public class OrderResponse
    {
        [DataMember]
        public string OrderId { get; set; }

        [DataMember]
        public string Message { get; set; }

        [DataMember]
        public string Product { get; set; }
    }
}
