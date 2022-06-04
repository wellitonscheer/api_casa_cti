using api1.Models;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text.Json;
using System;

namespace api1.Services
{
    public class HelperService
    {
        private const string BASE_URL_ARDUINO = "http://192.168.2.74";

        public async Task<T> RequestArduino<T>(string path)
        {
            HttpClient client = new HttpClient();
            string link = String.Format("{0}/{1}", BASE_URL_ARDUINO, path);
            HttpResponseMessage response = await client.GetAsync(link);
            string json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(json);
        }
    }
}