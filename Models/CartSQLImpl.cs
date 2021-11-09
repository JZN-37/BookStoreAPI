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

        public string DeleteCartRecord(int id, int bid) 
        {
            try
            {
                List<CompleteCart> cartlist = GetCartById(id);
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

        public List<CompleteCart> GetAllCart()
        {
            List<CompleteCart> cartList = new List<CompleteCart>();
            string connectionString = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandText = "select c.CartId,c.UserId,u.UName,c.BId,b.BTitle,b.BImgPath,b.BPrice,b.BCatId,cat.CatName,c.BQty from Cart c,Users u,Book b,Category cat where c.UserId=u.Id and c.BId=b.BId and b.BCatId=cat.CatId";
                conn.Open();
                SqlDataReader dr = comm.ExecuteReader();
                while (dr.Read())
                {
                    CompleteCart cart = new CompleteCart();

                    cart.CartId = Convert.ToInt32(dr["CartId"]);
                    cart.UserId = Convert.ToInt32(dr["UserId"]);
                    cart.UName = dr["UName"].ToString();
                    cart.BId = Convert.ToInt32(dr["BId"]);
                    cart.BTitle = dr["BTitle"].ToString();
                    cart.BImgPath = dr["BImgPath"].ToString();
                    cart.BPrice = Convert.ToDouble(dr["BPrice"]);
                    cart.BCatId = Convert.ToInt32(dr["BCatId"]);
                    cart.CatName = dr["CatName"].ToString();
                    cart.BQty = Convert.ToInt32(dr["BQty"]);

                    cartList.Add(cart);
                }
                
            }
            return cartList;
        }

        public List<CompleteCart> GetCartById(int id)
        {
            List<CompleteCart> cartList = new List<CompleteCart>();
            
            string connectionString = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandText = "select c.CartId,c.UserId,u.UName,c.BId,b.BTitle,b.BImgPath,b.BPrice,b.BCatId,cat.CatName,c.BQty from Cart c,Users u,Book b,Category cat where c.UserId=u.Id and c.BId=b.BId and b.BCatId=cat.CatId and c.UserId =" + id + " ";
                conn.Open();
                SqlDataReader dr = comm.ExecuteReader();
                while (dr.Read())
                {
                    CompleteCart cart = new CompleteCart();

                    cart.CartId = Convert.ToInt32(dr["CartId"]);
                    cart.UserId = Convert.ToInt32(dr["UserId"]);
                    cart.UName = dr["UName"].ToString();
                    cart.BId = Convert.ToInt32(dr["BId"]);
                    cart.BTitle = dr["BTitle"].ToString();
                    cart.BImgPath = dr["BImgPath"].ToString();
                    cart.BPrice = Convert.ToDouble(dr["BPrice"]);
                    cart.BCatId = Convert.ToInt32(dr["BCatId"]);
                    cart.CatName = dr["CatName"].ToString();
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

                    comm.CommandText = "UPDATE Cart SET BQty=" + cartObj.BQty + " WHERE CartId =" + id + " ";
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
