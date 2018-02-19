using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BE.request
{
    [DataContract]
    public class MedicalFileRequest
    {
        [DataMember]
        public String dniNumber { get; set; }
    }
}
