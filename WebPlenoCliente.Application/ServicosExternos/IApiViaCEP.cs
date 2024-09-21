namespace WebPlenoCliente.Application.ServicosExternos
{
    public interface IApiViaCEP
    {
        Task<string> ConsultarEnderecoAsync(string cep);
    }
}
