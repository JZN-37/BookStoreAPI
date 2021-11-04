using BookStoreAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace BookStoreAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class OrdersController : ApiController
  {
    private OrdersSQLImpl orderSqlObj;
    public OrdersController()
    {
      orderSqlObj = new OrdersSQLImpl();
    }

    [HttpGet]
    public List<Orders> Get()
    {
      return orderSqlObj.GetAllOrders();
    }

    [HttpGet]
    public List<Orders> Get(int id)
    {
      //Get all orders of a user
      return orderSqlObj.GetAllOrdersById(id);
    }

    [HttpGet]
    public List<Orders> Get(int id , int orderId)
    {
      //Get all orders of a user given a orderId
      return orderSqlObj.GetOrdersById(id , orderId);
    }

    [HttpPost]
    public List<Orders> Post(OrdersInsert ordnsrtIObj)
    {
      return orderSqlObj.AddOrders(ordnsrtIObj);
    }

    /*[HttpPut]
    public Ratings Put(int id, Ratings ratObj)
    {
      return ratSqlObj.UpdateRatings(id, ratObj);
    }*/

    /*[HttpDelete]
    public Category Delete(int id)
    {
      return catSqlObj.DeleteCategory(id);
    }*/

  }
}
