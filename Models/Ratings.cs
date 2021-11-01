using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStoreAPI.Models
{
    public class Ratings
    {
    public int UserId { get; set; }
    public int BId { get; set; }
    public double UserRating { get; set; }
  }
}
