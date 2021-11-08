using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BookStoreAPI.Models
{
    public class CartSQLImpl
    {
        public string AddCart(Cart cartObj)
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand comm = new SqlCommand();

                    comm.Connection = conn;
                    comm.CommandText = "insert into Cart values (" + cartObj.UserId + "," + cartObj.BId + "," + cartObj.BQty + ")";
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

        //http://localhost:60494/api/Cart/1?bid=2
        public string DeleteCartRecord(int id, int bid) 
        {
            try
            {
                List<Cart> cartlist = GetCartById(id);
                string connectionString = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand comm = new SqlCommand();
                    comm.Connection = conn;
                    comm.CommandText = "DELETE FROM Cart  WHERE UserId = " + id + " and BId=" + bid + "";
                    conn.Open();
                    int rows = comm.ExecuteNonQuery();

                }
                return "Success";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public List<Cart> GetAllCart()
        {
            List<Cart> cartList = new List<Cart>();
            string connectionString = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandText = "select * from Cart";
                conn.Open();
                SqlDataReader dr = comm.ExecuteReader();
                while (dr.Read())
                {
                    Cart cart = new Cart();

                    cart.CartId = Convert.ToInt32(dr["CartId"]);
                    cart.UserId = Convert.ToInt32(dr["UserId"]);
                    cart.BId = Convert.ToInt32(dr["BId"]);
                    cart.BQty = Convert.ToInt32(dr["BQty"]);

                    cartList.Add(cart);
                }
                
            }
            return cartList;
        }

        public List<Cart> GetCartById(int id)
        {
            List<Cart> cartList = new List<Cart>();
            
            string connectionString = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandText = "select * from Cart where UserId =" + id + " ";
                conn.Open();
                SqlDataReader dr = comm.ExecuteReader();
                while (dr.Read())
                {
                    Cart cart = new Cart();

                    cart.CartId = Convert.ToInt32(dr["CartId"]);
                    cart.UserId = Convert.ToInt32(dr["UserId"]);
                    cart.BId = Convert.ToInt32(dr["BId"]);
                    cart.BQty = Convert.ToInt32(dr["BQty"]);

                    cartList.Add(cart);
                }
                
            }
            return cartList;
        }


        public string UpdateCart(int id,Cart cartObj)
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand comm = new SqlCommand();
                    comm.Connection = conn;

                    comm.CommandText = "UPDATE Cart SET BQty=" + cartObj.BQty + " WHERE UserId =" + id + " and BId = " + cartObj.BId + " ";
                    conn.Open();
                    int rows = comm.ExecuteNonQuery();

                }
                return "Success";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
