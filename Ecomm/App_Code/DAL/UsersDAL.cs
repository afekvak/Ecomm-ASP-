using BLL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DAL
{
    public class UsersDAL
    {
        public static Users GetById(int Uid)
        {
            // the function recieves a product id and returns the product with that id else return null

            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\EcommDB.mdf;Integrated Security=True;Connect Timeout=30";
            SqlConnection connection = new SqlConnection(connectionString);

            connection.Open();
            string query = $"SELECT * FROM T.Users WHERE Uid = {Uid}";
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();
            Users temp = null;
            if (reader.Read() == true)
            {
                temp = new Users()
                {
                    Uid = (int)reader["Uid"],
                    FullName = (string)reader["FullName"],
                    Pass = (string)reader["Pass"],
                    Email = (string)reader["Email"],
                    Phone = (string)reader["Phone"],
                    Address = (string)reader["Address"],
                    Role = (string)reader["Role"],

                };

                connection.Close();
                return temp;
            }
            return new Users();
        }


        public static List<Users> GetAll()
        {
            // the function recieves a product id and returns the product with that id else return null

            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\EcommDB.mdf;Integrated Security=True;Connect Timeout=30";
            SqlConnection connection = new SqlConnection(connectionString);

            connection.Open();
            string query = $"SELECT * FROM T.Users ";
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();
            List<Users> temp = new List<Users>();
            while (reader.Read() == true)
            {
                Users tmp = new Users()
                {
                    Uid = (int)reader["Uid"],
                    FullName = (string)reader["FullName"],
                    Pass = (string)reader["Pass"],
                    Email = (string)reader["Email"],
                    Phone = (string)reader["Phone"],
                    Address = (string)reader["Address"],
                    Role = (string)reader["Role"],
                };
                temp.Add(tmp);
            }
            connection.Close();
            return temp;
        }


        public static int DeleteById(int Uid)
        {
            // the function recieves a product id and returns the product with that id else return null

            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\EcommDB.mdf;Integrated Security=True;Connect Timeout=30";
            SqlConnection connection = new SqlConnection(connectionString);

            connection.Open();
            string query = $"Delete FROM T.Users WHERE Uid = {Uid}";
            SqlCommand command = new SqlCommand(query, connection);
            int i = command.ExecuteNonQuery();
            connection.Close();
            return i;
        }
    }
}