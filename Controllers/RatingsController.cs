using BookStoreAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace BookStoreAPI.Controllers
{
  public class RatingsController : ApiController
  {
    private RatingsSQLImpl ratSqlObj;
    public RatingsController()
    {
      ratSqlObj = new RatingsSQLImpl();
    }

    [HttpGet]
    public List<Ratings> Get()
    {
      return ratSqlObj.GetAllRatings();
    }

    [HttpGet]
    public List<Ratings> Get(int id)
    {
      return ratSqlObj.GetRatingsById(id);
    }

    [HttpPost]
    public Ratings Post(Ratings ratObj)
    {

      return ratSqlObj.AddRatings(ratObj);
    }

    [HttpPut]
    public Ratings Put(int id, Ratings ratObj)
    {
      return ratSqlObj.UpdateRatings(id, ratObj);
    }

    /*[HttpDelete]
    public Category Delete(int id)
    {
      return catSqlObj.DeleteCategory(id);
    }*/

  }
}
