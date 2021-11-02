using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStoreAPI.Models
{
    public class Wishlist
    {
        public int WId { get; set; }
        public int UserId { get; set; }
        public int BId { get; set; }       
    }
}