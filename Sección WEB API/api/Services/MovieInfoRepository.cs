using System;
using System.Collections.Generic;
using System.Linq;
using api.Context;
using api.Entities;
using Microsoft.EntityFrameworkCore;

namespace api.Services
{
  public class MovieInfoRepository : IMovieInfoRepository
  {
    private MovieInfoContext _context;

    public MovieInfoRepository(MovieInfoContext context)
    {
      _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public Cast GetCastByMovie(int movieId, int castId)
    {
      return _context.Casts
           .Where(x => x.MovieId == movieId && x.Id == castId).FirstOrDefault();
    }

    public IEnumerable<Cast> GetCastsByMovie(int movieId)
    {
      return _context.Casts
          .Where(x => x.MovieId == movieId).ToList();
    }

    public Movie GetMovie(int movieId, bool includeCast)
    {
      if (includeCast)
      {
        return _context.Movies.Include(c => c.Casts)
                .Where(x => x.Id == movieId).FirstOrDefault();
      }

      return _context.Movies
                    .Where(x => x.Id == movieId).FirstOrDefault();

    }

    public IEnumerable<Movie> GetMovies()
    {
      return _context.Movies.OrderBy(m => m.Name).ToList();
    }

    public bool MovieExists(int movieId) => _context.Movies.Any(x => x.Id == movieId);

    public void AddCastForMovie(int movieId, Cast cast)
    {
      var movie = GetMovie(movieId, false);

      movie.Casts.Add(cast);

    }


    public bool Save() => _context.SaveChanges() > 0;

    public void UpdateCastForMovie(int movieId, Cast cast)
    {

    }

    public void DeleteCast(Cast cast)
    {
      _context.Casts.Remove(cast);
    }
  }
}