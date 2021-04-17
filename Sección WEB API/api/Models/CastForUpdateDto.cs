using System.ComponentModel.DataAnnotations;

namespace api.Models
{
  public class CastForUpdateDto
  {
    [Required(ErrorMessage = "Nombre es requerido")]
    [MaxLength(50, ErrorMessage = "Maximo 50")]
    public string Name { get; set; }
    [MaxLength(50, ErrorMessage = "Maximo 50")]
    public string Character { get; set; }
  }
}