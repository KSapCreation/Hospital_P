using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using Hospital_P.H.layers.ModelLayers;
using Microsoft.ApplicationBlocks.Data;
using System.Data;


namespace Hospital_P.H.layers.DataLayers
{
    public class DL_Patient
    {
        SqlConnection con = new SqlConnection(DL_Connection.GetConnection);
        public int DL_InsUpdUserAppointment(ML_Patient objML_Patient)
        {
            SqlParameter[] par ={new SqlParameter("@AppointmentNo",objML_Patient.AppointmentNo),
                                    new SqlParameter("@AppointmentDate",objML_Patient.AppointmentDate),
                                    new SqlParameter("@FirstName",objML_Patient.FirstName),
                                    new SqlParameter("@LastName",objML_Patient.LastName) ,
                                    new SqlParameter("@W_D_F_Name",objML_Patient.W_D_F_Name) ,
                                    new SqlParameter("@Gender",objML_Patient.Gender) ,
                                    new SqlParameter("@DOB",objML_Patient.DOB) ,
                                    new SqlParameter("@MobileNo",objML_Patient.MobileNo) ,
                                    new SqlParameter("@Address",objML_Patient.Address) ,
                                    new SqlParameter("@City",objML_Patient.City) ,
                                    new SqlParameter("@State",objML_Patient.State) ,
                                    new SqlParameter("@Amount",objML_Patient.Amount) ,
                                    new SqlParameter("@Doctor",objML_Patient.Doctor) ,
                                    new SqlParameter("@CreatedBy",objML_Patient.CreatedBy), 
                                    new SqlParameter("@ModifyBy",objML_Patient.ModifyBy)
                                    
                                 };
            return SqlHelper.ExecuteNonQuery(con, "SPCN_InsUpdUserAppointment", par);
        }
        public int DL_InsUpdPatientAdmission(ML_Patient objML_Patient)
        {
            SqlParameter[] par ={new SqlParameter("@AdmissionNo",objML_Patient.AdmissionNo),
                                    new SqlParameter("@AdmissionDate",objML_Patient.AdmissionDate),
                                    new SqlParameter("@FirstName",objML_Patient.FirstName),
                                    new SqlParameter("@LastName",objML_Patient.LastName) ,                                                                     
                                    new SqlParameter("@DOB",objML_Patient.DOB) ,
                                    new SqlParameter("@Gender",objML_Patient.Gender) ,
                                    new SqlParameter("@MarriedStatus",objML_Patient.MarriedStatus) ,
                                    new SqlParameter("@Age",objML_Patient.Age) ,
                                    new SqlParameter("@PhoneNo",objML_Patient.PhoneNo) ,
                                    new SqlParameter("@MobileNo",objML_Patient.MobileNo) ,                                    
                                    new SqlParameter("@EmailID",objML_Patient.EmailID) ,
                                    new SqlParameter("@MadicineInformation",objML_Patient.MadicineInformation) ,
                                    new SqlParameter("@HospitalName",objML_Patient.HospitalName) ,
                                    new SqlParameter("@Doctor",objML_Patient.Doctor) ,
                                    new SqlParameter("@Bed",objML_Patient.Bed) ,
                                    new SqlParameter("@Ward",objML_Patient.Ward) ,
                                    new SqlParameter("@Address",objML_Patient.Address) ,
                                    new SqlParameter("@City",objML_Patient.City) ,
                                    new SqlParameter("@State",objML_Patient.State) ,
                                    new SqlParameter("@Amount",objML_Patient.Amount) ,
                                    new SqlParameter("@Department",objML_Patient.Department) ,
                                    new SqlParameter("@CreatedBy",objML_Patient.CreatedBy), 
                                    new SqlParameter("@ModifyBy",objML_Patient.ModifyBy),
                                    new SqlParameter("@BillType",objML_Patient.BillType),
                                    new SqlParameter("@Charges",objML_Patient.Charges),
                                    new SqlParameter("@Complient",objML_Patient.Compilent)                                
                                    
                                 };
            return SqlHelper.ExecuteNonQuery(con, "SPCN_InsUpdPatientAdmission", par);
        }
        public DataTable DL_BindPatientList(ML_Patient objML_Patient)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_Patient.ID)
                                };
            return SqlHelper.ExecuteDataset(con, "SPCN_BindPatientList", par).Tables[0];
        }
        public DataTable DL_BindWard(ML_Patient objML_Patient)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_Patient.ID)
                                };
            return SqlHelper.ExecuteDataset(con, "SPCN_BindWardDetail", par).Tables[0];
        }
        public DataTable DL_BindBed(ML_Patient objML_Patient)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_Patient.ID)
                                };
            return SqlHelper.ExecuteDataset(con, "SPCN_BindBedDetail", par).Tables[0];
        }
        public DataTable DL_BindDepartment(ML_Patient objML_Patient)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_Patient.ID)
                                };
            return SqlHelper.ExecuteDataset(con, "SPCN_BindDepartment", par).Tables[0];
        }
        public DataTable DL_BindAppointment(ML_Patient objML_Patient)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_Patient.ID)
                                };
            return SqlHelper.ExecuteDataset(con, "SPCN_Bind_Appointment", par).Tables[0];
        }
        public DataTable DL_BindPatient(ML_Patient objML_Patient)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_Patient.ID)
                                };
            return SqlHelper.ExecuteDataset(con, "SPCN_BindPatientList", par).Tables[0];
        }
        public int DL_DeletePatient(ML_Patient objML_Patient)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_Patient.ID),
                                                                      
                                 };
            return SqlHelper.ExecuteNonQuery(con, "SPCN_Patient_Delete", par);
        }
        public DataTable DL_EditPatient(ML_Patient objML_Patient)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_Patient.ID)
                                };
            return SqlHelper.ExecuteDataset(con, "SPCN_Patient_Edit", par).Tables[0];
        }
        public DataTable DL_BindHospital(ML_Patient objML_Patient)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_Patient.ID)
                                };
            return SqlHelper.ExecuteDataset(con, "SPCN_Hospital_Bind", par).Tables[0];
        }
        public int DL_InsUpdToken(ML_Patient objML_Patient)
        {
            SqlParameter[] par ={new SqlParameter("@TokenID",objML_Patient.ID),
                                    new SqlParameter("@ApplicantName",objML_Patient.FirstName),
                                    new SqlParameter("@Slip_No",objML_Patient.AppointmentNo),
                                    new SqlParameter("@CreatedBy",objML_Patient.CreatedBy), 
                                    new SqlParameter("@ModifyBy",objML_Patient.ModifyBy)
                                    
                                    
                                 };
            return SqlHelper.ExecuteNonQuery(con, "SPCN_Insert_Token", par);
        }
        public DataTable DL_SearchApplicant(ML_Patient objML_Patient)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_Patient.ID)
                                };
            return SqlHelper.ExecuteDataset(con, "SPCN_Appointment_Search", par).Tables[0];
        }
        public DataTable DL_BindToken(ML_Patient objML_Patient)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_Patient.ID)
                                };
            return SqlHelper.ExecuteDataset(con, "SPCN_Bind_Token", par).Tables[0];
        }
        public DataTable DL_DisplayToken(ML_Patient objML_Patient)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_Patient.ID)
                                };
            return SqlHelper.ExecuteDataset(con, "SPCN_Display_Token", par).Tables[0];
        }
        public DataTable DL_SearchPatient(ML_Patient objML_Patient)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_Patient.ID)
                                };
            return SqlHelper.ExecuteDataset(con, "SPCN_Searching", par).Tables[0];
        }
        public DataTable DL_SelectAppointment(ML_Patient objML_Patient)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_Patient.ID)
                                };
            return SqlHelper.ExecuteDataset(con, "SPCN_Select_Appointment", par).Tables[0];
        }
    }
}