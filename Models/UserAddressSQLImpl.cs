using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BookStoreAPI.Models
{
    public class UserAddressSQLImpl
    {
        public UserAddress AddAddr(UserAddress addrObj)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {              
                SqlCommand comm = new SqlCommand();

                comm.Connection = conn;
                comm.CommandText = "insert into UserAddress values (" + addrObj.UserId + ",'"+addrObj.UAddrLine1 + "','" + addrObj.UAddrLine2 + "','" + addrObj.UAddrCity + "','" + addrObj.UAddrCountry + "','" + addrObj.UAddrPincode + "')";
                conn.Open();
                int rows = comm.ExecuteNonQuery();

            }
            return addrObj;
        }

        //http://localhost:60494/api/UserAddress?uid=2&addrid=3
        public List<UserAddress> DeleteAddr(int uid,int addrid)
        {
            List<UserAddress> addrlist = GetAddrById(uid);
            string connectionString = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandText = "DELETE FROM UserAddress  WHERE UserAddrId = " + addrid + " and UserId="+uid+" ";
                conn.Open();
                int rows = comm.ExecuteNonQuery();

            }
            return addrlist;
        }

        public List<UserAddress> GetAllAddr()
        {
            List<UserAddress> addrList = new List<UserAddress>();
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
                    UserAddress addr = new UserAddress();

                    addr.UserAddrId = Convert.ToInt32(dr["UserAddrId"]);
                    addr.UserId = Convert.ToInt32(dr["UserId"]);
                    addr.UAddrLine1 = (dr["UAddrLine1"]).ToString();
                    addr.UAddrLine2 = (dr["UAddrLine2"]).ToString();
                    addr.UAddrCity = (dr["UAddrCity"]).ToString();
                    addr.UAddrCountry = (dr["UAddrCountry"]).ToString();
                    addr.UAddrPincode = (dr["UAddrPincode"]).ToString();

                    addrList.Add(addr);
                }
            }
            return addrList;
        }

        public List<UserAddress> GetAddrById(int id)
        {
            List<UserAddress> addrList = new List<UserAddress>();

            string connectionString = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandText = "select * from UserAddress where UserId =" + id + " ";
                conn.Open();
                SqlDataReader dr = comm.ExecuteReader();
                while (dr.Read())
                {
                    UserAddress addr = new UserAddress();

                    addr.UserAddrId = Convert.ToInt32(dr["UserAddrId"]);
                    addr.UserId = Convert.ToInt32(dr["UserId"]);
                    addr.UAddrLine1 = (dr["UAddrLine1"]).ToString();
                    addr.UAddrLine2 = (dr["UAddrLine2"]).ToString();
                    addr.UAddrCity = (dr["UAddrCity"]).ToString();
                    addr.UAddrCountry = (dr["UAddrCountry"]).ToString();
                    addr.UAddrPincode = (dr["UAddrPincode"]).ToString();

                    addrList.Add(addr);
                }
            }
            return addrList;
        }


        public UserAddress UpdateAddr(int id, UserAddress addrObj)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;

                comm.CommandText = "UPDATE UserAddress SET UAddrLine1='"+addrObj.UAddrLine1+ "',UAddrLine2='" + addrObj.UAddrLine2 + "',UAddrCity='" + addrObj.UAddrCity + "',UAddrCountry='" + addrObj.UAddrCountry + "' ,UAddrPincode='" + addrObj.UAddrPincode + "'  WHERE UserId =" + id + " and UserAddrId="+ addrObj.UserAddrId+ " ";
                conn.Open();
                int rows = comm.ExecuteNonQuery();
            }
            return addrObj;
        }
    }
}