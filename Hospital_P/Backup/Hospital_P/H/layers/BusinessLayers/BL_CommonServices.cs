using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Hospital_P.H.layers.DataLayers;
using Hospital_P.H.layers.ModelLayers;
using System.Data;

namespace Hospital_P.H.layers.BusinessLayers
{
    public class BL_CommonServices
    {
        DL_CommonServices objDL_CommonServices = new DL_CommonServices();
        public int BL_InsUpdWardDetail(ML_CommonServices objML_CommonServices)
        {
            return objDL_CommonServices.DL_InsUpdWardDetail(objML_CommonServices);
        }
        public int BL_InsUpdBedDetail(ML_CommonServices objML_CommonServices)
        {
            return objDL_CommonServices.DL_InsUpdBedDetail(objML_CommonServices);
        }
        public int BL_DeleteDesignation(ML_CommonServices objML_CommonServices)
        {
            return objDL_CommonServices.DL_DeleteDesignation(objML_CommonServices);
        }
        public int BL_DeleteEmployeeMaster(ML_CommonServices objML_CommonServices)
        {
            return objDL_CommonServices.DL_DeleteEmployeeMaster(objML_CommonServices);
        }
        public int BL_InsUpdDepartment(ML_CommonServices objML_CommonServices)
        {
            return objDL_CommonServices.DL_InsUpdDepartment(objML_CommonServices);
        }
        public int BL_InsUpdDesignation(ML_CommonServices objML_CommonServices)
        {
            return objDL_CommonServices.DL_InsUpdDesignation(objML_CommonServices);
        }
        public int BL_InsUpdEmployeeMaster(ML_CommonServices objML_CommonServices)
        {
            return objDL_CommonServices.DL_InsUpdEmployeeMaster(objML_CommonServices);
        }
        public DataTable BL_BindDepartment(ML_CommonServices objML_CommonServices)
        {
            return objDL_CommonServices.DL_BindDepartment(objML_CommonServices);
        }
        public DataTable BL_BindDesigantion(ML_CommonServices objML_CommonServices)
        {
            return objDL_CommonServices.DL_BindDesigantion(objML_CommonServices);
        }
        public DataTable BL_BindEmployeeMaster(ML_CommonServices objML_CommonServices)
        {
            return objDL_CommonServices.DL_BindEmploeeMaster(objML_CommonServices);
        }   
        public DataTable BL_SelectDepartment(ML_CommonServices objML_CommonServices)
        {
            return objDL_CommonServices.DL_SelectDepartment(objML_CommonServices);
        }
        public DataTable BL_SelectWardMaster(ML_CommonServices objML_CommonServices)
        {
            return objDL_CommonServices.DL_SelectWardMaster(objML_CommonServices);
        }
        public DataTable BL_BindWardMaster(ML_CommonServices objML_CommonServices)
        {
            return objDL_CommonServices.DL_BindWardMaster(objML_CommonServices);
        }
        public DataTable BL_SelectBedMaster(ML_CommonServices objML_CommonServices)
        {
            return objDL_CommonServices.DL_SelectBedMaster(objML_CommonServices);
        }
        public DataTable BL_BindBedMaster(ML_CommonServices objML_CommonServices)
        {
            return objDL_CommonServices.DL_BindBedMaster(objML_CommonServices);
        }
        public DataTable BL_SelectDesingation(ML_CommonServices objML_CommonServices)
        {
            return objDL_CommonServices.DL_SelectDesignation(objML_CommonServices);
        }

        public DataTable BL_SelectEmpolyeeMaster(ML_CommonServices objML_CommonServices)
        {
            return objDL_CommonServices.DL_SelectEmployeeMaster(objML_CommonServices);
        }
    }
}