using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using hotelManagement.H.layers.ModelLayers;
using Microsoft.ApplicationBlocks.Data;
using System.Data;

namespace hotelManagement.H.layers.DataLayers
{
    public class DL_HospitalMaster
    {
        SqlConnection con = new SqlConnection(DL_Connection.GetConnection);

    }
}