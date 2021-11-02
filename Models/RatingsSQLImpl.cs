using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BookStoreAPI.Models
{
  public class RatingsSQLImpl
  {
    public Ratings AddRatings(Ratings ratObj)
    {
      string connectionString = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;
      using (SqlConnection conn = new SqlConnection(connectionString))
      {
        SqlCommand comm = new SqlCommand();
        comm.Connection = conn;
        //insert into Ratings values(1 , 1, 4)
        comm.CommandText = "insert into Ratings values (" + ratObj.UserId + " , " + ratObj.BId + "  , " + ratObj.UserRating + " )";
        conn.Open();
        //SqlDataReader dr = comm.ExecuteReader();
        int rows = comm.ExecuteNonQuery();
      }
      return ratObj;
    }

    /*public Category DeleteCategory(int id)
    {
      Category catObj = GetCatById(id);
      string connectionString = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;
      using (SqlConnection conn = new SqlConnection(connectionString))
      {
        SqlCommand comm = new SqlCommand();
        comm.Connection = conn;
        comm.CommandText = "DELETE FROM Category  WHERE id= " + id + " ";
        conn.Open();
        SqlDataReader dr = comm.ExecuteReader();


      }
      return catObj;
    }*/

    public List<Ratings> GetAllRatings()
    {
      List<Ratings> ratList = new List<Ratings>();
      string connectionString = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;

      using (SqlConnection conn = new SqlConnection(connectionString))
      {
        SqlCommand comm = new SqlCommand();
        comm.Connection = conn;
        comm.CommandText = "select * from Ratings";
        conn.Open();
        SqlDataReader dr = comm.ExecuteReader();
        while (dr.Read())
        {
          Ratings ratObj = new Ratings();

          ratObj.UserId = Convert.ToInt32(dr["UserId"]);
          ratObj.BId = Convert.ToInt32(dr["BId"]);
          ratObj.UserRating = Convert.ToDouble(dr["UserRating"]);
          ratList.Add(ratObj);
        }
      }
      return ratList;
    }

    public List<Ratings> GetRatingsById(int id)
    {
      /*Ratings ratObj = new Ratings();
      string connectionString = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;
      using (SqlConnection conn = new SqlConnection(connectionString))
      {
        SqlCommand comm = new SqlCommand();
        comm.Connection = conn;
        comm.CommandText = "select * from Ratings where UserId =" + id + " ";
        conn.Open();
        SqlDataReader dr = comm.ExecuteReader();
        while (dr.Read())
        {
          ratObj.UserId = Convert.ToInt32(dr["UserId"]);
          ratObj.BId = Convert.ToInt32(dr["BId"]);
          ratObj.UserRating = Convert.ToDouble(dr["UserRating"]);
        }
      }
      return ratObj;*/
      List<Ratings> ratList = new List<Ratings>();
      string connectionString = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;

      using (SqlConnection conn = new SqlConnection(connectionString))
      {
        SqlCommand comm = new SqlCommand();
        comm.Connection = conn;
        comm.CommandText = "select * from Ratings where UserId =" + id + " ";
        conn.Open();
        SqlDataReader dr = comm.ExecuteReader();
        while (dr.Read())
        {
          Ratings ratObj = new Ratings();

          ratObj.UserId = Convert.ToInt32(dr["UserId"]);
          ratObj.BId = Convert.ToInt32(dr["BId"]);
          ratObj.UserRating = Convert.ToDouble(dr["UserRating"]);
          ratList.Add(ratObj);
        }
      }
      
      return ratList;
    }


    public Ratings UpdateRatings(int id, Ratings ratObj)
    {
      string connectionString = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;
      using (SqlConnection conn = new SqlConnection(connectionString))
      {
        SqlCommand comm = new SqlCommand();
        comm.Connection = conn;

        comm.CommandText = "UPDATE Ratings SET UserRating='" + ratObj.UserRating + "'  WHERE UserId=" + id + "  and BId = "+ratObj.BId+" ";
        conn.Open();
        //SqlDataReader dr = comm.ExecuteReader();
        int rows = comm.ExecuteNonQuery();
      }
      return ratObj;
    }
  }
}
