using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelManagement.Management.Layers.ModelLayer
{
    public class ML_RoomMaster
    {
        public string ID { get; set; }
        public string RoomName { get; set; }
        public string RoomNo { get; set; }
        public string RoomPrice { get; set; }
        public string CreatedBy { get; set; }
        public string ModifyBy { get; set; }
        public Int32 Is_Active { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
        public string HalfPrice { get; set; }
        public string TaxGroup { get; set; }



    }
    public class ML_Masters
    {
        public string ID { get; set; }
        public string StateName { get; set; }
        public string CityName { get; set; }      
        public string CreatedBy { get; set; }
        public string ModifyBy { get; set; }
        public string ProjectName { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public string Website { get; set; }
        public string EmailID { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string MobileNo { get; set; }
        public string TanNo { get; set; }
        public string PanNo { get; set; }
        public string GSTIN { get; set; }
        public string PublishDate { get; set; }





    }
}