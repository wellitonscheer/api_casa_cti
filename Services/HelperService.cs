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
    public class HelperService
    {
        //private NpgsqlConnection connection;
        //private const string BASE_URL_ARDUINO = "http://192.168.21.153:90/?acao=";
        private const string BASE_URL_ARDUINO = "https://2a67-138-94-78-86.sa.ngrok.io/?acao=";
        
        NpgsqlConnection connection = new NpgsqlConnection("Server=ec2-52-204-195-41.compute-1.amazonaws.com;Port=5432;User Id=ptiupmxqefzbrw;Password=b0d2608030cee865d43b71bd99af5856c2bc1f7bd3d7e38e118288d90cfa2077;Database=dem3st7tq31kr7;");

        public async Task<T> RequestArduino<T>(string path)
        {
            HttpClient client = new HttpClient();
            string link = String.Format("{0}{1}", BASE_URL_ARDUINO, path);
            HttpResponseMessage response = await client.GetAsync(link);
            string json = await response.Content.ReadAsStringAsync();
 
            return JsonSerializer.Deserialize<T>(json);
        }

        public async Task<IEnumerable<T>> SelectDB<T>(string tabela){
           connection.Open();
           string commandText = "SELECT * FROM " + tabela;
           var pessoas = await connection.QueryAsync<T>(commandText);
           return pessoas;
        }
        public async Task Insert(aprender pessoa){
           connection.Open();
           string commandText = "INSERT INTO aprender (nome, idade) VALUES (@nome, @idade)";
           var argumentos = new {
               nome = pessoa.nome,
               idade = pessoa.idade
           };
           var pessoas = await connection.ExecuteAsync(commandText, argumentos);
        }
        public async Task<IEnumerable<T>> pegarUsuario<T>(string usuario){
           connection.Open();
           string commandText = String.Format("SELECT U.LOGIN, U.SENHA FROM USUARIOS U WHERE LOGIN = '{0}'", usuario);
           var credenciais = await connection.QueryAsync<T>(commandText);
           return credenciais;
        }
    }
}