using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStoreAPI.Models
{
    public class Discount
    {
        public int DId { get; set; }
        public string DCouponCode { get; set; }
        public double DDiscountValue { get; set; }
        public bool DStatus { get; set; }
    }
}