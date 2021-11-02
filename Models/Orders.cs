using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStoreAPI.Models
{
  public class OrdersInsert
  {
    public int UserId { get; set; }
    public List<int> BId { get; set; }
    public List<int> BQty { get; set; }
  }

  public class Orders
  {
    public int UserId { get; set; }
    public int OrderId { get; set; }
    public string BookTitle { get; set; }
    public string BookCatName { get; set; }
    public string BookISBN { get; set; }
    public DateTime BookYear { get; set; }
    public double BookPrice { get; set; }
    public string BImagePath { get; set; }
    public int BookQty { get; set; }
    public DateTime OrderDate { get; set; }
  }

}
