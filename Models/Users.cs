using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStoreAPI.Models
{
      public class UsersLogIn
    {
      public string UName { get; set; }
      public string UPwd { get; set; }
    }
    public class Users
    {
      public int Id { get; set; }
      public string UName { get; set; }
      public string UPwd { get; set; }
      public string UMobile { get; set; }
      public string UEmail { get; set; }
      public bool UStatus { get; set; }
      public int UOrderNo { get; set; }
    }
}
