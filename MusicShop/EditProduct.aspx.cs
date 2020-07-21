using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;


namespace MusicShop
{
    public partial class WebForm4 : System.Web.UI.Page
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

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = GridView1.Rows[e.RowIndex] as GridViewRow;
            FileUpload FileUpload1 = (FileUpload)GridView1.Rows[e.RowIndex].FindControl("fileUploadEdit1");

            if (FileUpload1 != null && FileUpload1.HasFile)
            {
                string fileName = FileUpload1.FileName;

                FileUpload1.SaveAs(Server.MapPath("~/images/" + fileName));
            }
        }

        protected void btnAddProduct_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddProduct.aspx");
        }
    }

}