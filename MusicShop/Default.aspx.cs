using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MusicShop
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {

                if (loginStatus())
                {
                    string userName = Request.Cookies["name"].Value;
                    lblName.Text = "Welcome " + userName + "  !!";

                    if (Convert.ToInt16(Request.Cookies["roles"].Value) == 1)
                    {
                        linkEditProduct.Text = "";
                        LinkEditUser.Text = "";
                    }
                    else if (Convert.ToInt16(Request.Cookies["roles"].Value) == 2)
                    {
                        linkEditProduct.Text = "Go Edit Products";
                        LinkEditUser.Text = "Go Edit Users";
                    }
                    else
                    {
                        linkEditProduct.Text = "";
                        LinkEditUser.Text = "";
                    }

                }
                else
                {
                    //todo make guest able to view things
                    lblName.Text = "Welcome to Music Shop!!";
                    linkEditProduct.Text = "";
                    LinkEditUser.Text = "";
                }

            }
            catch
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "{error}", "alert('{Default load error}');window.location.href='Login.aspx' ", true);

            }
        }

        protected void linkDefault1_Click(object sender, EventArgs e)
        {
            Response.Redirect("EditProduct.aspx");
        }
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("CustomerManage.aspx");
        }

        //return true if logged in
        protected bool loginStatus()
        {
            try
            {
                if (Request.Cookies["name"].Value == "")
                    return false;
                else
                    return true;
            }
            catch
            {
                return false;
            }
        }


    }
}