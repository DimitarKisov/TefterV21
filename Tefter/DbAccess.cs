namespace Tefter
{
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public static class DbAccess
    {
        private static SqlConnection connection = new SqlConnection();

        public static void CreateConnection(string connectionString)
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void CloseConnection()
        {
            connection.Close();
        }

        public static int ExecuteQuery(SqlCommand dbCommand, string connectionString)
        {
            try
            {
                if (connection.State == 0)
                {
                    CreateConnection(connectionString);
                }

                dbCommand.Connection = connection;
                dbCommand.CommandType = CommandType.Text;


                var result = dbCommand.ExecuteNonQuery();
                CloseConnection();

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
