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
        private const string BASE_URL_ARDUINO = "https://34eb-138-94-78-86.sa.ngrok.io/?acao=";
        
        IDbConnection connection = ConnectionService.GetInstance().connection;

        public async Task<T> RequestArduino<T>(string path)
        {
            HttpClient client = new HttpClient();
            string link = String.Format("{0}{1}", BASE_URL_ARDUINO, path);
            HttpResponseMessage response = await client.GetAsync(link);
            string json = await response.Content.ReadAsStringAsync();
 
            return JsonSerializer.Deserialize<T>(json);
        }

        public async Task<IEnumerable<T>> SelectDB<T>(string tabela){
           string commandText = "SELECT * FROM " + tabela;
           var pessoas = await connection.QueryAsync<T>(commandText);
           return pessoas;
        }
        public async Task Insert(aprender pessoa){
           string commandText = "INSERT INTO aprender (nome, idade) VALUES (@nome, @idade)";
           var argumentos = new {
               nome = pessoa.nome,
               idade = pessoa.idade
           };
           var pessoas = await connection.ExecuteAsync(commandText, argumentos);
        }

        public async Task<IEnumerable<T>> pegarUsuario<T>(string usuario){
           string commandText = String.Format("SELECT U.LOGIN, U.SENHA FROM USUARIOS U WHERE LOGIN = '{0}'", usuario);
           var credenciais = await connection.QueryAsync<T>(commandText);
           return credenciais;
        }

        public async Task<T> CodigoPessoa<T>(string usuario){
           var queryCodPessoa = String.Format("select u.id from usuarios u where u.login = '{0}'", usuario);
           var codPessoa = await connection.QueryFirstAsync<T>(queryCodPessoa);
        return codPessoa;
        }
        
        public async Task InserirEvento(string usuario, int acao, int item){
           DateTime tempo = DateTime.Now;
           int id = (await CodigoPessoa<Codigo>(usuario)).id;
           string commandText = "INSERT INTO eventos (acao, pessoa, componente, tempo) VALUES (@acaoQj, @pessoaQj, @componenteQj, @tempoQj)";
           var argumentos = new {
               acaoQj = acao,
               pessoaQj = id,
               componenteQj = item,
               tempoQj = tempo
           };
           var credenciais = await connection.ExecuteAsync(commandText, argumentos);
        }
    }
}