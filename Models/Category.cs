using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStoreAPI.Models
{
    public class Category
    {
        public int CatId { get; set; }
        public string CatName { get; set; }
        public string CatDesc { get; set; }
        public string CatImgPath { get; set; }
        public int CatCount { get; set; }
        public bool CatStatus { get; set; }
        public double CatPosition { get; set; }
        public DateTime CatCreatedAt { get; set; }
    }
}