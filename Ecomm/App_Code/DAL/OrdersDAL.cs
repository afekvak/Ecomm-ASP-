using BLL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DAL
{
    public class OrdersDAL
    {
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
    }
}