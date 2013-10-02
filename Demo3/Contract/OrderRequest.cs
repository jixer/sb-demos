using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PCSUG.CSDemo2.Contract
{
    [DataContract]
    public class OrderRequest
    {
        [DataMember]
        public string Product { get; set; }
    }
}
