using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Hospital_P.H.layers.BusinessLayers;
using Hospital_P.H.layers.ModelLayers;
using Hospital_P.H.layers.DataLayers;
using common;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Hospital_P.H
{
    public partial class ProductKey : System.Web.UI.Page
    {
        BL_Security objBL_Security = new BL_Security();
        ML_Secuirty objML_Secuirty = new ML_Secuirty();
        CommonClass objCommonClass = new CommonClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] == null)
            {
                Response.Redirect("Login.aspx");
            }
        }
        protected void GenerateKey(object sender, EventArgs e)
        {
            try
            {
                txtCodeCompany.Text = objCommonClass.GetEncrptProductKey(txtCompanyName.Text);
                txtCodeExpireDate.Text = objCommonClass.GetEncrptProductKey(txtExpireDate.Text);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('" + ex.Message.ToString() + " ')", true);
            }
        }
    }
}