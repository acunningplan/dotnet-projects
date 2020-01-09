using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Persistence;

namespace Application.TripCards
{
  public class Edit
  {
    public class Command : IRequest
    {
      public Guid Id { get; set; }
      public DateTime Date { get; set; }
      public string Name { get; set; }
      public string Description { get; set; }
    }

    public class Handler : IRequestHandler<Command>
    {
      private readonly DataContext _context;
      public Handler(DataContext context)
      {
        _context = context;
      }

      public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
      {
        var tripCard = await _context.TripCards.FindAsync(request.Id);

        if (tripCard == null) throw new Exception("Could not find activity.");


        tripCard.Id = request.Id;
        tripCard.Date = request.Date;
        tripCard.Name = request.Name;
        tripCard.Description = request.Description;
        
        var success = await _context.SaveChangesAsync() > 0;

        if (success) return Unit.Value;

        throw new Exception("Problem saving changes");
      }
    }
  }
}