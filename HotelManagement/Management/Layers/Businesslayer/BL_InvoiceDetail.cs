using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HotelManagement.Management.Layers.DataLayer;
using HotelManagement.Management.Layers.ModelLayer;
using System.Data;

namespace HotelManagement.Management.Layers.Businesslayer
{
    public class BL_InvoiceDetail
    {
        DL_InvoiceDetail objDL_InvoiceDetail = new DL_InvoiceDetail();
        public DataTable BL_SearchServiceInvoice(ML_InvoiceDetail objML_InvoiceDetail)
        {
            return objDL_InvoiceDetail.DL_SearchServiceInvoice(objML_InvoiceDetail);
        }
        public DataTable BL_BindVisitorList(ML_InvoiceDetail objML_InvoiceDetail)
        {
            return objDL_InvoiceDetail.DL_BindVisitorList(objML_InvoiceDetail);
        }
    }
}