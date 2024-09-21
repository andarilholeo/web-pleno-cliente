namespace WebPlenoCliente.Application.DTO
{
    public record ClienteDTO
    {
        public int ID { get; init; }
        public string Nome { get; init; }
        public string Email { get; init; }
        public string Telefone { get; init; }
        public DateTime DataNascimento { get; init; }
    }

}
