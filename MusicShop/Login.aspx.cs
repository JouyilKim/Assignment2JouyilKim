using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Security;

namespace MusicShop
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            
            LoginMidTier lmt = new LoginMidTier();
            SqlDataReader reader = lmt.Login(txtEmail.Text, txtPWD.Text);
            if (reader.Read())
            {
                /*  FormsAuthentication.SetAuthCookie(txtEmail.Text, false);
                 *this class is obslete said by many experienced developed
                 * coockie is even more fragile
                 * now a days people use token method for login authentication
                 */
               
                Response.Cookies["name"].Value = reader["name"].ToString();
                Response.Cookies["user_id"].Value = reader["ID"].ToString();
                Response.Cookies["date"].Value = DateTime.Now.ToString("HHmmss");
                
                /*
                 * roles is a colume in the user database to identify if it's 
                 * a customer or administer
                 */
                Response.Cookies["roles"].Value = reader["roles"].ToString();
                //Response.Cookies["roles"].Value = reader["roles"].ToString();

                Response.Cookies["name"].Expires= DateTime.Now.AddDays(10);
                Response.Cookies["user_id"].Expires = DateTime.Now.AddDays(10);
                Response.Cookies["date"].Expires = DateTime.Now.AddDays(10);
                Response.Cookies["roles"].Expires = DateTime.Now.AddDays(10);
                
                reader.Close();
                lmt.CloseConnection();
                Response.Redirect("Default.aspx");
            }
            else
            {
                lblLoginError.Text = "Login failed. check your id or password.";
            }

        }

        protected void lkbtnRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }
    }

}