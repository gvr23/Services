 using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BE.entities
{
    [DataContract]
    public class GenericResponse
    {
        [DataMember]
        public String message { get; set; }

        [DataMember]
        public int status { get; set; }
    }
}
