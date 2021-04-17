using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Entities
{
  public class Cast
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required()]
    [MaxLength(50)]
    public string Name { get; set; }

    [Required()]
    [MaxLength(50)]
    public string Character { get; set; }

    [ForeignKey("MovieId")]
    public Movie Movie { get; set; }

    public int MovieId { get; set; }

    public int? Age { get; set; }
  }
}