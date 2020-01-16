using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Errors;
using FluentValidation;
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

    public class CommandValidator : AbstractValidator<Command>
    {
      public CommandValidator()
      {
        RuleFor(x => x.Date).NotEmpty();
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Description).NotEmpty();
      }
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

        if (tripCard == null) throw new RestException(HttpStatusCode.NotFound, new
        {
          tripCard = "Could not find activity"
        });

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