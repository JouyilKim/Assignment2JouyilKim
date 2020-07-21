using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Web.Security;

namespace MusicShop
{
    public class LoginMidTier
    {
        string connectionString;
        SqlConnection con;
        Register register = new Register(); //this is just for getting hash code, nothing about DB connection
        public LoginMidTier()
        {
            
            connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            con = new SqlConnection(connectionString);
            con.Open();
        }

        public SqlDataReader Login(string email, string password)
        {
            
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from tblUser where email=@email and password=@password";


            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@password", register.getPasswordHash(email, password));

            

            SqlDataReader reader = cmd.ExecuteReader();
            


            return reader;
        }
        public void CloseConnection()
        {
            con.Close();
            con = null;
        }
    }

}