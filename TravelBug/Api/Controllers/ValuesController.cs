using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace DatingApp.API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class TripCardsController : ControllerBase
  {
    private readonly DataContext _context;
    public TripCardsController(DataContext context)
    {
      _context = context;

    }

    // GET api/values
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TripCard>>> Get()
    {
      var tripCards = await _context.TripCards.ToListAsync();
      return Ok(tripCards);
    }

    // GET api/values/5
    [HttpGet("{id}")]
    public async Task<ActionResult<TripCard>> Get(int id)
    {
      var tripCard = await _context.TripCards.FindAsync(id);
      return Ok(tripCard);
    }

    // POST api/values
    [HttpPost]
    public void Post([FromBody] string value)
    {
    }

    // PUT api/values/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/values/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
  }
}
