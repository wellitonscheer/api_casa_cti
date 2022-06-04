using api1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Net.Http;
//using System.Net.Http.Headers;
using System.Text.Json;
using System;

namespace api1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HelloWorldController : ControllerBase
    {
        private static readonly HttpClient client = new HttpClient();
        
        [HttpGet]
        [Route("luz_azul")]
        public async Task<IActionResult> LuzAzul()
        {
            Pessoa pessoa = new Pessoa();

            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("http://192.168.209.153/luz_azul");
            string t = await response.Content.ReadAsStringAsync();
            pessoa = JsonSerializer.Deserialize<Pessoa>(t);

            return Ok(new
            {
                nome = pessoa.nome
            });
        }

        [HttpGet]
        [Route("desliga_luz_azul")]
        public async Task<IActionResult> DesligaLuzAzul()
        {
            Pessoa pessoa = new Pessoa();

            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("http://192.168.209.153/desliga_luz_azul");
            string t = await response.Content.ReadAsStringAsync();
            pessoa = JsonSerializer.Deserialize<Pessoa>(t);

            return Ok(new
            {
                nome = pessoa.nome
            });
        }


        [HttpGet]
        [Route("luz_branca")]
        public async Task<IActionResult> luz_branca()
        {
            Pessoa pessoa = new Pessoa();

            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("http://192.168.209.153/luz_branca");
            string t = await response.Content.ReadAsStringAsync();
            pessoa = JsonSerializer.Deserialize<Pessoa>(t);

            return Ok(new
            {
                nome = pessoa.nome
            });
        }
        [HttpGet]
        [Route("desliga_luz_branca")]
        public async Task<IActionResult> DesligaLuzBranca()
        {
            Pessoa pessoa = new Pessoa();

            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("http://192.168.209.153/desliga_luz_branca");
            string t = await response.Content.ReadAsStringAsync();
            pessoa = JsonSerializer.Deserialize<Pessoa>(t);

            return Ok(new
            {
                nome = pessoa.nome
            });
        }

        [HttpGet]
        [Route("luz_vermelha")]
        public async Task<IActionResult> LuzVermelha()
        {
            Pessoa pessoa = new Pessoa();

            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("http://192.168.209.153/luz_vermelha");
            string t = await response.Content.ReadAsStringAsync();
            pessoa = JsonSerializer.Deserialize<Pessoa>(t);

            return Ok(new
            {
                nome = pessoa.nome
            });
        }
        [HttpGet]
        [Route("desliga_luz_vermelha")]
        public async Task<IActionResult> DesligaLuzVermelha()
        {
            Pessoa pessoa = new Pessoa();

            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("http://192.168.209.153/desliga_luz_vermelha");
            string t = await response.Content.ReadAsStringAsync();
            pessoa = JsonSerializer.Deserialize<Pessoa>(t);

            return Ok(new
            {
                nome = pessoa.nome
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