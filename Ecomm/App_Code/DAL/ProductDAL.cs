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
            string query = $"SELECT * FROM T_Product WHERE Pid = {Pid}";

            DataTable dt = db.Execute(query);
            
            Product temp = null;
            if (dt.Rows.Count > 0)
            {
                temp = new Product()
                {
                    Pid = Convert.ToInt32(dt.Rows[0]["Pid"]),
                    Pname = (string)dt.Rows[0]["Pname"],
                    Pdesc = (string)dt.Rows[0]["Pdesc"],
                    Price = Convert.ToSingle(dt.Rows[0]["Price"]),
                    Picname = (string)dt.Rows[0]["Picname"],
                    Cid = Convert.ToInt32(dt.Rows[0]["Cid"]),
                };

                db.Close();
                return temp;
            }
            return new Product();
        }


        public static List<Product> GetAll()
        {
            DbContext db = new DbContext();
            string query = "SELECT * FROM T_Product";
            DataTable dt = db.Execute(query);
            List<Product> list = new List<Product>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Product tmp = new Product()
                {
                    Pid = Convert.ToInt32(dt.Rows[i]["Pid"]),
                    Pname = dt.Rows[i]["Pname"].ToString(),
                    Pdesc = dt.Rows[i]["Pdesc"].ToString(),
                    Price = Convert.ToSingle(dt.Rows[i]["Price"]),
                    Picname = dt.Rows[i]["Picname"].ToString(),
                    Cid = Convert.ToInt32(dt.Rows[i]["Cid"]),
                };
                list.Add(tmp);
            }
            db.Close();
            return list;
        }


        public static int DeleteById(int Pid)
        {
            DbContext db = new DbContext();
            string query = $"Delete FROM T_Product WHERE Pid = {Pid}";
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
                query = $"Insert into T_Product(Pname,Pdesc,Price,Picname,Status,Cid)"; 
                query +=$"    values(N'{tmp.Pname}',N'{tmp.Pdesc}',{tmp.Price},N'{tmp.Picname}',{tmp.Status},{tmp.Cid})";
            }
            else
            {
                query = $"Update T_Product Set ";
                query += $"Pname=N'{tmp.Pname}', ";
                query += $"Pdesc=N'{tmp.Pdesc}', ";
                query += $"Price={tmp.Price}, ";
                query += $"Picname=N'{tmp.Picname}', ";
                query += $"Status={tmp.Status}, ";
                query += $"Cid={tmp.Cid} ";
                query += $"Where Pid={tmp.Pid}";

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