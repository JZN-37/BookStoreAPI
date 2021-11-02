using BookStoreAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BookStoreAPI.Controllers
{
    public class DiscountController : ApiController
    {
        private DiscountSQLImpl discSqlObj;
        public DiscountController()
        {
            discSqlObj = new DiscountSQLImpl();
        }

        [HttpGet]
        public List<Discount> Get()
        {
            return discSqlObj.GetAllDisc();
        }

        [HttpGet]
        public Discount Get(int id)
        {
            return discSqlObj.GetDiscById(id);
        }

        [HttpPost]
        public Discount Post(Discount discObj)
        {

            return discSqlObj.AddDisc(discObj);
        }

        [HttpPut]
        public Discount Put(int id, Discount discObj)
        {
            return discSqlObj.UpdateDisc(id, discObj);
        }

        [HttpDelete]
        public Discount Delete(int id)
        {
            return discSqlObj.DeleteDisc(id);
        }
    }
}
