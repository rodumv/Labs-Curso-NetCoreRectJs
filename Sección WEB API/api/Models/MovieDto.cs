using System.Collections.Generic;

namespace api.Models
{
  public class MovieDto
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    public ICollection<CastDto> Casts { get; set; } = new List<CastDto>();
  }
}