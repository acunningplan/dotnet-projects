using AutoMapper;
using Domain;

namespace Application.TripCards
{
  public class MappingProfile : Profile
  {
    public MappingProfile()
    {
      CreateMap<TripCard, TripCardDto>();
    }
  }
}