using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MailCryptAPI.DataServer
{
    public class SQLaccess
    {
        private string connectionString;

        private static SQLaccess instance;

        public static SQLaccess Instance
        {
            get
            {
                if (instance == null) instance = new SQLaccess();
                return SQLaccess.instance;
            }
            private set { instance = value; }
        }

        protected SQLaccess() {
            connectionString = @"Data Source=PC\SQLEXPRESS;Initial Catalog=MailCryptDB;Integrated Security=True";
        }

        private SqlConnection getConnection(string connectionString)
        {
            SqlConnection connect = new SqlConnection(connectionString);
            connect.Open();
            return connect;
        }

        public DataTable ExecuteQuery(string query, object[] parameter = null)
        {
            DataTable dt = new DataTable();
            using (SqlConnection connect = getConnection(connectionString))
            {
                connect.Open();
                SqlCommand comd = new SqlCommand(query, connect);

                if (parameter != null)          //Xử lý parameter
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            comd.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }
                SqlDataAdapter adapter = new SqlDataAdapter(comd);
                adapter.Fill(dt);
                connect.Close();
                return dt;
            }
        }

        public int ExecuteNoneQuery(string query, object[] parameter = null)
        {
            int data = 0;
            using (SqlConnection connect = getConnection(connectionString))
            {
                connect.Open();
                SqlCommand comd = new SqlCommand(query, connect);

                if (parameter != null)             //Xử lý parameter
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            comd.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }
                data = comd.ExecuteNonQuery();

                connect.Close();
                return data;
            }
        }

        public object ExecuteScallar(string query, object[] parameter = null)
        {
            object dt = 0;
            using (SqlConnection connect = getConnection(connectionString))
            {
                connect.Open();
                SqlCommand comd = new SqlCommand(query, connect);

                if (parameter != null)               //Xử lý parameter
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            comd.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }
                dt = comd.ExecuteScalar();
                connect.Close();
                return dt;
            }
        }
    }
}