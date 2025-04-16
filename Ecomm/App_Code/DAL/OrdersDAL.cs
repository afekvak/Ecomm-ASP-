using BLL;
using DATA;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DAL
{
    public class OrdersDAL
    {
        /*
        public static Orders GetById(int OrderId)
        {
            // the function recieves a product id and returns the product with that id else return null

            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\EcommDB.mdf;Integrated Security=True;Connect Timeout=30";
            SqlConnection connection = new SqlConnection(connectionString);

            connection.Open();
            string query = $"SELECT * FROM T.Orders WHERE OrderId = {OrderId}";
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();
            Orders temp = null;
            if (reader.Read() == true)
            {
                temp = new Orders()
                {
                    OrderId = (int)reader["OrderId"],
                    Uid = (int)reader["Uid"],
                    TotalPrice = (float)reader["TotalPrice"],
                    TotalAmount = (int)reader["TotalAmount"],
                    status = (string)reader["status"],
                };

                connection.Close();
                return temp;
            }
            return new Orders();
        }


        public static List<Orders> GetAll()
        {
            // the function recieves a product id and returns the product with that id else return null

            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\EcommDB.mdf;Integrated Security=True;Connect Timeout=30";
            SqlConnection connection = new SqlConnection(connectionString);

            connection.Open();
            string query = $"SELECT * FROM T.Orders ";
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();
            List<Orders> temp = new List<Orders>();
            while (reader.Read() == true)
            {
                Orders tmp = new Orders()
                {
                    OrderId = (int)reader["OrderId"],
                    Uid = (int)reader["Uid"],
                    TotalPrice = (float)reader["TotalPrice"],
                    TotalAmount = (int)reader["TotalAmount"],
                    status = (string)reader["status"],
                };
                temp.Add(tmp);
            }
            connection.Close();
            return temp;
        }


        public static int DeleteById(int OrderId)
        {
            // the function recieves a product id and returns the product with that id else return null

            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\EcommDB.mdf;Integrated Security=True;Connect Timeout=30";
            SqlConnection connection = new SqlConnection(connectionString);

            connection.Open();
            string query = $"Delete FROM T.Orders WHERE OrderId = {OrderId}";
            SqlCommand command = new SqlCommand(query, connection);
            int i = command.ExecuteNonQuery();
            connection.Close();
            return i;
        }
        */

        public static Orders GetById(int Orderid)
        {
            DbContext db = new DbContext();
            string query = $"SELECT * FROM T.Orders WHERE OrderId = {Orderid}";

            DataTable dt = db.Execute(query);

            Orders temp = null;
            if (dt.Rows.Count > 0)
            {
                temp = new Orders()
                {
                    OrderId = (int)dt.Rows[0]["OrderId"],
                    Uid = (int)dt.Rows[0]["Uid"],
                    TotalPrice = (float)dt.Rows[0]["TotalPrice"],
                    TotalAmount = (int)dt.Rows[0]["TotalAmount"],
                    status = (string)dt.Rows[0]["status"],
                };

                db.Close();
                return temp;
            }
            return new Orders();
        }


        public static List<Orders> GetAll()
        {
            DbContext db = new DbContext();
            string query = "SELECT * FROM T.Orders";
            DataTable dt = db.Execute(query);
            List<Orders> list = new List<Orders>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Orders tmp = new Orders()
                {
                    OrderId = (int)dt.Rows[i]["OrderId"],
                    Uid = (int)dt.Rows[i]["Uid"],
                    TotalPrice = (float)dt.Rows[i]["TotalPrice"],
                    TotalAmount = (int)dt.Rows[i]["TotalAmount"],
                    status = (string)dt.Rows[i]["status"],
                };
                list.Add(tmp);
            }
            db.Close();
            return list;
        }


        public static int DeleteById(int Orderid)
        {
            DbContext db = new DbContext();
            string query = $"Delete FROM T.Orders WHERE OrderId = {Orderid}";
            int i = db.ExecuteNonQuery(query);
            db.Close();
            return i;
        }


        public static int Save(Orders tmp)
        {
            DbContext Db = new DbContext();

            string query = $"";

            if (tmp.OrderId == -1)
            {
                query = $"Insert Into T.Orders (Uid, TotalPrice, TotalAmount, status) Values ";
                query += $"(N'{tmp.Uid}',";
                query += $"N'{tmp.TotalPrice}',";
                query += $"N'{tmp.TotalAmount}',";
                query += $"N'{tmp.status}')";

            }
            else
            {
                query = $"Update T.Orders Set ";
                query += $"Uid=N'{tmp.Uid}',";
                query += $"TotalPrice=N'{tmp.TotalPrice}',";
                query += $"TotalAmount=N'{tmp.TotalAmount}',";
                query += $"status=N'{tmp.status}'";
                query += $" Where OrderId = {tmp.OrderId}";
            }

            int i = Db.ExecuteNonQuery(query);
            if (tmp.OrderId == -1)
            {
                query = $"SELECT Max(OrderId) from T_Orders Where OrderId='{tmp.OrderId}'";
                tmp.OrderId = (int)Db.ExecuteScalar(query);
            }
            Db.Close();
            return i;
        }
    }
}