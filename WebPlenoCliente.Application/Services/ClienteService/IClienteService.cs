using WebPlenoCliente.Application.DTO;

namespace WebPlenoCliente.Application.Services.Cliente
{
    public interface IClienteService
    {
        Task<IEnumerable<ClienteDTO>> BuscarClientesAsync();
        Task<ClienteDTO> BuscarClientePorIdAsync(int id);
        Task<ClienteDTO> AdicionarClienteAsync(ClienteDTO cliente);
        Task AlterarClienteAsync(ClienteDTO cliente);
        Task DeletarClienteAsync(int id);
    }
}
