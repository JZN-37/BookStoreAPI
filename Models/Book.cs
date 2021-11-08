using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStoreAPI.Models
{
  public class Book
  {
    public int BId { get; set; }
    public int BCatId { get; set; }
    public string BTitle { get; set; }
    public string BISBN { get; set; }
    public string BYear { get; set; }    
    public double BPrice { get; set; }
    public string BDesc { get; set; }
    public double BPosition { get; set; }
    public int BCount { get; set; }
    public bool BStatus { get; set; }
    public string BImgPath { get; set; }
    public int Norders { get; set; }
  }

  public class BookWithCatName
  {
    public int BId { get; set; }
    public int BCatId { get; set; }
    public string BTitle { get; set; }
    public string BISBN { get; set; }
    public string BYear { get; set; }
    public double BPrice { get; set; }
    public string BDesc { get; set; }
    public double BPosition { get; set; }
    public int BCount { get; set; }
    public bool BStatus { get; set; }
    public string BImgPath { get; set; }
    public int Norders { get; set; }
    public string BCatName { get; set; }
  }

    public class BookWithIdImgPath
    {
        public int BId { get; set; }
        public string BImgPath { get; set; }
    }


}
