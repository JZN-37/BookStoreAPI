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
    public class UserBankDetailsController : ApiController
  {
    private UserBankDetailsSQLImpl bankSqlObj;
    public UserBankDetailsController()
    {
      bankSqlObj = new UserBankDetailsSQLImpl();
    }

    /*[HttpGet]
    public List<UserAddress> Get()
    {
      return bankSqlObj.GetAllAddr();
    }*/

    [HttpGet]
    public List<UserBankDetails> Get(int id)
    {
      return bankSqlObj.GetBankDetailsById(id);
    }

    [HttpPost]
    public string Post(UserBankDetails bankrObj)
    {

      return bankSqlObj.AddBankDetails(bankrObj);
    }

    [HttpPut]
    public string Put(int id, UserBankDetails bankrObj)
    {
      return bankSqlObj.UpdateBankDetails(id, bankrObj);
    }

    [HttpDelete]
    public List<UserBankDetails> Delete(int uid, int bankid)
    {
      //http://localhost:60494/api/UserBankDetails?uid=2&bankid=3 OR CHANGE uid to id
      return bankSqlObj.DeleteBankDetails(uid, bankid);
    }
  }
} 
