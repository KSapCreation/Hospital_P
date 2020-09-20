using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace hotelManagement.H.layers.ModelLayers
{
    public class ML_User_Access
    {
        public string ID { get; set; }
        public string UserName { get; set; }
        public string Passsword { get; set; }
        public string IP { get; set; }
        public string LoginDate { get; set; }
        public string ConformPasword { get; set; }
        public string CreatedDate { get; set; }
        public string ModifyDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifyBy { get; set; }
        public string ModulesName { get; set; }
        public string OldPassword { get; set; }
        public string LastName { get; set; }
        public string MobileNo { get; set; }
        public string EmailID { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string country { get; set; }
        public string Address { get; set; }
        public Boolean Activation { get; set; }


    }
}