using BLL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography;

namespace DAL
{
    public class ProductDAL
    {

        public static Product GetById(int Pid)
        {
            // the function recieves a product id and returns the product with that id else return null
            
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\EcommDB.mdf;Integrated Security=True;Connect Timeout=30";
            SqlConnection connection = new SqlConnection(connectionString);

            connection.Open();
            string query = $"SELECT * FROM T.Product WHERE Pid = {Pid}";
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();
            Product temp = null;
            if (reader.Read() ==true)
            {
                temp = new Product()
                {
                    Pid =(int) reader["Pid"],
                    Pname = (string)reader["Pname"],
                    Pdesc = (string)reader["Pdesc"],
                    Price = (float)reader["Price"],
                    Picname = (string)reader["Picname"],
                    Cid = (int)reader["Cid"],
                    Quantity = (int)reader["Quantity"]
                };
                
                connection.Close();
                return temp;
            }
            return new Product();
        }


        public static List<Product> GetAll()
        {
            // the function recieves a product id and returns the product with that id else return null

            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\EcommDB.mdf;Integrated Security=True;Connect Timeout=30";
            SqlConnection connection = new SqlConnection(connectionString);

            connection.Open();
            string query = $"SELECT * FROM T.Product ";
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();
            List<Product> temp = new List<Product>();
            while (reader.Read() == true)
            {
                Product tmp = new Product()
                {
                    Pid = (int)reader["Pid"],
                    Pname = (string)reader["Pname"],
                    Pdesc = (string)reader["Pdesc"],
                    Price = (float)reader["Price"],
                    Picname = (string)reader["Picname"],
                    Cid = (int)reader["Cid"],
                    Quantity = (int)reader["Quantity"]
                };
                temp.Add(tmp);
            }   
            connection.Close();
            return temp;
        }

        public static int DeleteById(int Pid)
        {
            // the function recieves a product id and returns the product with that id else return null

            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\EcommDB.mdf;Integrated Security=True;Connect Timeout=30";
            SqlConnection connection = new SqlConnection(connectionString);

            connection.Open();
            string query = $"Delete FROM T.Product WHERE Pid = {Pid}";
            SqlCommand command = new SqlCommand(query, connection);
            int i = command.ExecuteNonQuery();
            connection.Close();
            return i;
        }
    }
}