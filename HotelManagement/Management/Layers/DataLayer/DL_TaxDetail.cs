using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using HotelManagement.Management.Layers.ModelLayer;
using hotelManagement.Mangement.layers.DataLayers;
using Microsoft.ApplicationBlocks.Data;

namespace HotelManagement.Management.Layers.DataLayer
{
    public class DL_TaxDetail
    {
        SqlConnection con = new SqlConnection(DL_Connection.GetConnection);
        public int DL_InsUpdTaxRate(ML_TaxDetail objML_TaxDetail)
        {
            SqlParameter[] par ={new SqlParameter("@TaxRateID",objML_TaxDetail.ID),
                                    new SqlParameter("@TaxName",objML_TaxDetail.TaxName),                                
                                    new SqlParameter("@IsActive",objML_TaxDetail.isActive),                                
                                         new SqlParameter("@CreatedBy",objML_TaxDetail.CreatedBy),
                                    new SqlParameter("@ModifyBy",objML_TaxDetail.ModifyBy)
                                };
            return SqlHelper.ExecuteNonQuery(con, "SPCN_Insert_Tax_Rate_Master", par);
        }
        public int DL_InsUpdTaxRateDetail(ML_TaxDetail objML_TaxDetail)
        {
            SqlParameter[] par ={new SqlParameter("@TaxRateID",objML_TaxDetail.ID),
                                    new SqlParameter("@Taxrate",objML_TaxDetail.TaxRate)                              
                                  
                                };
            return SqlHelper.ExecuteNonQuery(con, "SPCN_Insert_Tax_Rate_Detail", par);
        }
        public int DL_DeleteTaxRateDetail(ML_TaxDetail objML_TaxDetail)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_TaxDetail.ID),                                   
                                };
            return SqlHelper.ExecuteNonQuery(con, "SPCN_Tax_Rate_Detail_Delete", par);
        }
        public DataTable DL_SelectTaxRateDetail(ML_TaxDetail objML_TaxDetail)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_TaxDetail.ID)                                                              
                                  
                                };
            return SqlHelper.ExecuteDataset(con, "SPCN_Tax_Rate_Select", par).Tables[0];
        }
        public DataTable DL_BindTaxRateDetail(ML_TaxDetail objML_TaxDetail)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_TaxDetail.ID)                                                              
                                  
                                };
            return SqlHelper.ExecuteDataset(con, "SPCN_Tax_Rate_Bind", par).Tables[0];
        }
        public DataTable DL_BindTaxRateinfo(ML_TaxDetail objML_TaxDetail)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_TaxDetail.ID)                                                              
                                  
                                };
            return SqlHelper.ExecuteDataset(con, "SPCN_Tax_Rate", par).Tables[0];
        }
        public int DL_DeleteTaxRateMaster(ML_TaxDetail objML_TaxDetail)
        {
            SqlParameter[] par ={new SqlParameter("@TaxRateID",objML_TaxDetail.ID),                                                              
                                  
                                };
            return SqlHelper.ExecuteNonQuery(con, "SPCN_Tax_Rate_Master_Delete", par);
        }
        public int DL_InsUpdTaxGroupDetail(ML_TaxDetail objML_TaxDetail)
        {
            SqlParameter[] par ={new SqlParameter("@TaxGroupID",objML_TaxDetail.ID),
                                    new SqlParameter("@TaxRateID",objML_TaxDetail.TaxRateID),
                                    new SqlParameter("@Taxrate",objML_TaxDetail.TaxRate),                            
                                  new SqlParameter("@Is_Default",objML_TaxDetail.Is_Default)  
                                };
            return SqlHelper.ExecuteNonQuery(con, "SPCN_Insert_Tax_Group_Detail", par);
        }
        public int DL_DeleteTaxGroupDetail(ML_TaxDetail objML_TaxDetail)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_TaxDetail.ID),                                   
                                };
            return SqlHelper.ExecuteNonQuery(con, "SPCN_Tax_Group_Detail_Delete", par);
        }
        public int DL_InsUpdTaxGroup(ML_TaxDetail objML_TaxDetail)
        {
            SqlParameter[] par ={new SqlParameter("@TaxGroupID",objML_TaxDetail.ID),
                                    new SqlParameter("@TaxGroupName",objML_TaxDetail.TaxGroup),                                
                                    new SqlParameter("@IsActive",objML_TaxDetail.isActive),                                
                                         new SqlParameter("@CreatedBy",objML_TaxDetail.CreatedBy),
                                    new SqlParameter("@ModifyBy",objML_TaxDetail.ModifyBy)
                                };
            return SqlHelper.ExecuteNonQuery(con, "SPCN_Insert_Tax_Group_Master", par);
        }
        public DataTable DL_SelectTaxGroupDetail(ML_TaxDetail objML_TaxDetail)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_TaxDetail.ID)                                                              
                                  
                                };
            return SqlHelper.ExecuteDataset(con, "SPCN_Tax_Group_Select", par).Tables[0];
        }
        public DataTable DL_BindTaxGroup(ML_TaxDetail objML_TaxDetail)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_TaxDetail.ID)                                                              
                                  
                                };
            return SqlHelper.ExecuteDataset(con, "SPCN_Tax_Group_Bind", par).Tables[0];
        }
    }

}