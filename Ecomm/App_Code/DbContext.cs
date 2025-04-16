using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace DATA
{
    public class DbContext
    {
        public string ConnectionString { get; set; }
        public SqlConnection Connection { get; set; }
        public SqlCommand Command { get; set; }

        public DbContext() 
        {
            this.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\EcommDB.mdf;Integrated Security=True;Connect Timeout=30";
            this.Connection = new SqlConnection(ConnectionString);
            Connection.Open();
        }

        public void Close()
        {
            Connection.Close(); 
        }

        public int ExecuteNonQuery(string query)
        {
            SqlCommand command = new SqlCommand(query, Connection);
            return command.ExecuteNonQuery();
        }

        public DataTable Execute(string query)
        {
            SqlCommand command = new SqlCommand(query, Connection);
            
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable Dt = new DataTable();
            adapter.SelectCommand = command;
            adapter.Fill(Dt);
            return Dt;

        }

        public object ExecuteScalar(string query)
        {
            SqlCommand command = new SqlCommand(query, Connection);
            return command.ExecuteScalar();
        }
    }
}