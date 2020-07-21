using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace MusicShop
{
    public partial class WebForm6 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if the role is not admin, redirect to default
            if (!(Request.Cookies["roles"].Value == "2"))
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(),
                    "{noAccess}", "alert('{You have no Access to this!}');window.location.href='Default.aspx' ", true);
            }

            ProductAccess pa = new ProductAccess();
            txtProductID.Text = "" + (pa.getMaxProductID() + 1);
            pa.CloseConnection();   //should I close it?
        }

        protected void btnAddProduct_Click(object sender, EventArgs e)
        {
            ProductAccess pa = new ProductAccess();

            //all the elements to save to database
            int product_id = Convert.ToInt32(txtProductID.Text);
            string productName = txtProductName.Text;
            float productPrice = float.Parse(txtProductPrice.Text);
            string description = txtDescription.Text;
            string type = dropdownType.Text;
            string brand = txtBrand.Text;
            string image = "NA";

            string fileName = Path.GetFileName(fileUploadImg.FileName); //get file name
            

            string filePath = "~/images/";
          
            filePath += fileName;

            image = filePath; //change imgae name to the file name

            fileUploadImg.PostedFile.SaveAs(Server.MapPath(filePath));


            bool saveProduct = pa.SaveProduct(product_id, productName, productPrice, description,
                type, brand, image);

            if (saveProduct)
            {
                //notification for succeed and refresh the page
                ClientScript.RegisterClientScriptBlock(this.GetType(),
                    "{saveProduct}", "alert('{Product saved!}');window.location.href='AddProduct.aspx' ", true);
            }
            else
            {
                //notification failure
                ClientScript.RegisterClientScriptBlock(this.GetType(),
                    "{saveError}", "alert('{Save Failed! Contact the developer!}');window.location.href='AddProduct.aspx' ", true);
            }
           
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            Response.Redirect("EditProduct.aspx");
        }
    }
}