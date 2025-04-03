using BLL;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BLL
{
    public class Categories
    {
        public int Cid { get; set; }
        public string Cname { get; set; }


        public static Categories GetById(int Cid)
        {
            return CategoriesDAL.GetById(Cid);
        }

        public static List<Categories> GetAll()
        {
            return new List<Categories>();
        }

        public int Save()
        {
            return 0;
        }

        public static int DeleteById(int Cid)
        {
            return CategoriesDAL.DeleteById(Cid); 
        }














    }


    
}