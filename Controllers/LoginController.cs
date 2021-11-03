using BookStoreAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BookStoreAPI.Controllers
{
    public class LoginController : ApiController
    {
      private UsersSQLImpl usersSqlObj;
      public LoginController()
      {
        usersSqlObj = new UsersSQLImpl();
      }

      [HttpPost]
      public bool Post(UsersLogIn usrObj)
      {

        return usersSqlObj.CheckUserLogIn(usrObj);
      }



  }
}
