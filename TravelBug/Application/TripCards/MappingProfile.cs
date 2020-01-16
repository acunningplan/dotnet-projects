using System.Linq;
using AutoMapper;
using Domain;

namespace Application.TripCards
{
  public class MappingProfile : Profile
  {

    public MappingProfile()
    {
      CreateMap<TripCard, TripCardDto>();
      CreateMap<UserTripCard, AuthorDto>()
        .ForMember(d => d.DisplayName, o => o.MapFrom(s => s.AppUser.DisplayName))
        .ForMember(d => d.MainPhotoUrl, o => o.MapFrom(s => s.AppUser.Photos.SingleOrDefault(p => p.IsMain).Url));
    }
  }
}