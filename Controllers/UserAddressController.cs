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
    public class UserAddressController : ApiController
    {
        private UserAddressSQLImpl addrSqlObj;
        public UserAddressController()
        {
            addrSqlObj = new UserAddressSQLImpl();
        }

        [HttpGet]
        public List<UserAddress> Get()
        {
            return addrSqlObj.GetAllAddr();
        }

        [HttpGet]
        public List<UserAddress> Get(int id)
        {
            return addrSqlObj.GetAddrById(id);
        }

        [HttpPost]
        public string Post(UserAddress addrObj)
        {

            return addrSqlObj.AddAddr(addrObj);
        }

        [HttpPut]
        public string Put(int id, UserAddress addrObj)
        {
            return addrSqlObj.UpdateAddr(id, addrObj);
        }

        [HttpDelete]
        public List<UserAddress> Delete(int uid,int addrid)
        {
            return addrSqlObj.DeleteAddr(uid,addrid);
        }
    }
}
