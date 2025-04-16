﻿using BLL;
using DATA;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DAL
{
    public class UsersDAL
    {
        /*
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
        */


        public static Users GetById(int Uid)
        {
            DbContext db = new DbContext();
            string query = $"SELECT * FROM T.Users WHERE Uid = {Uid}";

            DataTable dt = db.Execute(query);

            Users temp = null;
            if (dt.Rows.Count > 0)
            {
                temp = new Users()
                {
                    Uid = (int)dt.Rows[0]["Uid"],
                    FullName = (string)dt.Rows[0]["FullName"],
                    Pass = (string)dt.Rows[0]["Pass"],
                    Email = (string)dt.Rows[0]["Email"],
                    Phone = (string)dt.Rows[0]["Phone"],
                    Address = (string)dt.Rows[0]["Address"],
                    Role = (string)dt.Rows[0]["Role"],

                };

                db.Close();
                return temp;
            }
            return new Users();
        }


        public static List<Users> GetAll()
        {
            DbContext db = new DbContext();
            string query = "SELECT * FROM T.Users";
            DataTable dt = db.Execute(query);
            List<Users> list = new List<Users>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Users tmp = new Users()
                {
                    Uid = (int)dt.Rows[i]["Uid"],
                    FullName = (string)dt.Rows[i]["FullName"],
                    Pass = (string)dt.Rows[i]["Pass"],
                    Email = (string)dt.Rows[i]["Email"],
                    Phone = (string)dt.Rows[i]["Phone"],
                    Address = (string)dt.Rows[i]["Address"],
                    Role = (string)dt.Rows[i]["Role"],
                };
                list.Add(tmp);
            }
            db.Close();
            return list;
        }


        public static int DeleteById(int Uid)
        {
            DbContext db = new DbContext();
            string query = $"Delete FROM T.Users WHERE Uid = {Uid}";
            int i = db.ExecuteNonQuery(query);
            db.Close();
            return i;
        }


        public static int Save(Users tmp)
        {
            DbContext Db = new DbContext();

            string query = $"";

            if (tmp.Uid == -1)
            {
                query = $"Insert Into T.Users (FullName, Pass, Email, Phone, Address, Role) Values";
                query += $"(N'{tmp.FullName}', N'{tmp.Pass}', N'{tmp.Email}', N'{tmp.Phone}', N'{tmp.Address}', N'{tmp.Role}')";

            }
            else
            {
                query = $"Update T.Users Set FullName=N'{tmp.FullName}', ";
                query += $"Pass=N'{tmp.Pass}',";
                query += $"Email=N'{tmp.Email}',";
                query += $"Phone=N'{tmp.Phone}',";
                query += $"Address=N'{tmp.Address}',";
                query += $"Role=N'{tmp.Role}'";
                query += $" Where Uid={tmp.Uid}";
            }

            int i = Db.ExecuteNonQuery(query);
            if (tmp.Uid == -1)
            {
                query = $"SELECT Max(Uid) from T_Users Where FullName='{tmp.FullName}'";
                tmp.Uid = (int)Db.ExecuteScalar(query);
            }
            Db.Close();
            return i;
        }
    }
}