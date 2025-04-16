using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;


namespace BLL
{
    public class Product
    {
        public int Pid { get; set; }
        public string Pname { get; set; }
        public string Pdesc { get; set; }
        public float Price { get; set; }
        public string Picname { get; set; }
        public int Cid { get; set; }

        public string Status { get; set; }
        public int Quantity { get; set; }

        public static Product GetById(int Pid)
        {
            return ProductDAL.GetById(Pid);
        }

        public static List<Product> GetAll()
        {
            return new List<Product>();
        }

        public int Save()
        {
            return ProductDAL.Save(this);
        }  
        
        public static int DeleteById(int Pid)
        {
            return ProductDAL.DeleteById(Pid);
        }



    }
}