using Microsoft.Extensions.Logging;
using Movies.Worker.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Worker
{
    public class ApiClient
    {
        private readonly ILogger<ApiClient> _logger;

        public ApiClient(ILogger<ApiClient> logger)
        {
            _logger = logger;
        }
        public async Task SendRate()
        {
            var url = "https://localhost:44314/api/Movies";
       
            var httpClientHandler = new HttpClientHandler();
            httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, sslPolicyErrors) =>
            {
                return true;
            };

            using var client = new HttpClient(httpClientHandler);
            try
            {
                var response = await client.GetAsync(url);

                string result = await response.Content.ReadAsStringAsync();


                List<MovieModel> movies = JsonConvert.DeserializeObject<List<MovieModel>>(result);

                foreach (var item in movies)
                {
                    _logger.LogInformation(item.ToString());

                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
        }

    }
}
