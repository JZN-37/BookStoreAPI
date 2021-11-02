using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStoreAPI.Models
{
  public class UserBankDetails
  {
    public int UserBankDetailsId { get; set; }
    public int UserId { get; set; }
    public string UserCard { get; set; }
    public string CardExpiry { get; set; }
  }
}
