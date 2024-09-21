using Microsoft.AspNetCore.Mvc;
using WebPlenoCliente.Application.DTO;
using WebPlenoCliente.Application.Services.EnderecoService;

namespace WebPlenoCliente.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnderecoController : ControllerBase
    {
        private readonly IEnderecoService _enderecoService;

        public EnderecoController(IEnderecoService enderecoService)
        {
            _enderecoService = enderecoService;
        }

        [HttpGet("cliente/{clienteId}")]
        public async Task<ActionResult<IEnumerable<EnderecoDTO>>> GetEnderecosPorCliente(int clienteId)
        {
            var enderecos = await _enderecoService.BuscarEnderecosPorClienteAsync(clienteId);
            return Ok(enderecos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EnderecoDTO>> GetEndereco(int id)
        {
            var endereco = await _enderecoService.BuscarEnderecoPorIdAsync(id);
            if (endereco == null)
            {
                return NotFound();
            }
            return Ok(endereco);
        }

        [HttpPost]
        public async Task<ActionResult<EnderecoDTO>> PostEndereco(EnderecoDTO endereco)
        {
            var novoEndereco = await _enderecoService.AdicionarEnderecoAsync(endereco);
            return CreatedAtAction(nameof(GetEndereco), new { id = novoEndereco.ID }, novoEndereco);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutEndereco(int id, EnderecoDTO endereco)
        {
            if (id != endereco.ID)
            {
                return BadRequest();
            }

            await _enderecoService.AlterarEnderecoAsync(endereco);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEndereco(int id)
        {
            await _enderecoService.DeletarEnderecoAsync(id);
            return NoContent();
        }
    }
}
