using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hospital_P.H.layers.ModelLayers
{
    public class ML_HospitalMaster
    {
        public string ID { get; set; }
        public string UserName { get; set; }
        public string CreatedDate { get; set; }
        public string ModifyDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifyBy { get; set; }
    }
}