using Backend.Models.Requests;
using Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
  [ApiController]
  [Route("api/pesquisa")]
  public class PesquisaController : ControllerBase
  {
    private readonly PesquisaService _pesquisaService;

    public PesquisaController(PesquisaService pesquisaService)
    {
      _pesquisaService = pesquisaService;
    }

    // Buscar Pesquisa por CPF
    [HttpGet("{cpf}")]
    public async Task<IActionResult> GetPesquisaClienteCpf([FromRoute] string cpf)
    {
      var Pesquisa = await _pesquisaService.GetClientePorCpf(cpf);

      return Pesquisa is not null ? Ok(Pesquisa) : NotFound();
    }

    [HttpGet]
    public async Task<IActionResult> GetPesquisas()
    {
      var Pesquisas = await _pesquisaService.GetAllPesquisas();

      return Ok(Pesquisas);
    }

  }
}
