using System.Text.Json.Serialization;

namespace WebPlenoCliente.Application.DTO
{
    public class ResponseViaCEP
    {
        [JsonPropertyName("cep")]
        public string cep { get; set; }

        [JsonPropertyName("logradouro")]
        public string logradouro { get; set; }

        [JsonPropertyName("complemento")]
        public string complemento { get; set; }

        [JsonPropertyName("bairro")]
        public string bairro { get; set; }

        [JsonPropertyName("localidade")]
        public string localidade { get; set; }

        [JsonPropertyName("uf")]
        public string uf { get; set; }

        [JsonPropertyName("ibge")]
        public string ibge { get; set; }

        [JsonPropertyName("gia")]
        public string gia { get; set; }

        [JsonPropertyName("ddd")]
        public string ddd { get; set; }

        [JsonPropertyName("siafi")]
        public string siafi { get; set; }


        [JsonPropertyName("erro")]
        public bool Status { get; set; } = false;
    }
}
