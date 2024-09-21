using Microsoft.AspNetCore.Mvc;
using WebPlenoCliente.Application.DTO;
using WebPlenoCliente.Application.Services.Cliente;

namespace WebPlenoCliente.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClienteDTO>>> GetClientes()
        {
            var clientes = await _clienteService.BuscarClientesAsync();
            return Ok(clientes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ClienteDTO>> GetCliente(int id)
        {
            var cliente = await _clienteService.BuscarClientePorIdAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return Ok(cliente);
        }

        [HttpPost]
        public async Task<ActionResult<ClienteDTO>> PostCliente(ClienteDTO cliente)
        {
            var novoCliente = await _clienteService.AdicionarClienteAsync(cliente);
            return CreatedAtAction(nameof(GetCliente), new { id = novoCliente.ID }, novoCliente);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCliente(int id, ClienteDTO cliente)
        {
            if (id != cliente.ID)
            {
                return BadRequest();
            }

            await _clienteService.AlterarClienteAsync(cliente);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente(int id)
        {
            await _clienteService.DeletarClienteAsync(id);
            return NoContent();
        }
    }
}
