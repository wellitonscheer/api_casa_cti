using api1.Models;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text.Json;
using System.Data.SqlClient;
using Dapper;
using System;
using System.Data;
using Npgsql;
using System.Collections.Generic;

namespace api1.Services
{
    public class ConnectionService : IDisposable
    {
        private static ConnectionService _instance;
        public IDbConnection connection;

        public ConnectionService()
        {
            connection = new NpgsqlConnection("Server=ec2-52-204-195-41.compute-1.amazonaws.com;Port=5432;User Id=ptiupmxqefzbrw;Password=b0d2608030cee865d43b71bd99af5856c2bc1f7bd3d7e38e118288d90cfa2077;Database=dem3st7tq31kr7;");
            connection.Open();
        }

        public static ConnectionService GetInstance(){
            if(_instance == null){
                _instance = new ConnectionService();
            }
            return _instance;
        }

        public void Dispose()
        {
            connection.Close();
        }
    }
}