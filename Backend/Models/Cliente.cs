using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
  public class Cliente
  {
    [Key]
    public string Id { get; set; }
    public string Cpf { get; set; }

    public string Nome { get; set; }
    public string Email { get; set; }
    public string Endereco { get; set; }
    public string Cidade { get; set; }
    public string Estado { get; set; }
    public string Cep { get; set; }
    public string Telefone { get; set; }
  }
}
