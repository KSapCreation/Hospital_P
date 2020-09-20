using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace hotelManagement.H.layers.ModelLayers
{
    public class ML_City_Master
    {
        public string CityId {get; set;}
        public string CityName { get; set; }
        public string StateId { get; set; }
        public string CreatedDate { get; set; }
        public string ModifyDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifyBy { get; set; }

    }
}