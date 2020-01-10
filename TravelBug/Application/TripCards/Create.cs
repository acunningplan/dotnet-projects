using System;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistence;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using FluentValidation;

namespace Application.TripCards
{
  public class Create
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
        var tripCard = new TripCard
        {
          Id = request.Id,
          Date = request.Date,
          Name = request.Name,
          Description = request.Description,
        };
        
        
        _context.TripCards.Add(tripCard);
        var success = await _context.SaveChangesAsync() > 0;

        if (success) return Unit.Value;

        throw new Exception("Problem saving changes");
      }
    }
  }
}