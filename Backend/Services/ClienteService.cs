using Backend.Data;
using Backend.Models;

namespace Backend.Services
{
  public class ClienteService : IClienteService
  {
    private readonly BackendDbContext _context;

    public ClienteService(BackendDbContext context)
    {
      _context = context;
    }

    public async Task<Cliente?> GetClientePorCpf(string cpf)
    {
      return await _context.Clientes.FindAsync(cpf);
    }

    public async Task<Pesquisa> RegistrarPesquisa(string cpf)
    {
      var pesquisa = new Pesquisa
      {
        CpfPesquisado = cpf,
        DataPesquisa = DateTime.UtcNow
      };

      _context.Pesquisas.Add(pesquisa);
      await _context.SaveChangesAsync();

      return pesquisa;
    }
  }
}
