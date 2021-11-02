using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BookStoreAPI.Models
{
    public class UsersSQLImpl
    {
        public Users AddUser(Users usrObj)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand comm = new SqlCommand();
                
                comm.Connection = conn;
                int UStatus = 0;
                if (usrObj.UStatus == true)
                {
                    UStatus = 1;
                }
                comm.CommandText = "insert into Users values ('" + usrObj.UName + "' , '" + usrObj.UPwd + "' , '" + usrObj.UMobile + "', '" + usrObj.UEmail + "' , " + UStatus + "  , " + usrObj.UOrderNo + "  )";
                conn.Open();
                int rows = comm.ExecuteNonQuery();
            }
            return usrObj;
        }

        public Users DeleteUser(int id)
        {
            Users usrObj = GetUsrById(id);
            string connectionString = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandText = "DELETE FROM Users  WHERE Id= " + id + " ";
                conn.Open();
                int rows = comm.ExecuteNonQuery();
            }
            return usrObj;
        }

        public List<Users> GetAllUsers()
        {
            List<Users> usrList = new List<Users>();
            string connectionString = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandText = "select * from Users";
                conn.Open();
                SqlDataReader dr = comm.ExecuteReader();
                while (dr.Read())
                {
                    Users usr = new Users();

                    usr.Id = Convert.ToInt32(dr["Id"]);
                    usr.UName = dr["UName"].ToString();
                    usr.UPwd = dr["UPwd"].ToString();
                    usr.UMobile = dr["UMobile"].ToString();
                    usr.UEmail = dr["UEmail"].ToString();
                    usr.UStatus = Convert.ToBoolean(dr["UStatus"]);
                    usr.UOrderNo = Convert.ToInt32(dr["UOrderNo"]);

                    usrList.Add(usr);
                }
            }
            return usrList;
        }

        public Users GetUsrById(int id)
        {
            Users usr = new Users();
            string connectionString = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandText = "select * from Users where Id =" + id + " ";
                conn.Open();
                SqlDataReader dr = comm.ExecuteReader();
                while (dr.Read())
                {
                    usr.Id = Convert.ToInt32(dr["Id"]);
                    usr.UName = dr["UName"].ToString();
                    usr.UPwd = dr["UPwd"].ToString();
                    usr.UMobile = dr["UMobile"].ToString();
                    usr.UEmail = dr["UEmail"].ToString();
                    usr.UStatus = Convert.ToBoolean(dr["UStatus"]);
                    usr.UOrderNo = Convert.ToInt32(dr["UOrderNo"]);
                }
            }
            return usr;
        }


        public Users UpdateUsr(int id, Users usrObj)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                int UStatus = 0;
                if (usrObj.UStatus == true)
                {
                    UStatus = 1;
                }
                comm.CommandText = "UPDATE Users SET UName='" + usrObj.UName + "', UPwd='" + usrObj.UPwd + "',  UMobile='" + usrObj.UMobile + "', UEmail= '"+ usrObj.UEmail + "' , UStatus = " + UStatus + ", UOrderNo = " + usrObj.UOrderNo + " WHERE Id=" + id + " ";
                conn.Open();
                int rows = comm.ExecuteNonQuery();
            }
            return usrObj;
        }
    }
}