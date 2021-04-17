using System.Collections.Generic;
using api.Models;

namespace api
{
  public class MoviesDataStore
  {
    public static MoviesDataStore Current { get; } = new MoviesDataStore();
    public List<MovieDto> Movies { get; set; }
    public MoviesDataStore() => Movies = new List<MovieDto>(){
                    new MovieDto(){
                        Id = 1,
                        Name = "Pandillas de nueva york",
                        Description = "Gangs of New York ye una película histórica del añu 2002 dirixida por Martin Scorsese",
                        Casts  = new List<CastDto>() {
                            new CastDto { Id = 1, Name = "Daniel Day-Lewis",  Character = "The Butcher"},
                            new CastDto { Id = 2, Name = "Leonardo DiCaprio",  Character = "Amsterdam Vallon"},
                            new CastDto { Id = 3, Name = "Liam Neeson",  Character = "Priest Vallon"},
                        }
                    },
                    new MovieDto(){
                        Id = 2,
                        Name = "Forrest Gump",
                        Description = "Es un chico que sufre un cierto retraso mental. A pesar de todo, gracias a su tenacidad y a su buen corazón será protagonista de acontecimientos cruciales de su país",
                        Casts  = new List<CastDto>() {
                            new CastDto { Id = 1, Name = "Tom Hanks",  Character = "Forrest Gump"},
                            new CastDto { Id = 2, Name = "Gary Sinise",  Character = "Teniente Dan"},
                            new CastDto { Id = 3, Name = "Robin Wright",  Character = "Jenny curran"},
                        }

                    },
                    new MovieDto(){
                        Id = 3,
                        Name = "Taxi Driver",
                        Description = "mbientada en la Nueva York de la década de 1970, poco después de que terminara la guerra de Vietnam, se centra en la vida de Travis Bickle, un excombatiente solitario e inestable que debido a su insomnio crónico comienza a trabajar como taxista,",
                         Casts  = new List<CastDto>() {
                            new CastDto { Id = 1, Name = "Robert De Niro",  Character = "Travis Bickle"},
                            new CastDto { Id = 2, Name = "Martin scorsese",  Character = "Passenger"},
                            new CastDto { Id = 3, Name = "Jodie Foster",  Character = "Iris"},
                        }
                    },

                };

  }
}