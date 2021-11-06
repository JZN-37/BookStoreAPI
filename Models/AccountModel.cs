using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStoreAPI.Models
{
    public class PasswordChange
    {
      public string UName { get; set; }
      public string OldPass { get; set; }
      public string NewPass { get; set; }

    }

    public class AccountModel
    {
        public string UName { get; set; }
        public string UPwd { get; set; }
        public string UMobile { get; set; }
        public string UEmail { get; set; }
        public string[] Roles { get; set; }

  }
}
