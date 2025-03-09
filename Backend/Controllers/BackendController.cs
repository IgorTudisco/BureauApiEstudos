using Backend.Models;
using Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/clientes")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        // Buscar cliente por CPF
        [HttpGet("{cpf}")]
        public async Task<IActionResult> GetCliente(string cpf)
        {
            var cliente = await _clienteService.GetClientePorCpf(cpf);
            return cliente is not null ? Ok(cliente) : NotFound();
        }

        // Registrar pesquisa de CPF
        [HttpPost("pesquisa")]
        public async Task<IActionResult> RegistrarPesquisa([FromBody] PesquisaRequest request)
        {
            var pesquisa = await _clienteService.RegistrarPesquisa(request.Cpf);
            return Ok(pesquisa);
        }
    }
}
