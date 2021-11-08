using BookStoreAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace BookStoreAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UsersController : ApiController
    {
        private UsersSQLImpl usersSqlObj;
        public UsersController()
        {
            usersSqlObj = new UsersSQLImpl();
        }
        
        [HttpGet]
        public List<Users> Get()
        {
            return usersSqlObj.GetAllUsers();
        }

        [HttpGet]
        public Users Get(int id)
        {
            return usersSqlObj.GetUsrById(id);
        }

        [HttpGet]
        //http://localhost:60494/api/Users?userName=Martha
        public int Get(string userName)
        {
          return usersSqlObj.GetUIdByUName(userName);
        }

        ////Called Only From AccountController
        //[HttpPost]
        //public Users Post(Users usrObj)
        //{

        //    return usersSqlObj.AddUser(usrObj);
        //}

        [HttpPut]
        public string Put(int id, Users usrObj)
        {
            return usersSqlObj.UpdateUsr(id, usrObj);
        }

        //[HttpDelete]
        //public Users Delete(int id)
        //{
        //    return usersSqlObj.DeleteUser(id);
        //}
    }
}
