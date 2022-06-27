using api1.Models;
using api1.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text.Json;
using System;
using System.Linq;

namespace api1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HelloWorldController : ControllerBase
    {
        public class QueryParameters
        {
            public string path { get; set; }
            public int item { get; set; }
            public int acao { get; set; }
            public string usuario { get; set; }
            public string tabela { get; set; }
            public string filtro { get; set; }
        }

        [HttpGet]
        [Route("acao")]
        public async Task<IActionResult> Acao([FromQuery] QueryParameters queryParameters)
        {
            var resposta = await new HelperService().RequestArduino<Casa>(queryParameters.path);
            return Ok(new
            {
                resposta = resposta.nome
            });
        }
        [HttpGet]
        [Route("select")]
        public async Task<IActionResult> Banco()
        {
            HelperService a = new HelperService();
            var resposta = await a.SelectDB<aprender>("aprender");
            return Ok(new
            {
                resposta = resposta
            });
        }

        [HttpGet]
        [Route("insert")]
        public async void BancoInsert()
        {
            HelperService a = new HelperService();
            aprender pessoa = new aprender();
            pessoa.nome = "adriano";
            pessoa.idade = 25;
            await a.Insert(pessoa);
        }

        [HttpGet]
        [Route("login")]
        public async Task<IActionResult> testarSenha([FromQuery] QueryParameters queryParameters)
        {
            HelperService a = new HelperService();
            var resposta = await a.pegarUsuario<Login>(queryParameters.usuario);
            return Ok(new
            {
                resposta = resposta
            });
        }

        [HttpGet]
        [Route("evento")]
        public async Task<IActionResult> EventoInserir([FromQuery] QueryParameters queryParameters)
        {
            HelperService a = new HelperService();
            await a.InserirEvento(queryParameters.usuario, queryParameters.acao, queryParameters.item);
            return Ok(new
            {
                resposta = "evento inserido"
            });
        }

        [HttpGet]
        [Route("filtro_usuario")]
        public async Task<IActionResult> FiltroUsuario([FromQuery] QueryParameters queryParameters)
        {
            HelperService a = new HelperService();
            var usuarios = await a.SelectDB<Usuarios>(queryParameters.tabela);
            return Ok(new
            {
                resposta = usuarios
            });
        }

        [HttpGet]
        [Route("filtro_componente")]
        public async Task<IActionResult> FiltroComponente([FromQuery] QueryParameters queryParameters)
        {
            HelperService a = new HelperService();
            var componentes = await a.SelectDB<Componentes>(queryParameters.tabela);
            return Ok(new
            {
                resposta = componentes
            });
        }

        [HttpGet]
        [Route("filtro_acao")]
        public async Task<IActionResult> FiltroAcao([FromQuery] QueryParameters queryParameters)
        {
            HelperService a = new HelperService();
            var acoes = await a.SelectDB<Acoes>(queryParameters.tabela);
            return Ok(new
            {
                resposta = acoes
            });
        }

        [HttpGet]
        [Route("relatorio")]
        public async Task<IActionResult> Relatorio([FromQuery] QueryParameters queryParameters)
        {
            HelperService a = new HelperService();
            var relatorio = await a.RelatorioDb<Relatorio>(queryParameters.filtro);
            return Ok(new
            {
                resposta = relatorio
            });
        }

        [HttpPost]
        public IActionResult SayHello([FromBody] Pessoa pessoa)
        {
            return Ok(new
            {
                text = "Olá " + pessoa.nome
            });
        }
    }
}