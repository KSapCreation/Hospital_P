using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using hotelManagement.H.layers.DataLayers;
using hotelManagement.H.layers.ModelLayers;
using System.Data;

namespace hotelManagement.H.layers.BusinessLayers
{
    public class BL_Pharmacy
    {
        DL_Pharmacy objDL_Pharmacy = new DL_Pharmacy();
        public int BL_InsUpdUnitMaster(ML_Pharmacy ObjML_Pharmacy)
        {
            return objDL_Pharmacy.DL_InsUpdUnitMaster(ObjML_Pharmacy);
        }
        public DataTable BL_SearchUnitMaster(ML_Pharmacy ObjML_Pharmacy)
        {
            return objDL_Pharmacy.DL_SearchUnitMaster(ObjML_Pharmacy);
        }
        public DataTable BL_BindUnitMaster(ML_Pharmacy ObjML_Pharmacy)
        {
            return objDL_Pharmacy.DL_BindUnitMaster(ObjML_Pharmacy);
        }
        public int BL_InsUpdItemMaster(ML_Pharmacy ObjML_Pharmacy)
        {
            return objDL_Pharmacy.DL_InsUpdItemMaster(ObjML_Pharmacy);
        }
        public DataTable BL_SearchItem(ML_Pharmacy ObjML_Pharmacy)
        {
            return objDL_Pharmacy.DL_SearchItem(ObjML_Pharmacy);
        }
        public DataTable BL_BindItemMaster(ML_Pharmacy ObjML_Pharmacy)
        {
            return objDL_Pharmacy.DL_BindItemMaster(ObjML_Pharmacy);
        }
        public int BL_InsUpdVendorMaster(ML_Pharmacy ObjML_Pharmacy)
        {
            return objDL_Pharmacy.DL_InsUpdVendorMaster(ObjML_Pharmacy);
        }
        public DataTable BL_SelectVendorMaster(ML_Pharmacy ObjML_Pharmacy)
        {
            return objDL_Pharmacy.DL_SelectvendorMaster(ObjML_Pharmacy);
        }
        public DataTable BL_BindVendorMaster(ML_Pharmacy ObjML_Pharmacy)
        {
            return objDL_Pharmacy.DL_BindVendorMaster(ObjML_Pharmacy);
        }
        public DataTable BL_SelectCustomerMaster(ML_Pharmacy ObjML_Pharmacy)
        {
            return objDL_Pharmacy.DL_SelectCustomerMaster(ObjML_Pharmacy);
        }
        public DataTable BL_BindCustomerMaster(ML_Pharmacy ObjML_Pharmacy)
        {
            return objDL_Pharmacy.DL_BindCustomerMaster(ObjML_Pharmacy);
        }
        public int BL_InsUpdCustomerMaster(ML_Pharmacy ObjML_Pharmacy)
        {
            return objDL_Pharmacy.DL_InsUpdCustomerMaster(ObjML_Pharmacy);
        }
      
    }
}