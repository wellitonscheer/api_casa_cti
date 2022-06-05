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
        [Route("banco")]
        public async Task<IActionResult> Banco()
        {
            HelperService a = new HelperService();
            var resposta = await a.SelectDB<aprender>();
            var b = resposta.First();
            return Ok(new
            {
                resposta = b
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