using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.TripCards
{
  public class List
  {
    public class Query : IRequest<List<TripCard>> { }
    public class Handler : IRequestHandler<Query, List<TripCard>>
    {
      private readonly DataContext _context;
      public Handler(DataContext context)
      {
        _context = context;

      }

      public async Task<List<TripCard>> Handle(Query request, CancellationToken cancellationToken)
      {
        var tripCards = await _context.TripCards.ToListAsync();
        return tripCards;
      }
    }
  }
}