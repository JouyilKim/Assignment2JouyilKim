using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace MusicShop
{
    public partial class Master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {


                if (loginStatus())
                {
                    linkLogin.Text = "Logout"; //set link text to logout
                }
            }
            catch
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "{error}", "alert('{Master page load error}');window.location.href='Login.aspx' ", true);
            }

            try
            {
                linkCart.Text = "Cart (" + Convert.ToInt32(Request.Cookies["itemQuantity"].Value) + ")"; //set cart number if possible
            }
            catch
            {
                //label stays "Cart"
            }
        }

        protected void linkLogin_Click(object sender, EventArgs e)
        {
           
            try
            {
                if (loginStatus())    //logout; clear all cookies
                {
                    Response.Cookies["name"].Expires = DateTime.MinValue;   //delete user cookies
                    Response.Cookies["user_id"].Expires = DateTime.MinValue;
                    Response.Cookies["date"].Expires = DateTime.MinValue;
                    Response.Cookies["roles"].Expires = DateTime.MinValue;

                    linkLogin.Text = "Login"; //set link to "Login" again

                    try
                    {
                        if (cartStatus()) //if cart item is still there
                        {
                            OrderAccess oa = new OrderAccess();
                            oa.DeleteCart(Request.Cookies["cart_id"].Value);  //delete all cart orders from the database
                            Response.Cookies["cart_id"].Expires = DateTime.MinValue;
                            Response.Cookies["itemQuantity"].Expires = DateTime.MinValue;
                            //and delete cart cookie
                        }
                    }
                    catch
                    {
                        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "{error}", "alert('{Master page logout error}');window.location.href='Login.aspx' ", true);

                    }



                    Response.Redirect("Login.aspx");
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }

            }
            catch
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "{error}", "alert('{Master logout error}');window.location.href='Login.aspx' ", true);
            }
        }


        protected void linkAcc_Click(object sender, EventArgs e)
        {
            //if logined then go to acc info
            //if not, redirect
            try
            {

                if (loginStatus())
                {
                    string user_id = Request.Cookies["user_id"].Value;
                    Response.Redirect("UserDetail.aspx");
                }

                else
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "{Please Login First}", "alert('{Please Login First}');window.location.href='Login.aspx' ", true);
                    //essentail for the master page alert message
                }
            }
            catch
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "{error}", "alert('{Master page account error}');window.location.href='Login.aspx' ", true);

                //Response.Redirect("Login.aspx");
            }

        }

        protected void linkCart_Click(object sender, EventArgs e)
        {
            try
            {

                if (cartStatus())
                {
                    Response.Redirect("Cart.aspx");
                }

                else
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "{cart empty}", "alert('{Your Cart is Empty}'); ", true);
                    //essentail for the master page alert message
                }
            }
            catch
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "{error}", "alert('{Master page cart error}');window.location.href='Login.aspx' ", true);

                //Response.Redirect("Login.aspx");
            }
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

        //return true if cart is not empty
        protected bool cartStatus()
        {
            try
            {
                if (Request.Cookies["itemQuantity"].Value == "")
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