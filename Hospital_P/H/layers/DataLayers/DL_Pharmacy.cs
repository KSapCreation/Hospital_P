using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using hotelManagement.H.layers.ModelLayers;
using Microsoft.ApplicationBlocks.Data;
using System.Data;

namespace hotelManagement.H.layers.DataLayers
{
    public class DL_Pharmacy
    {
        SqlConnection con = new SqlConnection(DL_Connection.GetConnection);
        public int DL_InsUpdUnitMaster(ML_Pharmacy objML_Pharmacy)
        {
            SqlParameter[] par ={new SqlParameter("@UnitID",objML_Pharmacy.UnitID),
                                    new SqlParameter("@UnitName",objML_Pharmacy.UnitName),                                 
                                    new SqlParameter("@CreatedBy",objML_Pharmacy.CreatedBy), 
                                    new SqlParameter("@ModifyBy",objML_Pharmacy.ModifyBy),
                                    new SqlParameter("@Description",objML_Pharmacy.Description)
                                    
                                 };
            return SqlHelper.ExecuteNonQuery(con, "SPCN_InsUpdUnitMaster", par);
        }
        public DataTable DL_SearchUnitMaster(ML_Pharmacy objML_Pharmacy)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_Pharmacy.ID)
                                 
                                 };
            return SqlHelper.ExecuteDataset(con, "SPCN_Unit_Search", par).Tables[0];
        }
        public DataTable DL_BindUnitMaster(ML_Pharmacy objML_Pharmacy)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_Pharmacy.ID)
                                 
                                 };
            return SqlHelper.ExecuteDataset(con, "SPCN_Unit_Bind", par).Tables[0];
        }
        public int DL_InsUpdItemMaster(ML_Pharmacy objML_Pharmacy)
        {
            SqlParameter[] par ={new SqlParameter("@ItemCode",objML_Pharmacy.ItemCode),
                                    new SqlParameter("@ItemName",objML_Pharmacy.ItemName),
                                    new SqlParameter("@SaleAccount",objML_Pharmacy.SaleAccount),                                 
                                    new SqlParameter("@PurchaseAccount",objML_Pharmacy.PurchaseAccount),                                 
                                    new SqlParameter("@ItemCost",objML_Pharmacy.ItemCost),                                 
                                    new SqlParameter("@MRP",objML_Pharmacy.MRP),                                 
                                    new SqlParameter("@HSNCode",objML_Pharmacy.HSNCode),    
                                    new SqlParameter("@UOM",objML_Pharmacy.UOM),    
                                    new SqlParameter("@Active",objML_Pharmacy.Active),    
                                    new SqlParameter("@CreatedBy",objML_Pharmacy.CreatedBy), 
                                    new SqlParameter("@ModifyBy",objML_Pharmacy.ModifyBy)                                    
                                 };
            return SqlHelper.ExecuteNonQuery(con, "SPCN_InsUpdItemMaster", par);
        }
        public DataTable DL_SearchItem(ML_Pharmacy objML_Pharmacy)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_Pharmacy.ID)
                                 
                                 };
            return SqlHelper.ExecuteDataset(con, "SPCN_ItemMaster_Search", par).Tables[0];
        }
        public DataTable DL_BindItemMaster(ML_Pharmacy objML_Pharmacy)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_Pharmacy.ID)
                                 
                                 };
            return SqlHelper.ExecuteDataset(con, "SPCN_Item_Master_Select", par).Tables[0];
        }
        public int DL_InsUpdVendorMaster(ML_Pharmacy objML_Pharmacy)
        {
            SqlParameter[] par ={new SqlParameter("@VendorID",objML_Pharmacy.ID),
                                    new SqlParameter("@VendorName",objML_Pharmacy.VendorName),
                                    new SqlParameter("@Description",objML_Pharmacy.Description),                                 
                                    new SqlParameter("@Address",objML_Pharmacy.Address),                                 
                                    new SqlParameter("@Country",objML_Pharmacy.Country),                                 
                                    new SqlParameter("@State",objML_Pharmacy.State),                                 
                                    new SqlParameter("@City",objML_Pharmacy.City),    
                                    new SqlParameter("@MobileNo",objML_Pharmacy.MobileNo),    
                                    new SqlParameter("@Phone1",objML_Pharmacy.Phone1),    
                                    new SqlParameter("@Phone2",objML_Pharmacy.Phone2),    
                                    new SqlParameter("@EmailID",objML_Pharmacy.EmailID),    
                                    new SqlParameter("@WebSite",objML_Pharmacy.WebSite),    
                                    new SqlParameter("@AccountCode",objML_Pharmacy.AccountCode),    
                                    new SqlParameter("@GSTINNo",objML_Pharmacy.GSTINNo),    
                                    new SqlParameter("@CreatedBy",objML_Pharmacy.CreatedBy), 
                                    new SqlParameter("@ModifyBy",objML_Pharmacy.ModifyBy)                                    
                                 };
            return SqlHelper.ExecuteNonQuery(con, "SPCN_InsUpdVendorMaster", par);
        }
        public DataTable DL_SelectvendorMaster(ML_Pharmacy objML_Pharmacy)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_Pharmacy.ID)
                                 
                                 };
            return SqlHelper.ExecuteDataset(con, "SPCN_vendorMaster_Select", par).Tables[0];
        }
        public DataTable DL_BindVendorMaster(ML_Pharmacy objML_Pharmacy)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_Pharmacy.ID)
                                 
                                 };
            return SqlHelper.ExecuteDataset(con, "SPCN_vendorMaster_Bind", par).Tables[0];
        }
        public DataTable DL_SelectCustomerMaster(ML_Pharmacy objML_Pharmacy)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_Pharmacy.ID)
                                 
                                 };
            return SqlHelper.ExecuteDataset(con, "SPCN_CustomerMaster_Select", par).Tables[0];
        }
        public DataTable DL_BindCustomerMaster(ML_Pharmacy objML_Pharmacy)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_Pharmacy.ID)
                                 
                                 };
            return SqlHelper.ExecuteDataset(con, "SPCN_CustomerMaster_Bind", par).Tables[0];
        }
        public int DL_InsUpdCustomerMaster(ML_Pharmacy objML_Pharmacy)
        {
            SqlParameter[] par ={new SqlParameter("@CustomerID",objML_Pharmacy.ID),
                                    new SqlParameter("@CustomerName",objML_Pharmacy.CustomerName),
                                    new SqlParameter("@Description",objML_Pharmacy.Description),                                 
                                    new SqlParameter("@Address",objML_Pharmacy.Address),                                 
                                    new SqlParameter("@Country",objML_Pharmacy.Country),                                 
                                    new SqlParameter("@State",objML_Pharmacy.State),                                 
                                    new SqlParameter("@City",objML_Pharmacy.City),    
                                    new SqlParameter("@MobileNo",objML_Pharmacy.MobileNo),    
                                    new SqlParameter("@Phone1",objML_Pharmacy.Phone1),    
                                    new SqlParameter("@Phone2",objML_Pharmacy.Phone2),    
                                    new SqlParameter("@EmailID",objML_Pharmacy.EmailID),    
                                    new SqlParameter("@WebSite",objML_Pharmacy.WebSite),    
                                    new SqlParameter("@AccountCode",objML_Pharmacy.AccountCode),    
                                    new SqlParameter("@GSTINNo",objML_Pharmacy.GSTINNo),    
                                    new SqlParameter("@CreatedBy",objML_Pharmacy.CreatedBy), 
                                    new SqlParameter("@ModifyBy",objML_Pharmacy.ModifyBy)                                    
                                 };
            return SqlHelper.ExecuteNonQuery(con, "SPCN_InsUpdCustomerMaster", par);
        }
    }
}