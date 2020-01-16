using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.TripCards
{
  public class List
  {
    public class Query : IRequest<List<TripCardDto>> { }
    public class Handler : IRequestHandler<Query, List<TripCardDto>>
    {
      private readonly DataContext _context;
      private readonly IMapper _mapper;

      public Handler(DataContext context, IMapper mapper)
      {
        _context = context;
        _mapper = mapper;

      }

      public async Task<List<TripCardDto>> Handle(Query request, CancellationToken cancellationToken)
      {
        var tripCards = await _context.TripCards
          // .Include(tc => tc.UserTripCard)
          // .ThenInclude(utc => utc.AppUser)
          // .ThenInclude(au => au.Photos)
          .ToListAsync();

        return _mapper.Map<List<TripCard>, List<TripCardDto>>(tripCards);
      }
    }
  }
}