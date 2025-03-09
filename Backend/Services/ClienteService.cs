using Backend.Data;
using Backend.Models;
using Backend.Models.Requests;
using Backend.Models.Responses;

namespace Backend.Services
{
  public class ClienteService
  {
    private readonly BackendDbContext _context;

    public ClienteService(BackendDbContext context)
    {
      _context = context;
    }

    public ClienteResponse Create(ClienteRequest clienteRequest)
    {
      var cliente = ClienteConverter(clienteRequest);
      _context.Clientes.Add(cliente);
      _context.SaveChanges();

      var ClienteResponse = ClienteConverter(cliente);
      return ClienteResponse;
    }

    public ClienteResponse? Update(ClienteRequest clienteRequest, int id)
    {
      var cliente = _context.Clientes.Find(id);

      if (clienteRequest == null && cliente == null)
      {
        return null;
      }

      cliente!.Cpf = clienteRequest!.Cpf;
      cliente!.Nome = clienteRequest!.Nome;
      cliente!.Email = clienteRequest!.Email;
      cliente!.Endereco = clienteRequest!.Endereco;
      cliente!.Cidade = clienteRequest!.Cidade;
      cliente!.Estado = clienteRequest!.Estado;
      cliente!.Cep = clienteRequest!.Cep;
      cliente!.Telefone = clienteRequest!.Telefone;

      _context.Clientes.Update(cliente);
      _context.SaveChanges();
      var ClienteResponse = ClienteConverter(cliente);
      return ClienteResponse;
    }

    public void Delete(int id)
    {
      var cliente = _context.Clientes.Find(id);
      _context.Clientes.Remove(cliente);
      _context.SaveChanges();
    }

    public Cliente Get(int id)
    {
      return _context.Clientes.Find(id);
    }

    public IEnumerable<ClienteResponse> GetAll()
    {
      var clientes = _context.Clientes.ToList();
      List<ClienteResponse> clientesResponse = new List<ClienteResponse>();

      foreach (var cliente in clientes)
      {
        var clienteResponse = ClienteConverter(cliente);
        clientesResponse.Add(clienteResponse);
      }

      return clientesResponse;
    }

    public Cliente ClienteConverter(ClienteRequest clienteRequest)
    {
      return new Cliente
      {
        Cpf = clienteRequest.Cpf,
        Nome = clienteRequest.Nome,
        Email = clienteRequest.Email,
        Endereco = clienteRequest.Endereco,
        Cidade = clienteRequest.Cidade,
        Estado = clienteRequest.Estado,
        Cep = clienteRequest.Cep,
        Telefone = clienteRequest.Telefone
      };
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


  }
}
