using WebPlenoCliente.Application.DTO;

namespace WebPlenoCliente.Application.Services.EnderecoService
{
    public interface IEnderecoService
    {
        Task<IEnumerable<EnderecoDTO>> BuscarEnderecosAsync();
        Task<EnderecoDTO> BuscarEnderecoPorIdAsync(int id);
        Task<IEnumerable<EnderecoDTO>> BuscarEnderecosPorClienteAsync(int clienteId);
        Task<EnderecoDTO> AdicionarEnderecoAsync(EnderecoDTO enderecoDTO);
        Task AlterarEnderecoAsync(EnderecoDTO enderecoDTO);
        Task DeletarEnderecoAsync(int id);
    }
}
