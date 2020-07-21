using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MusicShop
{
    public partial class WebForm13 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if the role is not admin, redirect to default
            if (!(Request.Cookies["roles"].Value == "2"))
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(),
                    "{noAccess}", "alert('{You have no Access to this!}');window.location.href='Default.aspx' ", true);
            }
        }
    }
}