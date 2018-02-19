using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BE.response
{
    [DataContract]
    public class LoginResponse
    {
        [DataMember(Order = 1)]
        public long userId { get; set; }

        [DataMember(Order = 2)]
        public String userLoginName { get; set; }

        [DataMember(Order = 3)]
        public long profileId { get; set; }

        [DataMember(Order = 4)]
        public String profileType { get; set; }
    }
}
