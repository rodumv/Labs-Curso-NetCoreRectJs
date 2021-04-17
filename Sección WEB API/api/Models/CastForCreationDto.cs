using System.ComponentModel.DataAnnotations;

namespace api.Models
{
  public class CastForCreationDto
  {
    public int Id { get; set; }
    [Required(ErrorMessage = "Nombre es requerido")]
    [MaxLength(50, ErrorMessage = "Maximo 50")]
    public string Name { get; set; }
    [Required(ErrorMessage = "Personaje es requerido")]
    [MaxLength(50, ErrorMessage = "Maximo 50")]
    public string Character { get; set; }
  }
}