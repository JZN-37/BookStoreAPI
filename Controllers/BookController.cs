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
    public class BookController : ApiController
  {
    private BookSQLImpl bookSqlObj = new BookSQLImpl();
    BookController()
    {
      BookSQLImpl bookSqlObj = new BookSQLImpl();
    }
    [HttpGet]
    public List<BookWithCatName> Get()
    {
      return bookSqlObj.GetAllBook();
    }

    [HttpGet]
    public BookWithCatName Get(int id)
    {
      return bookSqlObj.GetBookById(id);
    }

    [HttpPost]
    public Book Post(Book book)
    {

      return bookSqlObj.AddBook(book);
    }

    [HttpPut]
    public string Put(int id, Book book)
    {
      return bookSqlObj.UpdateBook(id, book);
    }

    /*[HttpPut]   
    //https://localhost:44318/api/Book/9?extraBookQty=5    
    public Book Put(int id, int extraBookQty)
    {
      //For admin to increment the total available books
      return bookSqlObj.UpdateBookCount(id, extraBookQty);
    }*/


    [HttpDelete]
    public bool Delete(int id)
    {
      return bookSqlObj.DeleteBook(id);
    }


  }
}
