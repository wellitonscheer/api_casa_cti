using System.Net.Http;
using System.Threading.Tasks;
using api1.Models;
using Microsoft.AspNetCore.Mvc;

namespace api1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ImageController : ControllerBase
    {
        [Route("Dog")]
        public async Task<IActionResult> GetImage()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("https://dog.ceo/api/breeds/image/random");
            string t = await response.Content.ReadAsStringAsync();
            return Ok(new { content = t.ToString() });
        }
    }
}