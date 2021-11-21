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

        [HttpGet]
        public double GetByCode(string couponCode)
        {
          return discSqlObj.GetDiscByCode(couponCode);
        }

    [HttpPost]
        public string Post(Discount discObj)
        {

            return discSqlObj.AddDisc(discObj);
        }

        [HttpPut]
        public string Put(int id, Discount discObj)
        {
            return discSqlObj.UpdateDisc(id, discObj);
        }

        [HttpDelete]
        public string Delete(int id)
        {
            return discSqlObj.DeleteDisc(id);
        }
    }
}
