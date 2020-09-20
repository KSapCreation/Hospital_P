using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Hospital_P.H.layers.DataLayers;
using Hospital_P.H.layers.ModelLayers;
using System.Data;

namespace Hospital_P.H.layers.BusinessLayers
{
    public class BL_Patient
    {
        DL_Patient objDL_Patient = new DL_Patient();
        public int BL_InsUpdUserDetail(ML_Patient objML_Patient)
        {
            return objDL_Patient.DL_InsUpdUserAppointment(objML_Patient);
        }
        public int BL_InsUpdPatientAdmission(ML_Patient objML_Patient)
        {
            return objDL_Patient.DL_InsUpdPatientAdmission(objML_Patient);
        }
        public DataTable BL_BindPatientList(ML_Patient objML_Patient)
        {
            return objDL_Patient.DL_BindPatientList(objML_Patient);
        }
        public DataTable BL_BindWard(ML_Patient objML_Patient)
        {
            return objDL_Patient.DL_BindWard(objML_Patient);
        }
        public DataTable BL_Bindbed(ML_Patient objML_Patient)
        {
            return objDL_Patient.DL_BindBed(objML_Patient);
        }
        public DataTable BL_BindDepartment(ML_Patient objML_Patient)
        {
            return objDL_Patient.DL_BindDepartment(objML_Patient);
        }
        public DataTable BL_BindAppointment(ML_Patient objML_Patient)
        {
            return objDL_Patient.DL_BindAppointment(objML_Patient);
        }
        public DataTable BL_BindPaitent(ML_Patient objML_Patient)
        {
            return objDL_Patient.DL_BindPatient(objML_Patient);
        }
        public int BL_DeletePatient(ML_Patient objML_Patient)
        {
            return objDL_Patient.DL_DeletePatient(objML_Patient);
        }
        public DataTable BL_EditPatient(ML_Patient objML_Patient)
        {
            return objDL_Patient.DL_EditPatient(objML_Patient);
        }
        public DataTable BL_BindHospital(ML_Patient objML_Patient)
        {
            return objDL_Patient.DL_BindHospital(objML_Patient);
        }
        public int BL_InsUpdToken(ML_Patient objML_Patient)
        {
            return objDL_Patient.DL_InsUpdToken(objML_Patient);
        }
        public DataTable BL_SearchApplicant(ML_Patient objML_Patient)
        {
            return objDL_Patient.DL_SearchApplicant(objML_Patient);
        }
        public DataTable BL_BindToken(ML_Patient objML_Patient)
        {
            return objDL_Patient.DL_BindToken(objML_Patient);
        }
        public DataTable BL_DisplayToken(ML_Patient objML_Patient)
        {
            return objDL_Patient.DL_DisplayToken(objML_Patient);
        }
        public DataTable BL_SerachPatient(ML_Patient objML_Patient)
        {
            return objDL_Patient.DL_SearchPatient(objML_Patient);
        }
        public DataTable BL_SelectAppointment(ML_Patient objML_Patient)
        {
            return objDL_Patient.DL_SelectAppointment(objML_Patient);
        }
    }
}