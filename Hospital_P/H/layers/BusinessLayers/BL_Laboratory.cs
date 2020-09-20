using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using hotelManagement.H.layers.ModelLayers;
using hotelManagement.H.layers.DataLayers;
using System.Data;

namespace hotelManagement.H.layers.BusinessLayers
{
    public class BL_Laboratory
    {
        DL_Laboratory objDL_Laboratory = new DL_Laboratory();
        public int BL_InsTestMaster(ML_Laboratory objML_Laboratory)
        {
            return objDL_Laboratory.DL_InsTestMaster(objML_Laboratory);
        }
        public DataTable BL_BindTestMaster(ML_Laboratory objML_Laboratory)
        {
            return objDL_Laboratory.DL_BindTestMaster(objML_Laboratory);
        }
        public int BL_DeleteTestMaster(ML_Laboratory objML_Laboratory)
        {
            return objDL_Laboratory.DL_DeleteTestMaster(objML_Laboratory);
        }
        public DataTable BL_EditTestMaster(ML_Laboratory objML_Laboratory)
        {
            return objDL_Laboratory.DL_EditTestMaster(objML_Laboratory);
        }
        public DataTable BL_SearchPatient(ML_Laboratory objML_Laboratory)
        {
            return objDL_Laboratory.DL_SearchPatient(objML_Laboratory);
        }
        public int BL_InsParameterMaster(ML_Laboratory objML_Laboratory)
        {
            return objDL_Laboratory.DL_InsParameterMaster(objML_Laboratory);
        }
        public DataTable BL_BindParameter(ML_Laboratory objML_Laboratory)
        {
            return objDL_Laboratory.DL_BindParameter(objML_Laboratory);
        }
        public DataTable BL_EditParameter(ML_Laboratory objML_Laboratory)
        {
            return objDL_Laboratory.DL_EditParameter(objML_Laboratory);
        }
        public int BL_DeleteParameter(ML_Laboratory objML_Laboratory)
        {
            return objDL_Laboratory.DL_DeleteParameter(objML_Laboratory);
        }
        public int BL_InsUpdParameterMapping(ML_Laboratory objML_Laboratory)
        {
            return objDL_Laboratory.DL_InsUpdParameterMapping(objML_Laboratory);
        }
        public DataTable BL_SelectTestParameterMapping(ML_Laboratory objML_Laboratory)
        {
            return objDL_Laboratory.DL_SelectTestParameterMapping(objML_Laboratory);
        }
        public int BL_InsUpdLabTestEntry(ML_Laboratory objML_Laboratory)
        {
            return objDL_Laboratory.DL_InsUpdLabTestEntry(objML_Laboratory);
        }
        public DataTable BL_SelectLabEntry(ML_Laboratory objML_Laboratory)
        {
            return objDL_Laboratory.DL_SelectLabEntry(objML_Laboratory);
        }
        public int BL_DeleteLabTestEntry(ML_Laboratory objML_Laboratory)
        {
            return objDL_Laboratory.DL_DeleteLabTestEntry(objML_Laboratory);
        }
        public DataTable BL_EditLabTestEntry(ML_Laboratory objML_Laboratory)
        {
            return objDL_Laboratory.DL_EditLabTestEntry(objML_Laboratory);
        }
        public DataTable BL_TestParameterValues(ML_Laboratory objML_Laboratory)
        {
            return objDL_Laboratory.DL_TestParameterValues(objML_Laboratory);
        }
        public int BL_InsUpdParameterValues(ML_Laboratory objML_Laboratory)
        {
            return objDL_Laboratory.DL_InsUpdParameterValuesHead(objML_Laboratory);
        }
        public int BL_InsUpdParameterValuesDetail(ML_Laboratory objML_Laboratory)
        {
            return objDL_Laboratory.DL_InsUpdParameterValuesDetail(objML_Laboratory);
        }
        public DataTable BL_BindLabReport(ML_Laboratory objML_Laboratory)
        {
            return objDL_Laboratory.DL_BindLabReport(objML_Laboratory);
        }
    }
}