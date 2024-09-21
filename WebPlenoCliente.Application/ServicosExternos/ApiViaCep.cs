

using Microsoft.Extensions.Configuration;

namespace WebPlenoCliente.Application.ServicosExternos
{
    public class ApiViaCep : IApiViaCEP
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public ApiViaCep(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task<string> ConsultarEnderecoAsync(string cep)
        {
            var baseUrl = _configuration["ApiSettings:BaseAPIViaCep"];

            var response = await _httpClient.GetAsync($"{baseUrl}{cep}/json/");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            return content;
        }
    }
}
