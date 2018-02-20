using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BE.response
{
    [DataContract]
    public class EvaluationHeaderResponse
    {
        [DataMember(Order = 1)]
        public Int64 evaluationId { get; set; }

        [DataMember(Order = 2)]
        public DateTime creationDate { get; set; }

        [DataMember(Order = 3)]
        public DateTime modifiedDate { get; set; }

        [DataMember(Order = 4)]
        public String evaluationStatus { get; set; }
    }
}
