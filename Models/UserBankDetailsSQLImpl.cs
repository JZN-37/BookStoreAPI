using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BookStoreAPI.Models
{
  public class UserBankDetailsSQLImpl
  {
    public string AddBankDetails(UserBankDetails bankObj)
    {
      try
      {
        string connectionString = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
          SqlCommand comm = new SqlCommand();

          comm.Connection = conn;
          comm.CommandText = "insert into UserBankDetails values (" + bankObj.UserId + ",'" + bankObj.UserCard + "','" + bankObj.CardExpiry + "' )";
          conn.Open();
          int rows = comm.ExecuteNonQuery();

        }
        return "Success";

      }
      catch(Exception ex)
      {
        return ex.Message;
      }

    }

    public List<UserBankDetails> DeleteBankDetails(int uid, int UserBankDetailsId)
    {
      List<UserBankDetails> banklist = GetBankDetailsById(uid);
      string connectionString = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;
      using (SqlConnection conn = new SqlConnection(connectionString))
      {
        SqlCommand comm = new SqlCommand();
        comm.Connection = conn;
        comm.CommandText = "DELETE FROM UserBankDetails  WHERE UserBankDetailsId = " + UserBankDetailsId + " ";
        conn.Open();
        int rows = comm.ExecuteNonQuery();

      }
      return banklist;
    }

    /*public List<UserBankDetails> GetAllBankDetails()
    {
      List<UserBankDetails> bankList = new List<UserBankDetails>();
      string connectionString = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;

      using (SqlConnection conn = new SqlConnection(connectionString))
      {
        SqlCommand comm = new SqlCommand();
        comm.Connection = conn;
        comm.CommandText = "select * from UserAddress";
        conn.Open();
        SqlDataReader dr = comm.ExecuteReader();
        while (dr.Read())
        {
          UserBankDetails bankObj = new UserBankDetails();

          bankObj.UserBankDetailsId = Convert.ToInt32(dr["UserBankDetailsId"]);
          bankObj.UserId = Convert.ToInt32(dr["UserId"]);
          bankObj.UserCard = (dr["UserCard"]).ToString();
          bankObj.CardExpiry = (dr["CardExpiry"]).ToString();

          bankList.Add(bankObj);
        }
      }
      return bankList;
    }*/

    public List<UserBankDetails> GetBankDetailsById(int id)
    {
      List<UserBankDetails> bankList = new List<UserBankDetails>();

      string connectionString = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;
      using (SqlConnection conn = new SqlConnection(connectionString))
      {
        SqlCommand comm = new SqlCommand();
        comm.Connection = conn;
        comm.CommandText = "select * from UserBankDetails where UserId =" + id + " ";
        conn.Open();
        SqlDataReader dr = comm.ExecuteReader();
        while (dr.Read())
        {
          UserBankDetails bankObj = new UserBankDetails();

          bankObj.UserBankDetailsId = Convert.ToInt32(dr["UserBankDetailsId"]);
          bankObj.UserId = Convert.ToInt32(dr["UserId"]);
          bankObj.UserCard = (dr["UserCard"]).ToString();
          bankObj.CardExpiry = (dr["CardExpiry"]).ToString();

          bankList.Add(bankObj);
        }
      }
      return bankList;
    }


    public string UpdateBankDetails(int id, UserBankDetails bankObj)
    {
      try
      {
        string connectionString = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
          SqlCommand comm = new SqlCommand();
          comm.Connection = conn;

          comm.CommandText = "UPDATE UserBankDetails SET UserCard='" + bankObj.UserCard + "',CardExpiry='" + bankObj.CardExpiry + "' where UserBankDetailsId = " + bankObj.UserBankDetailsId + " ";
          conn.Open();
          int rows = comm.ExecuteNonQuery();
        }
        return "Success";
      }
      catch(Exception ex)
      {
        return ex.Message;
      }

    }
  }
}
