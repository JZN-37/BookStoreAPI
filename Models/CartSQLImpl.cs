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
        public Cart AddCart(Cart cartObj)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand comm = new SqlCommand();
                
                comm.Connection = conn;
                comm.CommandText = "insert into Cart values ("+cartObj.UserId+","+cartObj.BId+","+cartObj.BQty+")";
                conn.Open();
                int rows = comm.ExecuteNonQuery();
                conn.Close();
            }
            return cartObj;
        }

        public List<Cart> DeleteCartRecord(int id, int bid)
        {
            List<Cart> cartlist = GetCartById(id);
            string connectionString = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandText = "DELETE FROM Cart  WHERE UserId = " + id + " and BId="+bid+"";
                conn.Open();
                int rows = comm.ExecuteNonQuery();
                conn.Close();

            }
            return cartlist;
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
                conn.Close();
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
                conn.Close();
            }
            return cartList;
        }


        public Cart UpdateCart(Cart cartObj)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                
                comm.CommandText = "UPDATE Users SET BQty="+ cartObj.BQty+ " WHERE UserId =" + cartObj.UserId + " and BId = " + cartObj.BId + " ";
                conn.Open();
                int rows = comm.ExecuteNonQuery();
                conn.Close();
            }
            return cartObj;
        }
    }
}
