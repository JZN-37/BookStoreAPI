using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BookStoreAPI.Models
{
    public class DiscountSQLImpl
    {
        public string AddDisc(Discount discObj)
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    int DStatus = 0;
                    if (discObj.DStatus == true)
                    {
                        DStatus = 1;
                    }
                    SqlCommand comm = new SqlCommand();

                    comm.Connection = conn;
                    comm.CommandText = "insert into Discount values ('" + discObj.DCouponCode + "'," + discObj.DDiscountValue + "," + DStatus + ")";
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

        public string DeleteDisc(int id)
        {
            try
            {
                Discount wishlist = GetDiscById(id);
                string connectionString = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand comm = new SqlCommand();
                    comm.Connection = conn;
                    comm.CommandText = "DELETE FROM Discount  WHERE DId = " + id + " ";
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

        public List<Discount> GetAllDisc()
        {
            List<Discount> discList = new List<Discount>();
            string connectionString = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandText = "select * from Discount";
                conn.Open();
                SqlDataReader dr = comm.ExecuteReader();
                while (dr.Read())
                {
                    Discount disc = new Discount();

                    disc.DId = Convert.ToInt32(dr["DId"]);
                    disc.DCouponCode = (dr["DCouponCode"]).ToString();
                    disc.DDiscountValue = Convert.ToDouble(dr["DDiscountValue"]);
                    disc.DStatus = Convert.ToBoolean(dr["DStatus"]);

                    discList.Add(disc);
                }
            }
            return discList;
        }

        public Discount GetDiscById(int id)
        {
            Discount disc = new Discount();

            string connectionString = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandText = "select * from Discount where DId =" + id + " ";
                conn.Open();
                SqlDataReader dr = comm.ExecuteReader();
                while (dr.Read())
                {
                    disc.DId = Convert.ToInt32(dr["DId"]);
                    disc.DCouponCode = (dr["DCouponCode"]).ToString();
                    disc.DDiscountValue = Convert.ToDouble(dr["DDiscountValue"]);
                    disc.DStatus = Convert.ToBoolean(dr["DStatus"]);

                }
            }
            return disc;
        }


        public string UpdateDisc(int id, Discount discObj)
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    int DStatus = 0;
                    if (discObj.DStatus == true)
                    {
                        DStatus = 1;
                    }
                    SqlCommand comm = new SqlCommand();
                    comm.Connection = conn;

                    comm.CommandText = "UPDATE Discount SET DCouponCode= '" + discObj.DCouponCode + "', DDiscountValue = " + discObj.DDiscountValue + ", DStatus = " + DStatus + " WHERE DId =" + id + " ";
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