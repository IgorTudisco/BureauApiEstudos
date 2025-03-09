using Backend.Data;
using Backend.Models;
using Backend.Models.Responses;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services
{
  public class PesquisaService
  {
    private readonly BackendDbContext _context;

    public PesquisaService(BackendDbContext context)
    {
      _context = context;
    }

    public async Task<ClienteResponse?> GetClientePorCpf(string cpf)
    {
      Cliente? cliente = await _context.Clientes.FirstOrDefaultAsync(c => c.Cpf == cpf);
      if (cliente is null)
      {
        return null;
      }

      var pesquisa = new Pesquisa
      {
        CpfPesquisado = cpf,
        DataPesquisa = DateTime.UtcNow
      };

      _context.Pesquisas.Add(pesquisa);
      _context.SaveChanges();

      var clienteResponse = ClienteConverter(cliente);

      return clienteResponse;

    }

    public ClienteResponse ClienteConverter(Cliente cliente)
    {
      return new ClienteResponse
      {
        Cpf = cliente.Cpf,
        Nome = cliente.Nome,
        Email = cliente.Email,
        Endereco = cliente.Endereco,
        Cidade = cliente.Cidade,
        Estado = cliente.Estado,
        Cep = cliente.Cep,
        Telefone = cliente.Telefone
      };
    }

    public async Task<IEnumerable<PesquisaResponse>> GetAllPesquisas()
    {
      var pesquisas = await _context.Pesquisas.ToListAsync();
      List<PesquisaResponse> pesquisasResponse = new List<PesquisaResponse>();

      foreach (var pesquisa in pesquisas)
      {
        var pesquisaResponse = PesquisaConverter(pesquisa);
        pesquisasResponse.Add(pesquisaResponse);
      }

      return pesquisasResponse;
    }

    public PesquisaResponse PesquisaConverter(Pesquisa pesquisa)
    {
      return new PesquisaResponse
      {
        Cpf = pesquisa.CpfPesquisado,
        DataPesquisa = pesquisa.DataPesquisa
      };
    }

  }
}
