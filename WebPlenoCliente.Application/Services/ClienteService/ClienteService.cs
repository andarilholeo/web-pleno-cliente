using AutoMapper;
using WebPlenoCliente.Application.DTO;
using WebPlenoCliente.Domain.Entidades;
using WebPlenoCliente.Domain.Interfaces;
using WebPlenoCliente.Infra.Repositories;

namespace WebPlenoCliente.Application.Services.Cliente
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _repository;
        private readonly IMapper _mapper;

        public ClienteService(IClienteRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ClienteDTO> BuscarClientePorIdAsync(int id)
        {
            var cliente = await _repository.BuscarClientePorIdAsync(id);

            return _mapper.Map<ClienteDTO>(cliente);
        }

        public async Task<IEnumerable<ClienteDTO>> BuscarClientesAsync()
        {
            var clientes = await _repository.BuscarClientesAsync();

            return _mapper.Map<IEnumerable<ClienteDTO>>(clientes);
        }

        public async Task<ClienteDTO> AdicionarClienteAsync(ClienteDTO clienteDTO)
        {
            var clienteModel = _mapper.Map<WebPlenoCliente.Domain.Entidades.Cliente>(clienteDTO);
            var novoCliente = await _repository.AdicionarClienteAsync(clienteModel);

            return _mapper.Map<ClienteDTO>(novoCliente);
        }

        public async Task AlterarClienteAsync(ClienteDTO clienteDTO)
        {
            var cliente = _mapper.Map<WebPlenoCliente.Domain.Entidades.Cliente>(clienteDTO);
            await _repository.AlterarClienteAsync(cliente);
        }

        public async Task DeletarClienteAsync(int id)
        {
            await _repository.DeletarClienteAsync(id);
        }
    }
}
