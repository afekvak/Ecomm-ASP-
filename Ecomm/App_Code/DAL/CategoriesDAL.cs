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
    public class CategoriesDAL
    {
        /*
        public static Categories GetById(int Cid)
        {
            // the function recieves a product id and returns the product with that id else return null

            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\EcommDB.mdf;Integrated Security=True;Connect Timeout=30";
            SqlConnection connection = new SqlConnection(connectionString);

            connection.Open();
            string query = $"SELECT * FROM T.Category WHERE Cid = {Cid}";
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();
            Categories temp = null;
            if (reader.Read() == true)
            {
                temp = new Categories()
                {
                    Cid = (int)reader["Cid"],
                    Cname = (string)reader["Cname"],
                };

                connection.Close();
                return temp;
            }
            return new Categories();
        }


        public static List<Categories> GetAll()
        {
            // the function recieves a product id and returns the product with that id else return null

            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\EcommDB.mdf;Integrated Security=True;Connect Timeout=30";
            SqlConnection connection = new SqlConnection(connectionString);

            connection.Open();
            string query = $"SELECT * FROM T.Category ";
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();
            List<Categories> temp = new List<Categories>();
            while (reader.Read() == true)
            {
                Categories tmp = new Categories()
                {
                    Cid = (int)reader["Cid"],
                    Cname = (string)reader["Cname"],
                };
                temp.Add(tmp);
            }
            connection.Close();
            return temp;
        }


        public static int DeleteById(int Cid)
        {
            // the function recieves a product id and returns the product with that id else return null

            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\EcommDB.mdf;Integrated Security=True;Connect Timeout=30";
            SqlConnection connection = new SqlConnection(connectionString);

            connection.Open();
            string query = $"Delete FROM T.Category WHERE Cid = {Cid}";
            SqlCommand command = new SqlCommand(query, connection);
            int i = command.ExecuteNonQuery();
            connection.Close();
            return i;
        }
        */

        public static Categories GetById(int Cid)
        {
            DbContext db = new DbContext();
            string query = $"SELECT * FROM T.Category WHERE Cid = {Cid}";

            DataTable dt = db.Execute(query);

            Categories temp = null;
            if (dt.Rows.Count > 0)
            {
                temp = new Categories()
                {
                    Cid = (int)dt.Rows[0]["Cid"],
                    Cname = (string)dt.Rows[0]["Cname"],
                };

                db.Close();
                return temp;
            }
            return new Categories();
        }


        public static List<Categories> GetAll()
        {
            DbContext db = new DbContext();
            string query = "SELECT * FROM T.Category";
            DataTable dt = db.Execute(query);
            List<Categories> list = new List<Categories>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Categories tmp = new Categories()
                {
                    Cid = (int)dt.Rows[i]["Cid"],
                    Cname = (string)dt.Rows[i]["Cname"],
                };
                list.Add(tmp);
            }
            db.Close();
            return list;
        }


        public static int DeleteById(int Cid)
        {
            DbContext db = new DbContext();
            string query = $"Delete FROM T.Category WHERE Cid = {Cid}";
            int i = db.ExecuteNonQuery(query);
            db.Close();
            return i;
        }


        public static int Save(Categories tmp)
        {
            DbContext Db = new DbContext();

            string query = $"";

            if (tmp.Cid == -1)
            {
                query = $"Insert Into T_Category (Cname) Values (N'{tmp.Cname}')";
            }
            else
            {
                query = $"Update T_Category Set Cname = N'{tmp.Cname}' Where Cid = {tmp.Cid}";
            }

            int i = Db.ExecuteNonQuery(query);
            if (tmp.Cid == -1)
            {
                query = $"SELECT Max(Cid) from T_Category Where Cname='{tmp.Cname}'";
                tmp.Cid = (int)Db.ExecuteScalar(query);
            }
            Db.Close();
            return i;
        }
    }
}