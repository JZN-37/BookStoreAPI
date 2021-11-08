using BookStoreAPI.Controllers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Transactions;
using System.Web;

namespace BookStoreAPI.Models
{
    public class UsersSQLImpl
    {
        //Called from AccountController
        public string AddUser(Users usrObj)
        {
            try
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
                comm.CommandText = "insert into Users values (" + usrObj.Id + ",'" + usrObj.UName + "' , '" + usrObj.UPwd + "' , '" + usrObj.UMobile + "', '" + usrObj.UEmail + "' , " + UStatus + "  , " + 0 + "  )";
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

        //public Users DeleteUser(int id)
        //{
        //    Users usrObj = GetUsrById(id);
        //    string connectionString = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;
        //    using (SqlConnection conn = new SqlConnection(connectionString))
        //    {
        //        SqlCommand comm = new SqlCommand();
        //        comm.Connection = conn;
        //        comm.CommandText = "DELETE FROM Users  WHERE Id= " + id + " ";
        //        conn.Open();
        //        int rows = comm.ExecuteNonQuery();
        //    }
        //    return usrObj;
        //}

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

        public int GetUIdByUName(string userName)
        {
          int userId = 0;
          string connectionString = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;
          using (SqlConnection conn = new SqlConnection(connectionString))
          {
            SqlCommand comm = new SqlCommand();
            comm.Connection = conn;
            comm.CommandText = "select * from Users where UName ='" + userName + "' ";
            conn.Open();
            SqlDataReader dr = comm.ExecuteReader();
            while (dr.Read())
            {
              userId = Convert.ToInt32(dr["Id"]);
            }
          }
          return userId;
        }

        public string UpdateUsr(int id, Users usrObj)
        {
          try
          {
            //Update Code First
            string connectionString1 = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection conn1 = new SqlConnection(connectionString1))
            {
              SqlCommand comm1 = new SqlCommand();
              comm1.Connection = conn1;
              int UStatus = 0;
              if (usrObj.UStatus == true)
              {
                UStatus = 1;
              }
              comm1.CommandText = "UPDATE [User] SET PhoneNumber='" + usrObj.UMobile + "', Email= '" + usrObj.UEmail + "' , UStatus = " + UStatus + " WHERE UserID=" + id + " ";
              conn1.Open();
              int rows = comm1.ExecuteNonQuery();
            }

            //Update Code First
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
              comm.CommandText = "UPDATE Users SET UMobile='" + usrObj.UMobile + "', UEmail= '" + usrObj.UEmail + "' , UStatus = " + UStatus + " WHERE Id=" + id + " ";
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

  }
}
