using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebserviceDemo
{
    public class GetDataFromDB
    {
        internal static readonly string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        
        public static DataTable GetOrderDetails()
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmdSelect = new SqlCommand();
            cmdSelect.Connection = con;

            DataTable dt = new DataTable();

            cmdSelect.CommandType = CommandType.StoredProcedure;
            cmdSelect.CommandText = "GetOrderDetails";

            new SqlDataAdapter(cmdSelect).Fill(dt);
            con.Close();

            return dt;

        }
        public static DataTable GetOrderDetailsByDate(string FromDate, string ToDate)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmdSelect = new SqlCommand();
            cmdSelect.Connection = con;

            DataTable dt = new DataTable();
          
            cmdSelect.CommandType = CommandType.StoredProcedure;
            cmdSelect.CommandText = "GetOrderDetailsByDate";
            cmdSelect.Parameters.AddWithValue("@FromDate", FromDate);
            cmdSelect.Parameters.AddWithValue("@ToDate", ToDate);

            new SqlDataAdapter(cmdSelect).Fill(dt);
            con.Close();

            return dt;
          
        }      
    }
}