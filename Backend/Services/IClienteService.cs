using Backend.Models;

namespace Backend.Services
{
  public interface IClienteService
  {
    Task<Cliente?> GetClientePorCpf(string cpf);
    Task<Pesquisa> RegistrarPesquisa(string cpf);
  }
}
