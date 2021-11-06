using BookStoreAPI.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BookStoreAPI.Controllers
{
    public class AccountController : ApiController
    {
        [Route("api/User/Register")]
        [HttpPost]
        public IdentityResult Register(AccountModel model)
        {
            UsersSQLImpl usersSqlObj=new UsersSQLImpl();
       
            var userStore = new UserStore<ApplicationUser>(new ApplicationDbContext());
            var manager = new UserManager<ApplicationUser>(userStore);
            var user = new ApplicationUser() { UserName=model.UName, Email=model.UEmail, PhoneNumber=model.UMobile};
            user.UStatus = true;
            Users newuser = new Users();
            newuser.UName = model.UName;
            newuser.UEmail = model.UEmail;
            newuser.UMobile = model.UMobile;
            newuser.UPwd = "Encrypted";
            newuser.UStatus = true;

            IdentityResult result = manager.Create(user, model.UPwd);
            
            if (result.Succeeded == true)
            {
                manager.AddToRoles(user.Id, model.Roles);
                string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand comm = new SqlCommand();
                    comm.Connection = conn;
                    comm.CommandText = "select [UserID] from [User] where UserName = '"+model.UName+"'";
                    conn.Open();
                    SqlDataReader dr = comm.ExecuteReader();
                    while (dr.Read())
                    {
                        newuser.Id = Convert.ToInt32(dr["UserID"]);
                    }
                }

                usersSqlObj.AddUser(newuser);
            }
            return result;
        }
    }

}
