using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace MusicShop
{
    public class ProductAccess
    {
        string connectionString;
        SqlConnection con;
        public ProductAccess()
        {
            connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            con = new SqlConnection(connectionString);
            con.Open();
        }

        public int getMaxProductID()
        {

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select Max(product_id) from tblProduct";

            int maxID = Convert.ToInt16(cmd.ExecuteScalar().ToString());
            return maxID;
        }

        public bool SaveProduct(int product_id, string productName, float productPrice,
            string description, string type, string brand, string img)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "insert into tblProduct values(@product_id, @productName," +
                "@productPrice, @description, @type, @brand, @img)";

            cmd.Parameters.AddWithValue("@product_id", product_id);
            cmd.Parameters.AddWithValue("@productName", productName);
            cmd.Parameters.AddWithValue("@productPrice", productPrice);
            cmd.Parameters.AddWithValue("@description", description);
            cmd.Parameters.AddWithValue("@type", type);
            cmd.Parameters.AddWithValue("@brand", brand);
            cmd.Parameters.AddWithValue("@img", img);

            int i = 0;
            i = Convert.ToInt16(cmd.ExecuteNonQuery());
            if (i > 0)

                return true;
            else
                return false;
        }

        //not used due to gridview method 
        //was about to use in category multiple view
        public SqlDataReader GetProductsByType(string type)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from tblProduct where type = @type";

            //get all data from one type
            cmd.Parameters.AddWithValue("@type", type);
            
            return cmd.ExecuteReader();
        }

        /*
         * used to view on single item in ProductDetail.aspx
         * used to pass data to cart
         */
        public SqlDataReader SearchProductByID(int product_id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from tblProduct where product_id = @product_id";

            //get all data from one type
            cmd.Parameters.AddWithValue("@product_id", product_id);

            //cmd.ExecuteNonQuery();
            //DataTable dt = new DataTable();
            //SqlDataAdapter da = new SqlDataAdapter(cmd);
            //da.Fill(dt);
            

            return cmd.ExecuteReader();
        }

        //this method became useless due to powerful gridview!
        public int DeleteProductByID(int product_id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "delete from tblProduct where product_id = @product_id";

            //get all data from one type
            cmd.Parameters.AddWithValue("@product_id", product_id);

            return cmd.ExecuteNonQuery();
        }


        //this method became useless due to powerful grid view!
        public void UpdateProduct(int product_id, string productName, float productPrice,
            string description, string type, string brand, string img)

        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "update tblProduct set productName=@productName" +
                "productPrice=@productPrice, description=@description, type=@type" +
                "brand=@brand,img=@img where product_id=@product_id)";

            cmd.Parameters.AddWithValue("@product_id", product_id);
            cmd.Parameters.AddWithValue("@product_Name", productName);
            cmd.Parameters.AddWithValue("@productPrice", productPrice);
            cmd.Parameters.AddWithValue("@description", description);
            cmd.Parameters.AddWithValue("@type", type);
            cmd.Parameters.AddWithValue("@brand",brand);
            cmd.Parameters.AddWithValue("@img", img);

            cmd.ExecuteNonQuery();
        }


        public void CloseConnection()
        {
            //Step 6 - Close the connection.
            con.Close();
            con = null;
        }


    }
}