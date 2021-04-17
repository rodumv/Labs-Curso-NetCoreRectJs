using api.Entities;
using api.Models;
using AutoMapper;

namespace api.Profiles
{
  public class CastProfile : Profile
  {
    public CastProfile()
    {
      CreateMap<Cast, CastDto>();
      CreateMap<CastForCreationDto, Cast>();
      CreateMap<Cast, CastForCreationDto>();
      CreateMap<CastForUpdateDto, Cast>().ReverseMap();
    }

  }
}