using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStoreAPI.Models
{
    public class UserAddress
    {
        public int UserAddrId { get; set; }
        public int UserId { get; set; }
        public string UAddrLine1 { get; set; }
        public string UAddrLine2 { get; set; }
        public string UAddrCity { get; set; }
        public string UAddrCountry { get; set; }
        public string UAddrPincode { get; set; }
    }
}