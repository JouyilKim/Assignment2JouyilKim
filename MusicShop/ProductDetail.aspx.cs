using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

/*
 * this page is to show a single product which customer wants to see
 * with add to cart function
 * customer can choose itme amount (quantity)
 * cart item will be saving to database
 * only cart_id and quantity is saving to cookies
 */

namespace MusicShop
{
    public partial class WebForm8 : System.Web.UI.Page
    {
        protected int product_id = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            product_id = Convert.ToInt16(Request.QueryString["product_id"]);
            ProductAccess pa = new ProductAccess();
            SqlDataReader reader = pa.SearchProductByID(product_id);
            OrderAccess oa = new OrderAccess();

            while (reader.Read())
            {
                //set the datas to the UI
                ImageProduct.ImageUrl = reader.GetString(6);
                lblProductName.Text = reader.GetString(5) + " " + reader.GetString(1);
                lblPrice.Text = "$" + reader.GetDouble(2);
                lblDescription.Text = reader.GetString(3);

            }
            pa.CloseConnection();
        }

        protected void btnAddToCart_Click(object sender, EventArgs e)
        {
            if (!loginStatus())
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(),
                    "{Login first}", "alert('Please Login First!');", true);

            }
            else
            {
                OrderAccess oa = new OrderAccess();
                ProductAccess pa = new ProductAccess();
                SqlDataReader reader = pa.SearchProductByID(product_id);

                while (reader.Read())   //while search product succeed
                {
                    //parameters to send in 
                    int order_id = oa.getMaxOrderID() + 1;
                    int customer_id = Convert.ToInt16(Request.Cookies["user_id"].Value);
                    DateTime dateTime = DateTime.Now;
                    float orderTotalPrice = float.Parse(reader.GetDouble(2).ToString()) * Convert.ToInt16(dropdownQuantity.Text);
                    int orderQuantity = Convert.ToInt16(dropdownQuantity.Text);

                    int cart_id = Convert.ToInt32(customer_id.ToString() + Request.Cookies["date"].Value);
                    //generates a unique cart_id

                    try
                    {
                        //save the cart_id to cookie for checkout screen
                        Response.Cookies["cart_id"].Value = cart_id.ToString();

                        Response.Cookies["cart_id"].Expires = DateTime.Now.AddDays(10);

                        //save order thru database layer
                        oa.SaveOrder(order_id, customer_id, dateTime, product_id, orderTotalPrice, orderQuantity, cart_id);

                        int a = 1;  //identify if it's the first order after login
                        if (!cartStatus()) //if it's the first order, cart quantity will be 1
                        {
                            Response.Cookies["itemQuantity"].Value = a.ToString(); //if so, set 1 to cart quantity
                            Response.Cookies["itemQuantity"].Expires = DateTime.Now.AddDays(10);
                        }
                        else
                        {

                            Response.Cookies["itemQuantity"].Value = (Convert.ToInt16(Request.Cookies["itemQuantity"].Value) + 1).ToString();
                            //if not, plus 1 to the cart quantity
                        }
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "{Order Success}", "alert('Order Succesfull Added');window.location.href='Default.aspx' ", true);
                    }
                    catch
                    {
                        //shoe error to tell item save failed
                        ClientScript.RegisterClientScriptBlock(this.GetType(),
                           "{error}", "alert('{productDetail error!}'); window.location.href='Default.aspx'", true);
                    }

                }


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