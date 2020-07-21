using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MusicShop
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Register register = new Register();

            if (register.checkEmailExists(txtEmail.Text)) //check if exists
            {
                if (register.RegisterUser(txtEmail.Text, txtPWDConfirm.Text, txtName.Text, txtAdd.Text, txtPhone.Text))
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "{Register}", "alert('{Register Successful!}');window.location.href='Login.aspx' ", true);
                    //alert and redirect to login page
                }
                else
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "{error}", "alert('{Register Failed! Contact admin}');window.location.href='Register.aspx' ", true);

            }
            else
            {
                lblRegister.Text = "Email already registered! try another email";
            }


        }
    }
}