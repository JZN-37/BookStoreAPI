using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BookStoreAPI.Models
{
    public class WishlistSQLImpl
    {
        public Wishlist AddWish(Wishlist wishObj)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand comm = new SqlCommand();

                comm.Connection = conn;
                comm.CommandText = "insert into Wishlist values (" + wishObj.UserId + "," + wishObj.BId + ")";
                conn.Open();
                int rows = comm.ExecuteNonQuery();
                conn.Close();
            }
            return wishObj;
        }

        public List<Wishlist> DeleteWish(int id, int bid)
        {
            List<Wishlist> wishlist = GetWishById(id);
            string connectionString = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandText = "DELETE FROM Wishlist  WHERE UserId = " + id + " and BId=" + bid + "";
                conn.Open();
                int rows = comm.ExecuteNonQuery();
                conn.Close();

            }
            return wishlist;
        }

        public List<Wishlist> GetAllWish()
        {
            List<Wishlist> wishList = new List<Wishlist>();
            string connectionString = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandText = "select * from Wishlist";
                conn.Open();
                SqlDataReader dr = comm.ExecuteReader();
                while (dr.Read())
                {
                    Wishlist wish = new Wishlist();

                    wish.WId = Convert.ToInt32(dr["WId"]);
                    wish.UserId = Convert.ToInt32(dr["UserId"]);
                    wish.BId = Convert.ToInt32(dr["BId"]);

                    wishList.Add(wish);
                }
                conn.Close();
            }
            return wishList;
        }

        public List<Wishlist> GetWishById(int id)
        {
            List<Wishlist> wishList = new List<Wishlist>();

            string connectionString = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandText = "select * from Wishlist where UserId =" + id + " ";
                conn.Open();
                SqlDataReader dr = comm.ExecuteReader();
                while (dr.Read())
                {
                    Wishlist wish = new Wishlist();

                    wish.WId = Convert.ToInt32(dr["WId"]);
                    wish.UserId = Convert.ToInt32(dr["UserId"]);
                    wish.BId = Convert.ToInt32(dr["BId"]);

                    wishList.Add(wish);
                }
                conn.Close();
            }
            return wishList;
        }


        //public Wishlist UpdateWish(int id, Wishlist wishObj)
        //{
        //    string connectionString = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;
        //    using (SqlConnection conn = new SqlConnection(connectionString))
        //    {
        //        SqlCommand comm = new SqlCommand();
        //        comm.Connection = conn;

        //        comm.CommandText = "UPDATE Wishlist SET BQty=" + cartObj.BQty + " WHERE UserId =" + id + " and BId = " + cartObj.BId + " ";
        //        conn.Open();
        //        int rows = comm.ExecuteNonQuery();
        //        conn.Close();
        //    }
        //    return wishObj;
        //}
    }
}