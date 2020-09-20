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
    public class DL_CommonServices
    {
        SqlConnection con = new SqlConnection(DL_Connection.GetConnection);

        public int DL_InsUpdWardDetail(ML_CommonServices objML_CommonServices)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_CommonServices.ID),
                                    new SqlParameter("@WardName",objML_CommonServices.WardName),                                  
                                    new SqlParameter("@CreatedBy",objML_CommonServices.CraetedBy), 
                                    new SqlParameter("@ModifyBy",objML_CommonServices.ModifyBy)
                                    
                                 };
            return SqlHelper.ExecuteNonQuery(con, "SPCN_InsUpdWardDetail", par);
        }
        public int DL_InsUpdBedDetail(ML_CommonServices objML_CommonServices)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_CommonServices.ID),
                                    new SqlParameter("@BedName",objML_CommonServices.BedName),  
                                    new SqlParameter("@No_Of_Bed",objML_CommonServices.No_Of_Bed),
                                    new SqlParameter("@WardID",objML_CommonServices.WardName),  
                                    new SqlParameter("@CreatedBy",objML_CommonServices.CraetedBy), 
                                    new SqlParameter("@ModifyBy",objML_CommonServices.ModifyBy)
                                    
                                 };
            return SqlHelper.ExecuteNonQuery(con, "SPCN_InsUpdBedDetail", par);
        }
        public int DL_DeleteDesignation(ML_CommonServices objML_CommonServices)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_CommonServices.ID),
                                 
                                 };
            return SqlHelper.ExecuteNonQuery(con, "SPCN_Designation_Delete", par);
        }
        public int DL_DeleteEmployeeMaster(ML_CommonServices objML_CommonServices)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_CommonServices.ID),
                                 
                                 };
            return SqlHelper.ExecuteNonQuery(con, "SPCN_EmployeeMaster_Delete", par);
        }
        public int DL_InsUpdDepartment(ML_CommonServices objML_CommonServices)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_CommonServices.ID),
                                    new SqlParameter("@DepartmentName",objML_CommonServices.Department),                                  
                                    new SqlParameter("@CreatedBy",objML_CommonServices.CraetedBy), 
                                    new SqlParameter("@ModifyBy",objML_CommonServices.ModifyBy)
                                    
                                 };
            return SqlHelper.ExecuteNonQuery(con, "SPCN_InsUpdDepartment", par);
        }
        public int DL_InsUpdDesignation(ML_CommonServices objML_CommonServices)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_CommonServices.ID),
                                    new SqlParameter("@DepartmentName",objML_CommonServices.Department),   
                                    new SqlParameter("@Designation",objML_CommonServices.Designation),   
                                    new SqlParameter("@CreatedBy",objML_CommonServices.CraetedBy), 
                                    new SqlParameter("@ModifyBy",objML_CommonServices.ModifyBy)
                                    
                                 };
            return SqlHelper.ExecuteNonQuery(con, "SPCN_InsUpdDesignation", par);
        }
        public DataTable DL_BindDepartment(ML_CommonServices objML_CommonServices)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_CommonServices.ID),
                                 
                                 };
            return SqlHelper.ExecuteDataset(con, "SPCN_Department_Bind", par).Tables[0];
        }
        public DataTable DL_BindDesigantion(ML_CommonServices objML_CommonServices)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_CommonServices.ID),
                                 
                                 };
            return SqlHelper.ExecuteDataset(con, "SPCN_Designation_Bind", par).Tables[0];
        }
        public int DL_InsUpdEmployeeMaster(ML_CommonServices objML_CommonServices)
        {
            SqlParameter[] par ={new SqlParameter("@EmployeeID",objML_CommonServices.ID),
                                    new SqlParameter("@FirstName",objML_CommonServices.FirstName),   
                                    new SqlParameter("@LastName",objML_CommonServices.LastName),  
                                    new SqlParameter("@DOB",objML_CommonServices.DOB),  
                                    new SqlParameter("@Gender",objML_CommonServices.Gender),  
                                    new SqlParameter("@MarriedStatus",objML_CommonServices.MarriedStatus),  
                                    new SqlParameter("@Age",objML_CommonServices.Age),  
                                    new SqlParameter("@Department",objML_CommonServices.Department),  
                                    new SqlParameter("@MobileNo",objML_CommonServices.MobileNo),  
                                    new SqlParameter("@EmailID",objML_CommonServices.EmailID),  
                                    new SqlParameter("@Designation",objML_CommonServices.Designation),  
                                    new SqlParameter("@Address",objML_CommonServices.Address),  
                                    new SqlParameter("@City",objML_CommonServices.City),  
                                    new SqlParameter("@State",objML_CommonServices.State),  
                                    new SqlParameter("@Country",objML_CommonServices.Country),  
                                    new SqlParameter("@Website",objML_CommonServices.Website),  
                                    new SqlParameter("@CreatedBy",objML_CommonServices.CraetedBy), 
                                    new SqlParameter("@ModifyBy",objML_CommonServices.ModifyBy)
                                    
                                 };
            return SqlHelper.ExecuteNonQuery(con, "SPCN_InsUpdEmployeeMaster", par);
        }

        public DataTable DL_BindEmploeeMaster(ML_CommonServices objML_CommonServices)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_CommonServices.ID),
                                 
                                 };
            return SqlHelper.ExecuteDataset(con, "SPCN_EmployeeMaster_Bind", par).Tables[0];
        }
      
        public DataTable DL_SelectDepartment(ML_CommonServices objML_CommonServices)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_CommonServices.ID),
                                 
                                 };
            return SqlHelper.ExecuteDataset(con, "SPCN_Department_Select", par).Tables[0];
        }
        public DataTable DL_SelectWardMaster(ML_CommonServices objML_CommonServices)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_CommonServices.ID),
                                 
                                 };
            return SqlHelper.ExecuteDataset(con, "SPCN_WardMaster_Select", par).Tables[0];
        }
        public DataTable DL_BindWardMaster(ML_CommonServices objML_CommonServices)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_CommonServices.ID),
                                 
                                 };
            return SqlHelper.ExecuteDataset(con, "SPCN_BindWardDetail", par).Tables[0];
        }
        public DataTable DL_SelectBedMaster(ML_CommonServices objML_CommonServices)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_CommonServices.ID),
                                 
                                 };
            return SqlHelper.ExecuteDataset(con, "SPCN_BedMaster_Select", par).Tables[0];
        }
        public DataTable DL_BindBedMaster(ML_CommonServices objML_CommonServices)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_CommonServices.ID),
                                 
                                 };
            return SqlHelper.ExecuteDataset(con, "SPCN_BindBedDetail", par).Tables[0];
        }
        public DataTable DL_SelectDesignation(ML_CommonServices objML_CommonServices)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_CommonServices.ID),
                                 
                                 };
            return SqlHelper.ExecuteDataset(con, "SPCN_Designation_Select", par).Tables[0];
        }

        public DataTable DL_SelectEmployeeMaster(ML_CommonServices objML_CommonServices)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_CommonServices.ID),
                                 
                                 };
            return SqlHelper.ExecuteDataset(con, "SPCN_EmployeeMaster_Select", par).Tables[0];
        }

      
    }
}