using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BE.response
{
    [DataContract]
    public class EmployeeResponse
    {
        [DataMember(Order = 1)]
        public String name { get; set; }

        [DataMember(Order = 2)]
        public String location { get; set; }

        [DataMember(Order = 3)]
        public String email { get; set; }

        [DataMember(Order = 4)]
        public String historyNumber { get; set; }

        [DataMember(Order = 5)]
        public String dniNumber { get; set; }

        [DataMember(Order = 6)]
        public String standing { get; set; }

        [DataMember(Order = 7)]
        public long employeeId { get; set; }

    }
}
