using System;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistence;

namespace Application.TripCards
{
  public class Details
  {
    public class Query : IRequest<TripCard>
    {
      public Guid Id { get; set; }
    }
    public class Handler : IRequestHandler<Query, TripCard>
    {
      private readonly DataContext _context;

      public Handler(DataContext context)
      {
        _context = context;

      }

      public async Task<TripCard> Handle(Query request, CancellationToken cancellationToken)
      {
        var tripCard = await _context.TripCards.FindAsync(request.Id);
        
        return tripCard;
      }
    }
  }

}