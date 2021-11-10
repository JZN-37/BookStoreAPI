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

    public class Completewishlist
    {
        public int WId { get; set; }
        public int UserId { get; set; }
        public string UName { get; set; }
        public int BId { get; set; }
        public string BTitle { get; set; }
        public string BImgPath { get; set; }
        public double BPrice { get; set; }
        public int BCatId { get; set; }
        public int BCount { get; set; }
        public string CatName { get; set; }
    }
}