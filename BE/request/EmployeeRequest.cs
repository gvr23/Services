using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BE.request
{
    [DataContract]
    public class EmployeeRequest
    {
        [DataMember]
        public String locationCode { get; set; }

        [DataMember]
        public String idNumber { get; set; }

        [DataMember]
        public String employeeFullName { get; set; }
    }
}
