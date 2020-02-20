using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Errors;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.TripCards
{
    public class Details
    {
        public class Query : IRequest<TripCardDto>
        {
            public Guid Id { get; set; }
        }
        public class Handler : IRequestHandler<Query, TripCardDto>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<TripCardDto> Handle(Query request, CancellationToken cancellationToken)
            {
                var tripCard = await _context.TripCards
                  // .Include(tc => tc.UserTripCard)
                  // .ThenInclude(utc => utc.AppUser)
                  .SingleOrDefaultAsync(x => x.Id == request.Id);

                if (tripCard == null)
                    throw new RestException(HttpStatusCode.NotFound, new { tripCard = "Not found." });

                return _mapper.Map<TripCard, TripCardDto>(tripCard);
            }
        }
    }

}