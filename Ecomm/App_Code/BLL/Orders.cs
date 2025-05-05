using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BLL
{
    public class Orders
    {
        public int OrderId { get; set; }
        public int Uid { get; set; }
        public float TotalPrice { get; set; }
        public int TotalAmount { get; set; }
        public string status { get; set; }

        public static Orders GetById(int OrderId)
        {
            return OrdersDAL.GetById(OrderId);
        }

        public static List<Orders> GetAll()
        {
            return new List<Orders>();
        }

        public int Save()
        {
            return OrdersDAL.Save(this);
        }

        public static int DeleteById(int OrderId)
        {
            return OrdersDAL.DeleteById(OrderId);
        }
    }

    
}