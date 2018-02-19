using BE.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BE.response
{
    [DataContract]
    public class DataResponse<T>
    {
        [DataMember(Order = 1)]
        public GenericResponse response { get; set; }

        [DataMember(Order = 2)]
        public T data { get; set; }
    }
}
