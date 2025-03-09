using Backend.Models;
using Backend.Models.Requests;
using Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/clientes")]
    public class ClienteController : ControllerBase
    {
        private readonly ClienteService _clienteService;

        public ClienteController(ClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpPost]
        public IActionResult PostCliente([FromBody] ClienteRequest clienteRequest)
        {
            var clienteResponse = _clienteService.Create(clienteRequest);
            return Ok(clienteResponse);
        }

        [HttpPut("/{id}")]
        public IActionResult UpdateCliente([FromBody] ClienteRequest clienteRequest, [FromRoute] int id)
        {
            var clienteResponse = _clienteService.Update(clienteRequest, id);
            if (clienteResponse == null)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("/{id}")]
        public IActionResult DeleteCliente([FromRoute] int id)
        {
            _clienteService.Delete(id);
            return NoContent();
        }

        [HttpGet("/{id}")]
        public IActionResult GetCliente([FromRoute] int id)
        {
            var cliente = _clienteService.Get(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return Ok(cliente);
        }

        [HttpGet]
        public IActionResult GetClientes()
        {
            var clientes = _clienteService.GetAll();
            return Ok(clientes);
        }


    }
}
