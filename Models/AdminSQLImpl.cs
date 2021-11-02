using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BookStoreAPI.Models
{
  public class AdminSQLImpl
  {
    public bool CheckAdminLogIn(Admin adminObj)
    {
      bool logInStatus = false;
      string password = "";
      string connectionString = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;
      using (SqlConnection conn = new SqlConnection(connectionString))
      {
        SqlCommand comm = new SqlCommand();
        comm.Connection = conn;

        comm.CommandText = "select * from Admin where AName = '"+adminObj.AName+"' ";
        conn.Open();
        SqlDataReader dr = comm.ExecuteReader();
        
        while (dr.Read())
        {
          password = dr["APwd"].ToString();
        }
        

        if(password == adminObj.APwd)
        {
          logInStatus = true;
        }

      }
      return logInStatus;
    }
  }
}
