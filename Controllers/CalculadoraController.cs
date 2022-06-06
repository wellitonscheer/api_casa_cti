using api1.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace api1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculadoraController : ControllerBase
    {
        [HttpPost]
        [Route("imc")]
        public IActionResult Imc([FromBody] ImcModel imc)
        {
            Console.WriteLine(imc.Peso);
            System.Threading.Thread.Sleep(10000);
            double resultado = imc.Peso / (imc.Altura * imc.Altura);
            string descricao = ImcToText(resultado);
            return Ok(new
            {
                imc = resultado,
                descricao = descricao
            });
        }

        private string ImcToText(double imc)
        {
            if (imc < 18.5) return "Abaixo do normal";
            if (imc <= 24.9) return "Normal";
            if (imc <= 29.9) return "Sobrepeso";
            if (imc <= 34.9) return "Obesidade Grau I";
            if (imc <= 39.9) return "Obesidade Grau II";
            return "Obesidade Grau III - Mórbida";
        }
    }
}