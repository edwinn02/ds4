using System.Data.SqlClient;

namespace CalculadoraAPI.Data
{
    public static class DBConnection
    {
        private static readonly string connectionString =
            @"Data Source=DESKTOP-3IOUQVC\SQLEXPRESS;
              Initial Catalog=CalculadoraDB;
              Integrated Security=True;
              TrustServerCertificate=True";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}