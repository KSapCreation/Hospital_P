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
    public class DL_InvoiceDetail
    {
        SqlConnection con = new SqlConnection(DL_Connection.GetConnection);
        public DataTable DL_SearchServiceInvoice(ML_InvoiceDetail objML_InvoiceDetail)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_InvoiceDetail.Name),
                                    new SqlParameter("@FromDate",objML_InvoiceDetail.FromDate),
                                    new SqlParameter("@ToDate",objML_InvoiceDetail.ToDate)
                                };
            return SqlHelper.ExecuteDataset(con, "SPCN_Search_Service_Invoice", par).Tables[0];
        }
         public DataTable DL_BindVisitorList(ML_InvoiceDetail objML_InvoiceDetail)
         {
             SqlParameter[] par ={new SqlParameter("@ID",objML_InvoiceDetail.ID)
                                };
             return SqlHelper.ExecuteDataset(con, "SPCN_Hotel_Check_In_RoomNo", par).Tables[0];
         }

    }
}