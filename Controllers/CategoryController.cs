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
    public class CategoryController : ApiController
    {
        private CategorySQLImpl catSqlObj;
        public CategoryController()
        {
            catSqlObj = new CategorySQLImpl();
        }

        [HttpGet]
        public List<Category> Get()
        {
            return catSqlObj.GetAllCategory();
        }

        [HttpGet]
        public Category Get(int id)
        {
            return catSqlObj.GetCatById(id);
        }

        [HttpPost]
        public Category Post(Category catObj)
        {

            return catSqlObj.AddCategory(catObj);
        }

        [HttpPut]
        public Category Put(int id, Category catObj)
        {
            return catSqlObj.UpdateCat(id, catObj);
        }

        [HttpDelete]
        public Category Delete(int id)
        {
            return catSqlObj.DeleteCategory(id);
        }

    }
}

