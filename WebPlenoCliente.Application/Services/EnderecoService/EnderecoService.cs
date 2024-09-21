using AutoMapper;
using WebPlenoCliente.Application.DTO;
using WebPlenoCliente.Domain.Entidades;
using WebPlenoCliente.Domain.Interfaces;

namespace WebPlenoCliente.Application.Services.EnderecoService
{
    public class EnderecoService : IEnderecoService
    {
        private readonly IEnderecoRepository _enderecoRepository;
        private readonly IMapper _mapper;

        public EnderecoService(IEnderecoRepository enderecoRepository, IMapper mapper)
        {
            _enderecoRepository = enderecoRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EnderecoDTO>> BuscarEnderecosPorClienteAsync(int clienteId)
        {
            var enderecos = await _enderecoRepository.BuscarEnderecosPorClienteAsync(clienteId);
            return _mapper.Map<IEnumerable<EnderecoDTO>>(enderecos);
        }

        public async Task<EnderecoDTO> BuscarEnderecoPorIdAsync(int id)
        {
            var endereco = await _enderecoRepository.BuscarEnderecoPorIdAsync(id);
            return _mapper.Map<EnderecoDTO>(endereco);
        }

        public Task<IEnumerable<EnderecoDTO>> BuscarEnderecosAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<EnderecoDTO> AdicionarEnderecoAsync(EnderecoDTO enderecoDto)
        {
            var endereco = _mapper.Map<Endereco>(enderecoDto);
            var novoEndereco = await _enderecoRepository.AdicionarEnderecoAsync(endereco);
            return _mapper.Map<EnderecoDTO>(novoEndereco);
        }

        public async Task AlterarEnderecoAsync(EnderecoDTO enderecoDto)
        {
            var endereco = _mapper.Map<Endereco>(enderecoDto);
            await _enderecoRepository.AlterarEnderecoAsync(endereco);
        }

        public async Task DeletarEnderecoAsync(int id)
        {
            await _enderecoRepository.DeletarEnderecoAsync(id);
        }
    }
}
