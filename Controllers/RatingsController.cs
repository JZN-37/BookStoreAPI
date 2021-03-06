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
    public string Post(Ratings ratObj)
    {

      return ratSqlObj.AddRatings(ratObj);
    }

    [HttpPut]
    public string Put(int id, Ratings ratObj)
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
