using BookStoreAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BookStoreAPI.Controllers
{
    public class CartController : ApiController
    {
        private CartSQLImpl cartSqlObj;
        public CartController()
        {
            cartSqlObj = new CartSQLImpl();
        }

        [HttpGet]
        public List<Cart> Get()
        {
            return cartSqlObj.GetAllCart();
        }

        [HttpGet]
        public List<Cart> Get(int id)
        {
            return cartSqlObj.GetCartById(id);
        }

        [HttpPost]
        public Cart Post(Cart cartObj)
        {

            return cartSqlObj.AddCart(cartObj);
        }

        [HttpPut]
        public Cart Put(int id,Cart cartObj)
        {
            return cartSqlObj.UpdateCart(id,cartObj);
        }

        [HttpDelete]
        public List<Cart> Delete(int id,int bid)
        {
            return cartSqlObj.DeleteUser(id,bid);
        }
    }
}
