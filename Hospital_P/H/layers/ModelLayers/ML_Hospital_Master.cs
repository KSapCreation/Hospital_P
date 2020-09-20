using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace hotelManagement.H.layers.ModelLayers
{
    public class ML_Hospital_Master
    {
        public string HospitalNo { get; set; }
        public string HospitalName { get; set; }
        public string CreateDate { get; set; }
        public string Address { get; set; }
        public string Website { get; set; }
        public string HospitalType { get; set; }
        public string IsHms { get; set; }
        public string ProductName { get; set; }
        public string CityId { get; set; }
        public string StateId { get; set; }
        public string CreatedDate { get; set; }
        public string ModifyDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifyBy { get; set; }
    }
}