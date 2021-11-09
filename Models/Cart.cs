using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStoreAPI.Models
{
    public class Cart
    {
        public int CartId { get; set; }
        public int UserId { get; set; }
        public int BId { get; set; }
        public int BQty { get; set; }
    }

    public class CompleteCart
    {
        public int CartId { get; set; }
        public int UserId { get; set; }
        public string UName { get; set; }
        public int BId { get; set; }
        public string BTitle { get; set; }
        public string BImgPath { get; set; }
        public double BPrice { get; set; }
        public int BCatId { get; set; }
        public string CatName { get; set; }
        public int BQty { get; set; }
    }
}