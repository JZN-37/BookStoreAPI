using BookStoreAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace BookStoreAPI.Controllers
{
  public class AdminController : ApiController
  {
    private AdminSQLImpl adminSqlObj;
    public AdminController()
    {
      adminSqlObj = new AdminSQLImpl();
    }

    [HttpPost]
    public bool Post(Admin adminObj)
    {
      return adminSqlObj.CheckAdminLogIn(adminObj);
    }
  }
}
