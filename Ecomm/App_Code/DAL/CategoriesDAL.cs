using BLL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DAL
{
    public class CategoriesDAL
    {
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
    }
}