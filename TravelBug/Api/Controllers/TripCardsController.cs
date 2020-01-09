using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.TripCards;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DatingApp.API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class TripCardsController : ControllerBase
  {
    private readonly IMediator _mediator;
    public TripCardsController(IMediator mediator)
    {
      _mediator = mediator;

    }

    [HttpGet]
    public async Task<ActionResult<List<TripCard>>> List()
    {
      return await _mediator.Send(new List.Query());
      // var tripCards = await _context.TripCards.ToListAsync();
      // return Ok(tripCards);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<TripCard>> Details(Guid id)
    {
      return await _mediator.Send(new Details.Query{Id = id});
    }

    [HttpPost]
    public async Task<ActionResult<Unit>> Create(Create.Command command)
    {
      return await _mediator.Send(command);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Unit>> Edit(Guid id, Edit.Command command)
    {
      command.Id = id;
      return await _mediator.Send(command);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Unit>> Delete(Guid id)
    {
      return await _mediator.Send(new Delete.Command{Id = id});
    }

    // [HttpPut("{id}")]
    // public void Put(int id, [FromBody] string value)
    // {
    // }

    // [HttpDelete("{id}")]
    // public void Delete(int id)
    // {
    // }
  }
}
