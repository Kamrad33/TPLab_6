using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Web;
using log4net;
using log4net.Config;

namespace TP_Lab5.DAO
{
    public class DAO
    {
        private string connectionString = @"Data Source=sergvlad\SQLEXPRESS;Initial Catalog=ГИБДД;Integrated Security=True;";

        public SqlConnection Connection { get; set; }
        public void Connect()
        {
         //   Log.For(this).Info("FORLOG");
            Connection = new SqlConnection(connectionString);
            Connection.Open();

        }
        public void Disconnect()
        {
         //   Log.For(this).Info("FORLOG");
            Connection.Close();

        }

    }
}