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
    public class CartController : ApiController
    {
        private CartSQLImpl cartSqlObj;
        public CartController()
        {
            cartSqlObj = new CartSQLImpl();
        }

        [HttpGet]
        public List<CompleteCart> Get()
        {
            return cartSqlObj.GetAllCart();
        }

        [HttpGet]
        public List<CompleteCart> Get(int id)
        {
            return cartSqlObj.GetCartById(id);
        }

        [HttpPost]
        public string Post(Cart cartObj)
        {

            return cartSqlObj.AddCart(cartObj);
        }

        [HttpPut]
        public string Put(int id,Cart cartObj)
        {
            return cartSqlObj.UpdateCart(id,cartObj);
        }

        [HttpDelete]
        //http://localhost:60494/api/Cart/1?bid=2
        public string Delete(int id,int bid)
        {
            return cartSqlObj.DeleteCartRecord(id,bid);
        }
    }
}
