using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web;
using HotelManagement.Management.Layers.DataLayer;
using HotelManagement.Management.Layers.ModelLayer;
using System.Data;

namespace HotelManagement.Management.Layers.Businesslayer
{
    public class BL_TaxDetail
    {
        DL_TaxDetail objDL_TaxDetail = new DL_TaxDetail();
        public int BL_InsUpdTaxRate(ML_TaxDetail objML_TaxDetail)
        {
            return objDL_TaxDetail.DL_InsUpdTaxRate(objML_TaxDetail);
        }
        public int BL_InsUpdTaxRateDetail(ML_TaxDetail objML_TaxDetail)
        {
            return objDL_TaxDetail.DL_InsUpdTaxRateDetail(objML_TaxDetail);
        }
        public int BL_DeleteTaxRateDetail(ML_TaxDetail objML_TaxDetail)
        {
            return objDL_TaxDetail.DL_DeleteTaxRateDetail(objML_TaxDetail);
        }
        public DataTable BL_SelectTaxRateDetail(ML_TaxDetail objML_TaxDetail)
        {
            return objDL_TaxDetail.DL_SelectTaxRateDetail(objML_TaxDetail);
        }

        public DataTable BL_BindTaxRateDetail(ML_TaxDetail objML_TaxDetail)
        {
            return objDL_TaxDetail.DL_BindTaxRateDetail(objML_TaxDetail);
        }
        public DataTable BL_BindTaxRateinfo(ML_TaxDetail objML_TaxDetail)
        {
            return objDL_TaxDetail.DL_BindTaxRateinfo(objML_TaxDetail);
        }
        public int BL_DeleteTaxRateMaster(ML_TaxDetail objML_TaxDetail)
        {
            return objDL_TaxDetail.DL_DeleteTaxRateMaster(objML_TaxDetail);
        }
        public int BL_InsUpdTaxGroupDetail(ML_TaxDetail objML_TaxDetail)
        {
            return objDL_TaxDetail.DL_InsUpdTaxGroupDetail(objML_TaxDetail);
        }
        public int BL_DeleteTaxGroupDetail(ML_TaxDetail objML_TaxDetail)
        {
            return objDL_TaxDetail.DL_DeleteTaxGroupDetail(objML_TaxDetail);
        }
        public int BL_InsUpdTaxGroup(ML_TaxDetail objML_TaxDetail)
        {
            return objDL_TaxDetail.DL_InsUpdTaxGroup(objML_TaxDetail);
        }
        public DataTable BL_SelectTaxGroupDetail(ML_TaxDetail objML_TaxDetail)
        {
            return objDL_TaxDetail.DL_SelectTaxGroupDetail(objML_TaxDetail);
        }
        public DataTable BL_BindTaxGroup(ML_TaxDetail objML_TaxDetail)
        {
            return objDL_TaxDetail.DL_BindTaxGroup(objML_TaxDetail);
        }
    }
}