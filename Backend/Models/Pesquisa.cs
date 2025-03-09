using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
  public class Pesquisa
  {
    [Key]
    public int Id { get; set; }
    public string CpfPesquisado { get; set; } = string.Empty;
    public DateTime DataPesquisa { get; set; }
  }
}
