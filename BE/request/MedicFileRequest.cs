﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BE.request
{
    [DataContract]
    public class MedicFileRequest
    {
        [DataMember]
        public String historyNumber { get; set; }
    }
}
