using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using hotelManagement.H.layers.ModelLayers;
using Microsoft.ApplicationBlocks.Data;
using System.Data;
using System.Data.SqlClient;

namespace hotelManagement.H.layers.DataLayers
{
    public class DL_Laboratory
    {
        SqlConnection con = new SqlConnection(DL_Connection.GetConnection);
        public int DL_InsTestMaster(ML_Laboratory objML_Laboratory)
        {
            SqlParameter[] par ={new SqlParameter("@TestID",objML_Laboratory.ID),
                                    new SqlParameter("@TestName",objML_Laboratory.TestName),
                                    new SqlParameter("@Cost",objML_Laboratory.Cost),
                                    new SqlParameter("@CreatedBy",objML_Laboratory.CreatedBy), 
                                    new SqlParameter("@ModifyBy",objML_Laboratory.ModifyBy)
                                    
                                 };
            return SqlHelper.ExecuteNonQuery(con, "OSP_InsUpdTestMaster", par);
        }
        public DataTable DL_BindTestMaster(ML_Laboratory objML_Laboratory)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_Laboratory.ID)
                                                                
                                 };
            return SqlHelper.ExecuteDataset(con, "SPCN_Test_Bind", par).Tables[0];
        }
        public int DL_DeleteTestMaster(ML_Laboratory objML_Laboratory)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_Laboratory.ID)
                                                                
                                 };
            return SqlHelper.ExecuteNonQuery(con, "SPCN_Test_Delete", par);
        }
        public DataTable DL_EditTestMaster(ML_Laboratory objML_Laboratory)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_Laboratory.ID)
                                                                
                                 };
            return SqlHelper.ExecuteDataset(con, "SPCN_Test_Edit", par).Tables[0];
        }
        public DataTable DL_SearchPatient(ML_Laboratory objML_Laboratory)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_Laboratory.ID)
                                                                
                                 };
            return SqlHelper.ExecuteDataset(con, "SPCN_Searching", par).Tables[0];
        }
        public int DL_InsParameterMaster(ML_Laboratory objML_Laboratory)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_Laboratory.ID),
                                    new SqlParameter("@Name",objML_Laboratory.TestName),
                                      new SqlParameter("@DefaultRange",objML_Laboratory.DefaultRange),
                                    new SqlParameter("@CreatedBy",objML_Laboratory.CreatedBy), 
                                    new SqlParameter("@ModifyBy",objML_Laboratory.ModifyBy)                                 
                                    
                                 };
            return SqlHelper.ExecuteNonQuery(con, "OSP_InsUpdParameterMaster", par);
        }
        public DataTable DL_BindParameter(ML_Laboratory objML_Laboratory)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_Laboratory.ID)
                                                                
                                 };
            return SqlHelper.ExecuteDataset(con, "SPCN_Parameter_Bind", par).Tables[0];
        }
        public DataTable DL_EditParameter(ML_Laboratory objML_Laboratory)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_Laboratory.ID)
                                                                
                                 };
            return SqlHelper.ExecuteDataset(con, "SPCN_Parameter_Edit", par).Tables[0];
        }
        public int DL_DeleteParameter(ML_Laboratory objML_Laboratory)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_Laboratory.ID)
                                                                
                                 };
            return SqlHelper.ExecuteNonQuery(con, "SPCN_Parameter_Delete", par);
        }
        public int DL_InsUpdParameterMapping(ML_Laboratory objML_Laboratory)
        {
            SqlParameter[] par ={new SqlParameter("@ParameterID",objML_Laboratory.ParameterID),
            new SqlParameter("@ParameterName",objML_Laboratory.ParameterName),
            new SqlParameter("@chkSelect",objML_Laboratory.chkSelect),
            new SqlParameter("@TestID",objML_Laboratory.TestID),
            new SqlParameter("@TestName",objML_Laboratory.TestName)                                                                
                                 };
            return SqlHelper.ExecuteNonQuery(con, "OSP_InsUpdParameterMapping", par);
        }
        public DataTable DL_SelectTestParameterMapping(ML_Laboratory objML_Laboratory)
        {
            SqlParameter[] par ={new SqlParameter("@TestID",objML_Laboratory.TestID)
                                                                
                                 };
            return SqlHelper.ExecuteDataset(con, "SPCN_Parameter_Mapping_Select", par).Tables[0];
        }
        public int DL_InsUpdLabTestEntry(ML_Laboratory objML_Laboratory)
        {
            SqlParameter[] par ={new SqlParameter("@LTE_Code",objML_Laboratory.ID),
                                    new SqlParameter("@PatientID",objML_Laboratory.PatientID),
                                    new SqlParameter("@Name",objML_Laboratory.Name),
                                    new SqlParameter("@TestID",objML_Laboratory.TestID),
                                    new SqlParameter("@Cost",objML_Laboratory.Cost),
                                    new SqlParameter("@CreatedBy",objML_Laboratory.CreatedBy), 
                                    new SqlParameter("@ModifyBy",objML_Laboratory.ModifyBy)
                                    
                                 };
            return SqlHelper.ExecuteNonQuery(con, "SPCN_InsUpdLabTest_Entry", par);
        }
        public DataTable DL_SelectLabEntry(ML_Laboratory objML_Laboratory)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_Laboratory.ID)
                                                                
                                 };
            return SqlHelper.ExecuteDataset(con, "SPCN_LabTestEntry_Bind", par).Tables[0];
        }
        public int DL_DeleteLabTestEntry(ML_Laboratory objML_Laboratory)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_Laboratory.ID)
                                                                
                                 };
            return SqlHelper.ExecuteNonQuery(con, "SPCN_LabTestEntry_Delete", par);
        }
        public DataTable DL_EditLabTestEntry(ML_Laboratory objML_Laboratory)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_Laboratory.ID)
                                                                
                                 };
            return SqlHelper.ExecuteDataset(con, "SPCN_LabTestEntry_Edit", par).Tables[0];
        }
        public DataTable DL_TestParameterValues(ML_Laboratory objML_Laboratory)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_Laboratory.ID),
                                    new SqlParameter("@PVCode",objML_Laboratory.PatientID)
                                                                
                                 };
            return SqlHelper.ExecuteDataset(con, "SPCN_Test_Paramters_Values", par).Tables[0];
        }
        public int DL_InsUpdParameterValuesHead(ML_Laboratory objML_Laboratory)
        {
            SqlParameter[] par ={new SqlParameter("@PVCodeID",objML_Laboratory.ID),
                                 new SqlParameter("@TestName",objML_Laboratory.TestName),
                                   new SqlParameter("@TestID",objML_Laboratory.TestID),     
                                      new SqlParameter("@CreatedBy",objML_Laboratory.CreatedBy), 
                                    new SqlParameter("@ModifyBy",objML_Laboratory.ModifyBy),   
                                    new SqlParameter("@PatientName",objML_Laboratory.PatientName)          
                                };
            return SqlHelper.ExecuteNonQuery(con, "SPCN_Insert_Parameter_Values_Head", par);
        }
        public int DL_InsUpdParameterValuesDetail(ML_Laboratory objML_Laboratory)
        {
            SqlParameter[] par ={new SqlParameter("@PVCodeID",objML_Laboratory.ID),
                                    new SqlParameter("@ParameterID",objML_Laboratory.ParameterID),
                                     new SqlParameter("@ParameterName",objML_Laboratory.ParameterName),
                                        
                                          new SqlParameter("@ParameterValues",objML_Laboratory.Parametervalues),
                                     
                                                                          
                                };
            return SqlHelper.ExecuteNonQuery(con, "SPCN_Insert_Parameter_Values_Detail", par);
        }
        public DataTable DL_BindLabReport(ML_Laboratory objML_Laboratory)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_Laboratory.PatientName)
                                                                
                                 };
            return SqlHelper.ExecuteDataset(con, "SPCN_Test_Paramters_Values_Select", par).Tables[0];
        }
    }
}