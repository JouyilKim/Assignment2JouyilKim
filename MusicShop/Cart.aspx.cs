using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MusicShop
{
    public partial class WebForm7 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!cartStatus())
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "{nothing}", "alert('there is nothing in your cart! heading back to home');window.location.href='Default.aspx' ", true);
            }
        }

        protected void btnDeleteAll_Click(object sender, EventArgs e)
        {
            string cart_id = Request.Cookies["cart_id"].Value;

            OrderAccess oa = new OrderAccess();
            try
            {
                oa.DeleteCart(cart_id);
                Response.Cookies["cart_id"].Expires = DateTime.MinValue;
                Response.Cookies["itemQuantity"].Expires = DateTime.MinValue;


                ClientScript.RegisterClientScriptBlock(this.GetType(), "{delete Success}", "alert('Everything in Cart was deleted! heading back to home');window.location.href='Default.aspx' ", true);
            }
            catch
            {
                oa.DeleteCart(cart_id);
                ClientScript.RegisterClientScriptBlock(this.GetType(), "{error}", "alert('database connect error');window.location.href='Default.aspx' ", true);
            }
        }

        protected void btnCheckOut_Click(object sender, EventArgs e)
        {
            //delete cookies
            Response.Cookies["cart_id"].Expires = DateTime.MinValue;
            Response.Cookies["itemQuantity"].Expires = DateTime.MinValue;

            ClientScript.RegisterClientScriptBlock(this.GetType(), "{checkout Success}", "alert('Checkout successful! heading back to home');window.location.href='Default.aspx' ", true);

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

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            if (cartStatus())
            {
                if(Request.Cookies["itemQuantity"].Value == "1")    //if everything is deleted manually, clear all cart cookies
                {
                    Response.Cookies["cart_id"].Expires = DateTime.MinValue;
                    Response.Cookies["itemQuantity"].Expires = DateTime.MinValue;

                    ClientScript.RegisterClientScriptBlock(this.GetType(), "{cart empty}", "alert('Everything in your cart is deleted!');window.location.href='Default.aspx' ", true);
                }
                else
                {
                    Response.Cookies["itemQuantity"].Value = (Convert.ToInt16(Request.Cookies["itemQuantity"].Value) - 1).ToString();
                }
            }
            
        }

    }
}