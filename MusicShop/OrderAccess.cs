using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace MusicShop
{
    public class OrderAccess
    {
        string connectionString;
        SqlConnection con;
        public OrderAccess()
        {
            connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            con = new SqlConnection(connectionString);
            con.Open();
        }
        public int getMaxOrderID()
        {
            int maxID;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select Max(order_id) from tblOrders";

            try
            {
                 maxID = Convert.ToInt16(cmd.ExecuteScalar().ToString());
            }
            catch
            {
                maxID = -1;
            }
            return maxID;
        }

        public bool SaveOrder(int order_id, int customer_id, DateTime orderTime,
            int product_id, double orderTotalPrice, int orderQuantity, int cart_id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "insert into tblOrders values(@order_id, @customer_id, @orderTime, @product_id," +
                "@orderTotalPrice, @orderQuantity, @cart_id)";

            cmd.Parameters.AddWithValue("@order_id", order_id);
            cmd.Parameters.AddWithValue("@customer_id", customer_id);
            cmd.Parameters.AddWithValue("@orderTime", orderTime);
            cmd.Parameters.AddWithValue("@product_id", product_id);
            cmd.Parameters.AddWithValue("@orderTotalPrice", orderTotalPrice);
            cmd.Parameters.AddWithValue("@orderQuantity", orderQuantity);
            cmd.Parameters.AddWithValue("@cart_id", cart_id);

            int i = 0;
            i = Convert.ToInt16(cmd.ExecuteNonQuery());
            if (i > 0)

                return true;
            else
                return false;
        }

        public void DeleteCart(string cart_id)
        {

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "DELETE FROM tblOrders WHERE cart_id = @cart_id";

            cmd.Parameters.AddWithValue("@cart_id", Convert.ToInt32(cart_id));
            cmd.ExecuteNonQuery();
        }
    }
}