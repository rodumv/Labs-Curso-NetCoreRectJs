using api.Entities;
using Microsoft.EntityFrameworkCore;

namespace api.Context
{
  public class MovieInfoContext : DbContext
  {
    public DbSet<Movie> Movies { get; set; }

    public DbSet<Cast> Casts { get; set; }

    public MovieInfoContext(DbContextOptions<MovieInfoContext> options) : base(options)
    {
      //Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Movie>()
        .HasData(
          new Movie()
          {
            Id = 1,
            Name = "Pandillas de nueva york",
            Description = "Gangs of New York ye una película histórica del añu 2002 dirixida por Martin Scorsese"
          },
          new Movie()
          {
            Id = 2,
            Name = "Forrest Gump",
            Description = "Es un chico que sufre un cierto retraso mental. A pesar de todo, gracias a su tenacidad y a su buen corazón será protagonista de acontecimientos cruciales de su país"
          },
          new Movie()
          {
            Id = 3,
            Name = "Taxi Driver",
            Description = "Ambientada en la Nueva York de la década de 1970, poco después de que terminara la guerra de Vietnam, se centra en la vida de Travis Bickle, un excombatiente solitario e inestable que debido a su insomnio crónico comienza a trabajar como taxista,"
          }
        );

      modelBuilder.Entity<Cast>()
        .HasData(
          new Cast()
          {
            Id = 1,
            Name = "Daniel Day-Lewis",
            Character = "The Butcher",
            MovieId = 1
          },
          new Cast()
          {
            Id = 2,
            Name = "Leonardo DiCaprio",
            Character = "Amsterdam Vallon",
            MovieId = 1
          },
           new Cast()
           {
             Id = 3,
             Name = "Liam Neeson",
             Character = "Priest Vallon",
             MovieId = 1
           },
            new Cast()
            {
              Id = 4,
              Name = "Tom Hanks",
              Character = "Forrest Gump",
              MovieId = 2
            },
            new Cast()
            {
              Id = 5,
              Name = "Gary Sinise",
              Character = "Teniente Dan",
              MovieId = 2
            },
            new Cast()
            {
              Id = 6,
              Name = "Robin Wright",
              Character = "Jenny curran",
              MovieId = 2
            },
            new Cast()
            {
              Id = 7,
              Name = "Robert De Niro",
              Character = "Travis Bickle",
              MovieId = 3
            },
            new Cast()
            {
              Id = 8,
              Name = "Martin scorsese",
              Character = "Passenger",
              MovieId = 3
            },
            new Cast()
            {
              Id = 9,
              Name = "Jodie Foster",
              Character = "Iris",
              MovieId = 3
            }
          );

      base.OnModelCreating(modelBuilder);


    }
  }
}