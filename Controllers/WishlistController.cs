using BookStoreAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace BookStoreAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class WishlistController : ApiController
    {
        private WishlistSQLImpl wishSqlObj;
        public WishlistController()
        {
            wishSqlObj = new WishlistSQLImpl();
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public List<Wishlist> Get()
        {
            return wishSqlObj.GetAllWish();
        }

        [HttpGet]
        [Authorize]
        public List<Wishlist> Get(int id)
        {
            return wishSqlObj.GetWishById(id);
        }

        [HttpPost]
        public string Post(Wishlist wishObj)
        {

            return wishSqlObj.AddWish(wishObj);
        }

        //[HttpPut]
        //public Wishlist Put(int id, Wishlist wishObj)
        //{
        //    return wishSqlObj.UpdateWish(id, wishObj);
        //}

        [HttpDelete]
        public List<Wishlist> Delete(int id, int bid)
        {
            return wishSqlObj.DeleteWish(id, bid);
        }
    }
}
