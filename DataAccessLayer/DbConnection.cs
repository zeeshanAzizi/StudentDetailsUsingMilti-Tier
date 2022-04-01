using System;
using Microsoft.Data.SqlClient;
using CommonLayer.Models;
namespace DataAccessLayer
{
    public class DbConnection
    {
        public SqlConnection Cnn;
        public DbConnection()
        {
            Cnn = new SqlConnection(Connection.StdConnection); 
        }
    }
}
