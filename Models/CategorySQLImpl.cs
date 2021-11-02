using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BookStoreAPI.Models
{
    public class CategorySQLImpl
    {
        public Category AddCategory(Category catObj)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString; 
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand comm = new SqlCommand();
                //insert into Category values('Comedy', 'Comedy Description' , '~/Image/Comedy/ComedyCat.jpg' , 0, 1, 0, '01/02/2021')
                comm.Connection = conn;
                int catStatus = 0;
                if (catObj.CatStatus == true)
                {
                    catStatus = 1;
                }
                comm.CommandText = "insert into Category values ('" + catObj.CatName + "' , '" + catObj.CatDesc + "' , '" + catObj.CatImgPath + "', " + catObj.CatCount + " , " + catStatus + "  , " + catObj.CatPosition + " , '" + DateTime.Now + "' )";
                conn.Open();
                SqlDataReader dr = comm.ExecuteReader();
            }
            return catObj;
        }

        public Category DeleteCategory(int id)
        {
            Category catObj = GetCatById(id);
            string connectionString = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString; 
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandText = "DELETE FROM Category  WHERE id= " + id + " ";
                conn.Open();
                SqlDataReader dr = comm.ExecuteReader();


            }
            return catObj;
        }

        public List<Category> GetAllCategory()
        {
            List<Category> catList = new List<Category>();
            string connectionString = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString; 
                                                                                                       
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandText = "select * from Category";
                conn.Open();
                SqlDataReader dr = comm.ExecuteReader();
                while (dr.Read())
                {
                    Category cat = new Category();

                    cat.CatId = Convert.ToInt32(dr["CatId"]);
                    cat.CatName = dr["CatName"].ToString();
                    cat.CatDesc = dr["CatDesc"].ToString();
                    cat.CatImgPath = dr["CatImgPath"].ToString();
                    cat.CatCount = Convert.ToInt32(dr["CatCount"]);
                    cat.CatStatus = Convert.ToBoolean(dr["CatStatus"]);
                    cat.CatPosition = Convert.ToDouble(dr["CatPosition"]);
                    cat.CatCreatedAt = Convert.ToDateTime(dr["CatCreatedAt"]);
                    catList.Add(cat);
                }
            }
            return catList;
        }

        public Category GetCatById(int id)
        {
            Category cat = new Category();
            string connectionString = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandText = "select * from Category where CatId =" + id + " ";
                conn.Open();
                SqlDataReader dr = comm.ExecuteReader();
                while (dr.Read())
                {
                    cat.CatId = Convert.ToInt32(dr["CatId"]);
                    cat.CatName = dr["CatName"].ToString();
                    cat.CatDesc = dr["CatDesc"].ToString();
                    cat.CatImgPath = dr["CatImgPath"].ToString();
                    cat.CatCount = Convert.ToInt32(dr["CatCount"]);
                    cat.CatStatus = Convert.ToBoolean(dr["CatStatus"]);
                    cat.CatPosition = Convert.ToDouble(dr["CatPosition"]);
                    cat.CatCreatedAt = Convert.ToDateTime(dr["CatCreatedAt"]);
                }
            }
            return cat;
        }


        public Category UpdateCat(int id, Category catObj)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString; 
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                int catStatus = 0;
                if (catObj.CatStatus == true)
                {
                    catStatus = 1;
                }
                comm.CommandText = "UPDATE Category SET CatName='" + catObj.CatName + "', CatDesc='" + catObj.CatDesc + "',  CatImgPath='" + catObj.CatImgPath + "', CatStatus = " + catStatus + " WHERE CatId=" + id + " ";
                conn.Open();
                SqlDataReader dr = comm.ExecuteReader();
            }
            return catObj;
        }
    }
}
