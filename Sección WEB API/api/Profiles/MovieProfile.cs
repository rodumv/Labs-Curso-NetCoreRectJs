using api.Entities;
using api.Models;
using AutoMapper;

namespace api.Profiles
{
  public class MovieProfile : Profile
  {
    public MovieProfile()
    {
      CreateMap<Movie, MovieDto>();
      CreateMap<Movie, MovieWithoutCastDto>();
    }
  }
}