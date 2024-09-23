using AutoMapper;
using WebPlenoCliente.Application.DTO;
using WebPlenoCliente.Application.ServicosExternos;
using WebPlenoCliente.Domain.Entidades;
using WebPlenoCliente.Domain.Interfaces;

namespace WebPlenoCliente.Application.Services.EnderecoService
{
    public class EnderecoService : IEnderecoService
    {
        private readonly IEnderecoRepository _enderecoRepository;
        private readonly IMapper _mapper;
        private readonly IApiViaCEP _apiViaCEP;

        public EnderecoService(IEnderecoRepository enderecoRepository, IMapper mapper, IApiViaCEP apiViaCEP)
        {
            _enderecoRepository = enderecoRepository;
            _mapper = mapper;
            _apiViaCEP = apiViaCEP;
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

        public async Task<IEnumerable<EnderecoDTO>> BuscarEnderecosAsync()
        {
            return _mapper.Map<IEnumerable<EnderecoDTO>>(await _enderecoRepository.BuscarEnderecosAsync());
        }

        public async Task<EnderecoDTO> AdicionarEnderecoAsync(EnderecoDTO enderecoDto)
        {
            var enderecoMapeadoAPI = new Endereco();

            if (!await _enderecoRepository.EnderecoExisteAsync(_mapper.Map<Endereco>(enderecoDto)))
            {
                var enderecoAPI = await _apiViaCEP.ConsultarEnderecoAsync(enderecoDto.CEP);

                enderecoMapeadoAPI = _mapper.Map<Endereco>(enderecoAPI);
            }

            var novoEndereco = await _enderecoRepository.AdicionarEnderecoAsync(_mapper.Map<Endereco>(enderecoDto));
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
