using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelManagement.Management.Layers.ModelLayer
{
    public class ML_Visitors
    {
        public string CreatedBy { get; set; }
        public string ModifyBy { get; set; }
        public string ID { get; set; }        
        public string ProjectName { get; set; }
        public string Name { get; set; }
        public string NamePrefix { get; set; }
        public string Address { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
        public string RoomName { get; set; }
        public string RoomNo { get; set; }
        public string ArrivalDate { get; set; }
        public string ArrivalTime { get; set; }
        public string DepartureDate { get; set; }
        public string DepartureTime { get; set; }
        public Int32 Days { get; set; }
        public Int32 Adults { get; set; }
        public Int32 Child { get; set; }
        public string ReservationType { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
        public string MobileNo { get; set; }
        public string Fax { get; set; }
        public string Identity { get; set; }
        public string IdentityNo { get; set; }
        public string Gender { get; set; }
        public string BillType { get; set; }
        public string PaymentType { get; set; }
        public string PaymentMode { get; set; }
        public string RoomPrice { get; set; }
        public string ItemType { get; set; }
        public string ItemName { get; set; }
        public string VisitorID { get; set; }
        public string ServiceDaskID { get; set; }
        public decimal TotolAmount { get; set; }
        public decimal RoomAmount { get; set; }
        public decimal ServiceDeskAmount { get; set; }
        public decimal DiscountPer { get; set; }
        public string TaxName1 { get; set; }
        public decimal TaxRate1 { get; set; }
        public decimal TaxAmt1 { get; set; }
        public string TaxName2 { get; set; }
        public decimal TaxRate2 { get; set; }
        public decimal TaxAmt2 { get; set; }
        public string TaxName3 { get; set; }
        public decimal TaxRate3 { get; set; }
        public decimal TaxAmt3 { get; set; }
        public decimal TaxableAmount { get; set; }
        public decimal DiscountAmt { get; set; }
        public decimal GrandTotal { get; set; }





    }
}