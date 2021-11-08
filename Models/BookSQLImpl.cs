using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BookStoreAPI.Models
{
  public class BookSQLImpl
  {
    public string AddBook(Book bookObj)
    {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand comm = new SqlCommand();
                    //insert into Book values(2,'Born a Crime',978389667,'2020', 14.99, 'Author : Trevor Noah ', 0, 5, 1,'~/Images/Comedy/BornACrime.jpg' , 0)
                    comm.Connection = conn;
                    int bookStatus = 0;
                    if (bookObj.BStatus == true)
                    {
                        bookStatus = 1;
                    }
                    DateTime YeartoDate = DateTime.Parse("01/01/" + bookObj.BYear);
                    comm.CommandText = "insert into Book values (" + bookObj.BCatId + " , '" + bookObj.BTitle + "' , '" + bookObj.BISBN + "', '" + YeartoDate + "' , " + bookObj.BPrice + "  , '" + bookObj.BDesc + "' , " + 0 + " , " + bookObj.BCount + " , " + bookStatus + ", '" + bookObj.BImgPath + "', " + 0 + ")";
                    conn.Open();

                    int rows = comm.ExecuteNonQuery();
                }
                return "success";
            }
            catch(Exception ex)
            {
                return ex.Message;
            }          
    }

    public string DeleteBook(int id)
    {
            try
            {
                BookWithCatName book = GetBookById(id);
                int rows = 0;
                string connectionString = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand comm = new SqlCommand();
                    SqlCommand comm1 = new SqlCommand();
                    comm.Connection = conn;
                    comm1.Connection = conn;
                    comm.CommandText = "DELETE FROM Book  WHERE BId= " + id + " ";
                    comm1.CommandText = "exec usp_IDelBk '" + book.BCatId + "' , '" + book.BStatus + "' ";
                    conn.Open();
                    //SqlDataReader dr = comm.ExecuteReader();
                    rows = comm.ExecuteNonQuery();

                    //SqlDataReader dr1 = comm1.ExecuteReader();
                    rows = comm1.ExecuteNonQuery();

                }
                if (rows > 0)
                {
                    return "Book Deleted";
                }
                else
                {
                    return "No Book Deleted";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

    }

    public List<BookWithCatName> GetAllBook()
    {
      List<BookWithCatName> bookList = new List<BookWithCatName>();
      string connectionString = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString; 
                                                                                                
      using (SqlConnection conn = new SqlConnection(connectionString))
      {
        SqlCommand comm = new SqlCommand();
        comm.Connection = conn;
        comm.CommandText = "select * from Book b, Category c where b.BCatId= c.CatId";
        conn.Open();
        SqlDataReader dr = comm.ExecuteReader();
        while (dr.Read())
        {
          BookWithCatName book = new BookWithCatName();

          book.BId = Convert.ToInt32(dr["BId"]);
          book.BCatId = Convert.ToInt32(dr["BCatId"]);
          book.BTitle = dr["BTitle"].ToString();
          book.BISBN = dr["BISBN"].ToString();
          book.BYear = dr["BYear"].ToString();
          book.BPrice = Convert.ToDouble(dr["BPrice"]);
          book.BDesc = dr["BDesc"].ToString();
          book.BPosition = Convert.ToDouble(dr["BPosition"]);
          book.BCount = Convert.ToInt32(dr["BCount"]);
          book.BStatus = Convert.ToBoolean(dr["BStatus"]);
          book.BImgPath = dr["BImgPath"].ToString();
          book.Norders = Convert.ToInt32(dr["Norders"]);
          book.BCatName = dr["CatName"].ToString();

          bookList.Add(book);
        }
      }
      return bookList;
    }

    public BookWithCatName GetBookById(int id)
    {
      BookWithCatName book = new BookWithCatName();
      string connectionString = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString; 
      using (SqlConnection conn = new SqlConnection(connectionString))
      {
        SqlCommand comm = new SqlCommand();
        comm.Connection = conn;
        comm.CommandText = "select * from Book b, Category c where b.BId =" + id + " and  b.BCatId= c.CatId ";
        conn.Open();
        SqlDataReader dr = comm.ExecuteReader();
        while (dr.Read())
        {
          book.BId = Convert.ToInt32(dr["BId"]);
          book.BCatId = Convert.ToInt32(dr["BCatId"]);
          book.BTitle = dr["BTitle"].ToString();
          book.BISBN = dr["BISBN"].ToString();
          book.BYear = dr["BYear"].ToString();
          book.BPrice = Convert.ToDouble(dr["BPrice"]);
          book.BDesc = dr["BDesc"].ToString();
          book.BPosition = Convert.ToDouble(dr["BPosition"]);
          book.BCount = Convert.ToInt32(dr["BCount"]);
          book.BStatus = Convert.ToBoolean(dr["BStatus"]);
          book.BImgPath = dr["BImgPath"].ToString();
          book.Norders = Convert.ToInt32(dr["Norders"]);
          book.BCatName = dr["CatName"].ToString();
        }
      }
      return book;
    }

    public string UpdateBook(int id, Book book)
    {
      try
      {
        string connectionString = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
          SqlCommand comm = new SqlCommand();
          comm.Connection = conn;
          DateTime YeartoDate = DateTime.Parse("01/01/" + book.BYear);
          comm.CommandText = "UPDATE Book SET BCatId=" + book.BCatId + ", BTitle='" + book.BTitle + "',  BISBN='" + book.BISBN + "', BYear = '" + book.BYear + "',BPrice = " + book.BPrice + ",BDesc ='" + book.BDesc + "', BCount='" + book.BCount + "', BStatus='" + book.BStatus + "' , BImgPath = '" + book.BImgPath + "'   WHERE BId=" + id + "  ";
          conn.Open();
          int rows = comm.ExecuteNonQuery();

        }
        return "Success";
      }
      catch(Exception ex)
      {
        return ex.Message;
      }

    }

    /*public bool UpdateBookCount(int id, int extraBookQty)
    {
      BookWithCatName book = GetBookById(id);
      int 
      string connectionString = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString; 
      using (SqlConnection conn = new SqlConnection(connectionString))
      {
        SqlCommand comm = new SqlCommand();
        comm.Connection = conn;

        book.BCount = book.BCount + extraBookQty;
        //comm.CommandText = "UPDATE Book SET BCatId=" + book.BCatId + ", BTitle='" + book.BTitle + "',  BISBN='" + book.BISBN + "', BYear = '" + book.BYear + "',BPrice = " + book.BPrice + ",BDesc ='" + book.BDesc + "',BPosition ='" + book.BPosition + "', BCount='" + book.BCount + "', BStatus='" + book.BStatus + "' , BImgPath = '" + book.BImgPath + "', Norders=" + book.Norders + "    WHERE BId=" + book.BId + "  ";
        comm.CommandText = "update Book Set BCount='" + book.BCount + "'  WHERE BId=" + id + "";
        conn.Open();
        //SqlDataReader dr = comm.ExecuteReader();
        int rows = comm.ExecuteNonQuery();
        
      }
      return book;
    }*/
  }
}
