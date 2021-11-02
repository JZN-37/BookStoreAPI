using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BookStoreAPI.Models
{
  public class OrdersSQLImpl
  {
    public List<Orders> AddOrders(OrdersInsert ordnsrtIObj)
    {
      string connectionString = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;
      List<Orders> orderList = new List<Orders>();
      using (SqlConnection conn = new SqlConnection(connectionString))
      {
        SqlCommand comm = new SqlCommand();
        SqlCommand comm1 = new SqlCommand();

        comm.Connection = conn;
        comm1.Connection = conn;


        //First increment the UOrderNo of the current user to get the latest order id for current user
        //To do this we call the stored procedure usp_BeforeInsrtToOrders with current user's userid
        comm.CommandText = "exec usp_BeforeInsrtToOrders " + ordnsrtIObj.UserId + " ";
        conn.Open();
        int rows = comm.ExecuteNonQuery();
        conn.Close();


        //For each item in the BId list we will insert into the Orders table using the stored procedure usp_InsrtOrders  @userId, @bookId, @bookQty
        //After that delete the record from Cart as it has been purchased
        conn.Open();
        for(int c=0; c<ordnsrtIObj.BId.Count; c++)
        {
          comm1.CommandText = "exec usp_InsrtOrders "+ordnsrtIObj.UserId+", "+ordnsrtIObj.BId[c]+", "+ordnsrtIObj.BQty[c]+" ";
          comm1.ExecuteNonQuery();
          CartSQLImpl cartSqlObj = new CartSQLImpl();
          cartSqlObj.DeleteCartRecord(ordnsrtIObj.UserId, ordnsrtIObj.BId[c]);
        }
        conn.Close();


        //Sending the Current order details of user 
        Users usrObj = new Users();
        UsersSQLImpl usersSqlObj = new UsersSQLImpl();
        usrObj = usersSqlObj.GetUsrById(ordnsrtIObj.UserId);

        orderList = GetOrdersById(ordnsrtIObj.UserId, usrObj.UOrderNo);

      }
      return orderList;
    }

    public List<Orders> GetAllOrders()
    {
      List<Orders> orderList = new List<Orders>();
      string connectionString = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;

      using (SqlConnection conn = new SqlConnection(connectionString))
      {
        SqlCommand comm = new SqlCommand();
        comm.Connection = conn;
        comm.CommandText = "select * from Orders ";
        conn.Open();
        SqlDataReader dr = comm.ExecuteReader();
        while (dr.Read())
        {
          Orders ordObj = new Orders();

          ordObj.UserId = Convert.ToInt32(dr["UserId"]);
          ordObj.OrderId = Convert.ToInt32(dr["OrderId"]);
          ordObj.BookTitle = dr["BookTitle"].ToString();
          ordObj.BookCatName = dr["BookCatName"].ToString();
          ordObj.BookISBN = dr["BookISBN"].ToString();
          ordObj.BookYear = Convert.ToDateTime(dr["BookYear"]);
          ordObj.BookPrice = Convert.ToDouble(dr["BookPrice"]);
          ordObj.BImagePath = dr["BImagePath"].ToString();
          ordObj.BookQty = Convert.ToInt32(dr["BookQty"]);
          ordObj.OrderDate = Convert.ToDateTime(dr["OrderDate"]);

          orderList.Add(ordObj);
        }
        conn.Close();
      }

      return orderList;
    }



    //To get all orders by the user
    public List<Orders> GetAllOrdersById(int id)
    {
      //Retrieving Order based on User Id

      List<Orders> orderList = new List<Orders>();
      string connectionString = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;

      using (SqlConnection conn = new SqlConnection(connectionString))
      {
        SqlCommand comm = new SqlCommand();
        comm.Connection = conn;
        comm.CommandText = "select * from Orders where UserId =" + id + " ";
        conn.Open();
        SqlDataReader dr = comm.ExecuteReader();
        while (dr.Read())
        {
          Orders ordObj = new Orders();

          ordObj.UserId = Convert.ToInt32(dr["UserId"]);
          ordObj.OrderId = Convert.ToInt32(dr["OrderId"]);
          ordObj.BookTitle = dr["BookTitle"].ToString();
          ordObj.BookCatName = dr["BookCatName"].ToString();
          ordObj.BookISBN = dr["BookISBN"].ToString();
          ordObj.BookYear = Convert.ToDateTime(dr["BookYear"]);
          ordObj.BookPrice = Convert.ToDouble(dr["BookPrice"]);
          ordObj.BImagePath = dr["BImagePath"].ToString();
          ordObj.BookQty = Convert.ToInt32(dr["BookQty"]);
          ordObj.OrderDate = Convert.ToDateTime(dr["OrderDate"]);

          orderList.Add(ordObj);
        }
        conn.Close();
      }

      return orderList;
    }


    //To get all orders by the user for a given orderId
    public List<Orders> GetOrdersById(int id , int orderId)
    {
      //Retrieving Order based on User Id and Order Id

      List<Orders> orderList = new List<Orders>();
      string connectionString = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;

      using (SqlConnection conn = new SqlConnection(connectionString))
      {
        SqlCommand comm = new SqlCommand();
        comm.Connection = conn;
        comm.CommandText = "select * from Orders where UserId =" + id + " and OrderId="+orderId+" ";
        conn.Open();
        SqlDataReader dr = comm.ExecuteReader();
        while (dr.Read())
        {
          Orders ordObj = new Orders();

          ordObj.UserId = Convert.ToInt32(dr["UserId"]);
          ordObj.OrderId = Convert.ToInt32(dr["OrderId"]);
          ordObj.BookTitle = dr["BookTitle"].ToString();
          ordObj.BookCatName = dr["BookCatName"].ToString();
          ordObj.BookISBN = dr["BookISBN"].ToString();
          ordObj.BookYear = Convert.ToDateTime(dr["BookYear"]);
          ordObj.BookPrice = Convert.ToDouble(dr["BookPrice"]);
          ordObj.BImagePath = dr["BImagePath"].ToString();
          ordObj.BookQty = Convert.ToInt32(dr["BookQty"]);
          ordObj.OrderDate = Convert.ToDateTime(dr["OrderDate"]);

          orderList.Add(ordObj);
        }
        conn.Close();
      }

      return orderList;
    }
  }
}
