using BLL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography;
using DATA;

namespace DAL
{
    public class ProductDAL
    {

        public static Product GetById(int Pid)
        {
            DbContext db = new DbContext();
            string query = $"SELECT * FROM T.Product WHERE Pid = {Pid}";

            DataTable dt = db.Execute(query);
            
            Product temp = null;
            if (dt.Rows.Count > 0)
            {
                temp = new Product()
                {
                    Pid =(int) dt.Rows[0]["Pid"],
                    Pname = (string)dt.Rows[0]["Pname"],
                    Pdesc = (string)dt.Rows[0]["Pdesc"],
                    Price = (float)dt.Rows[0]["Price"],
                    Picname = (string)dt.Rows[0]["Picname"],
                    Cid = (int)dt.Rows[0]["Cid"],
                    Quantity = (int)dt.Rows[0]["Quantity"]
                };

                db.Close();
                return temp;
            }
            return new Product();
        }


        public static List<Product> GetAll()
        {
            DbContext db = new DbContext();
            string query = "SELECT * FROM T.Product";
            DataTable dt = db.Execute(query);
            List<Product> list = new List<Product>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Product tmp = new Product()
                {
                    Pid = (int)dt.Rows[i]["Pid"],
                    Pname = (string)dt.Rows[i]["Pname"],
                    Pdesc = (string)dt.Rows[i]["Pdesc"],
                    Price = (float)dt.Rows[i]["Price"],
                    Picname = (string)dt.Rows[i]["Picname"],
                    Cid = (int)dt.Rows[i]["Cid"],
                    Quantity = (int)dt.Rows[i]["Quantity"]
                };
                list.Add(tmp);
            }
            db.Close();
            return list;
        }


        public static int DeleteById(int Pid)
        {
            DbContext db = new DbContext();
            string query = $"Delete FROM T.Product WHERE Pid = {Pid}";
            int i = db.ExecuteNonQuery(query);
            db.Close();
            return i;
        }


        public static int Save(Product tmp)
        {
            DbContext Db = new DbContext();

            string query = $"";
          
            if(tmp.Pid == -1)
            {
                query = $"Insert into T_Product(Pname,Pdesc,Price,Picname,Status,Cid,Quantity)"; 
                query +=$"    values(N'{tmp.Pname}',N'{tmp.Pdesc}',{tmp.Price},N'{tmp.Picname}',{tmp.Status},{tmp.Cid},{tmp.Quantity})";
            }
            else
            {
                query = $"Update T_Product Set";
                query += $"Pname=N'{tmp.Pname}', ";
                query += $"Pdesc=N'{tmp.Pdesc}', ";
                query += $"Price={tmp.Price},";
                query += $"Picname=N''{tmp.Picname},";
                query += $"Status={tmp.Status},";
                query += $"Cid={tmp.Cid},";
                query += $"Quantity={tmp.Quantity},";
                query += $"  Where Pid={tmp.Pid}";
            }
            
            int i = Db.ExecuteNonQuery(query);
            if(tmp.Pid == -1)
            {
                query = $"SELECT Max(Pid) from T_Product Where Pname='{tmp.Pname}'";
                tmp.Pid = (int)Db.ExecuteScalar(query);
            }
            Db.Close();
            return i;
        }
    }
}