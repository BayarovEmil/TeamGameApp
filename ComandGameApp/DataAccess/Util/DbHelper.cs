using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComandGameApp.DataAccess.Util
{
    public class DbHelper
    {
        string conectionstring = "Data Source=EMIL\\MSSQLSERVER01;Initial Catalog=TeamGameDb;Integrated Security=True;";
        public void ExecuteNonQuery(string query)
        {
            SqlConnection sqlConnection = new SqlConnection(conectionstring);
            sqlConnection.Open();
            var cmd = new SqlCommand(query, sqlConnection);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            sqlConnection.Close();
        }

        public void ExecuteNonQuery(string query, Dictionary<string, object> parameters = null)
        {
            using (SqlConnection sqlConnection = new SqlConnection(conectionstring))
            {
                sqlConnection.Open();
                using (SqlCommand cmd = new SqlCommand(query, sqlConnection))
                {
                    if (parameters != null)
                    {
                        foreach (var param in parameters)
                        {
                            cmd.Parameters.AddWithValue(param.Key, param.Value);
                        }
                    }

                    cmd.ExecuteNonQuery();
                }
            }
        }


        public int ExecuteScalar(string query)
        {
            SqlConnection sqlConnection = new SqlConnection(conectionstring);
            sqlConnection.Open();
            var cmd = new SqlCommand(query, sqlConnection);
            int value = (int)cmd.ExecuteScalar();
            cmd.Dispose();
            sqlConnection.Close();
            return value;
        }

        public int ExecuteScalar(string query, Dictionary<string, object> parameters = null)
        {
            int value = 0;
            using (SqlConnection sqlConnection = new SqlConnection(conectionstring))
            {
                sqlConnection.Open();
                using (SqlCommand cmd = new SqlCommand(query, sqlConnection))
                {
                    if (parameters != null)
                    {
                        foreach (var param in parameters)
                        {
                            cmd.Parameters.AddWithValue(param.Key, param.Value);
                        }
                    }

                    value = (int)cmd.ExecuteScalar();
                }
            }
            return value;
        }



        public DataTable ExecuteReader(string query)
        {
            DataTable dataTable = new DataTable();

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(conectionstring))
                {
                    sqlConnection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, sqlConnection))
                    {
                        using (SqlDataReader sqlReader = cmd.ExecuteReader())
                        {
                            dataTable.Load(sqlReader);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                // Handle SQL errors
                Console.WriteLine("SQL Error: " + ex.Message);
            }
            catch (Exception ex)
            {
                // Handle other possible errors
                Console.WriteLine("Error: " + ex.Message);
            }

            return dataTable;
        }

    }
}
