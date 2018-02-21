using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BE.request
{
    [DataContract]
    public class OsteoMuscularAnalysisRequest
    {
        [DataMember]
        public String historyNumber { get; set; }
    }
}
