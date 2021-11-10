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
        public string AddWish(Wishlist wishObj)
        {
      try
      {
        string connectionString = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
          SqlCommand comm = new SqlCommand();

          comm.Connection = conn;
          comm.CommandText = "insert into Wishlist values (" + wishObj.UserId + "," + wishObj.BId + ")";
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

        public string DeleteWish(int id, int bid)
        {
            try
            {
                List<Completewishlist> wishlist = GetWishById(id);
                string connectionString = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand comm = new SqlCommand();
                    comm.Connection = conn;
                    comm.CommandText = "DELETE FROM Wishlist  WHERE UserId = " + id + " and BId=" + bid + "";
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

        public List<Completewishlist> GetAllWish()
        {
            List<Completewishlist> wishList = new List<Completewishlist>();
            string connectionString = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandText = "select * from Wishlist w,Users u,Book b,Category cat where w.UserId=u.Id and w.BId=b.BId and b.BCatId=cat.CatId and b.BStatus=1";
                conn.Open();
                SqlDataReader dr = comm.ExecuteReader();
                while (dr.Read())
                {
                    Completewishlist wish = new Completewishlist();

                    wish.WId = Convert.ToInt32(dr["WId"]);
                    wish.UserId = Convert.ToInt32(dr["UserId"]);
                    wish.UName = dr["UName"].ToString();
                    wish.BId = Convert.ToInt32(dr["BId"]);
                    wish.BTitle = dr["BTitle"].ToString();
                    wish.BImgPath = dr["BImgPath"].ToString();
                    wish.BPrice = Convert.ToDouble(dr["BPrice"]);
                    wish.BCatId = Convert.ToInt32(dr["BCatId"]);
                    wish.BCount = Convert.ToInt32(dr["BCount"]);
                    wish.CatName = dr["CatName"].ToString();

                    wishList.Add(wish);
                }
            }
            return wishList;
        }

        public List<Completewishlist> GetWishById(int id)
        {
            List<Completewishlist> wishList = new List<Completewishlist>();

            string connectionString = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandText = "select * from Wishlist w,Users u,Book b,Category cat where w.UserId=u.Id and w.BId=b.BId and b.BCatId=cat.CatId and b.BStatus=1 and w.UserId =" + id + " ";
                conn.Open();
                SqlDataReader dr = comm.ExecuteReader();
                while (dr.Read())
                {
                    Completewishlist wish = new Completewishlist();

                    wish.WId = Convert.ToInt32(dr["WId"]);
                    wish.UserId = Convert.ToInt32(dr["UserId"]);
                    wish.UName = dr["UName"].ToString();
                    wish.BId = Convert.ToInt32(dr["BId"]);
                    wish.BTitle = dr["BTitle"].ToString();
                    wish.BImgPath = dr["BImgPath"].ToString();
                    wish.BPrice = Convert.ToDouble(dr["BPrice"]);
                    wish.BCatId = Convert.ToInt32(dr["BCatId"]);
                    wish.BCount = Convert.ToInt32(dr["BCount"]);
                    wish.CatName = dr["CatName"].ToString();

                    wishList.Add(wish);
                }
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
