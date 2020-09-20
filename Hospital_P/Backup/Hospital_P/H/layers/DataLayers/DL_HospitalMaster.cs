using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using Hospital_P.H.layers.ModelLayers;
using Microsoft.ApplicationBlocks.Data;
using System.Data;

namespace Hospital_P.H.layers.DataLayers
{
    public class DL_HospitalMaster
    {
        SqlConnection con = new SqlConnection(DL_Connection.GetConnection);

    }
}