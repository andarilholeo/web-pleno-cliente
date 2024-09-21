namespace WebPlenoCliente.Application.DTO
{
    public record EnderecoDTO
    {
        public int ID { get; init; }
        public int ClienteID { get; init; }
        public string CEP { get; init; }
        public string Rua { get; init; }
        public string Numero { get; init; }
        public string Complemento { get; init; }
        public string Bairro { get; init; }
        public string Cidade { get; init; }
        public string Estado { get; init; }
    }
}
