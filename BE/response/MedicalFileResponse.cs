using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BE.response
{
    [DataContract]
    public class MedicalFileHeaderResponse
    {
        [DataMember(Order = 1)]
        public long idMedicalFile { get; set; }

        [DataMember(Order = 2)]
        public String documentNumber { get; set; }

        [DataMember(Order = 3)]
        public String firstNames { get; set; }
        
        [DataMember(Order = 4)]
        public String lastNames { get; set; }

        [DataMember(Order = 5)]
        public String historyNumber { get; set; }

        [DataMember(Order = 6)]
        public String locationShortName { get; set; }

        [DataMember(Order = 7)]
        public DateTime creationDate { get; set; }
    }
}
