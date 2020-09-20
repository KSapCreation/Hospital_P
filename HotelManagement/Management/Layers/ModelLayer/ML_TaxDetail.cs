using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelManagement.Management.Layers.ModelLayer
{
    public class ML_TaxDetail
    {
        public string ID { get; set; }
        public string TaxName { get; set; }
        public string TaxGroup { get; set; }
        public Decimal TaxRate { get; set; }
        public string Description { get; set; }
        public string CreatedBy { get; set; }
        public string ModifyBy { get; set; }
        public Int32 isActive { get; set; }
        public string TaxRateID { get; set; }
        public Int32 Is_Default { get; set; }

    }

}