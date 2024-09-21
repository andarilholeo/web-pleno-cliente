using WebPlenoCliente.Domain.Entidades;

namespace WebPlenoCliente.Domain.Interfaces
{
    public interface IClienteRepository
    {
        Task<Cliente> AdicionarClienteAsync(Cliente cliente);
        Task<IEnumerable<Cliente>> BuscarClientesAsync();
        Task<Cliente> BuscarClientePorIdAsync(int id);
        Task AlterarClienteAsync(Cliente cliente);
        Task DeletarClienteAsync(int id);
    }
}
