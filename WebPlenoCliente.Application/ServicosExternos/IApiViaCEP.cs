using WebPlenoCliente.Application.DTO;

namespace WebPlenoCliente.Application.ServicosExternos
{
    public interface IApiViaCEP
    {
        Task<ResponseViaCEP> ConsultarEnderecoAsync(string cep);
    }
}
