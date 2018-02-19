using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BE.request
{
    [DataContract]
    public class LoginRequest
    {
        [DataMember(Order = 1)]
        public String userName { get; set; }

        [DataMember(Order = 2)]
        public String password { get; set; }
    }
}
