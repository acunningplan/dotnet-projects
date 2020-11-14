using FunFacts.Context;
using FunFacts.Entities;
using FunFacts.FunFactServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FunFacts.Web.Controllers
{
    [Route("api/fun-fact")]
    public class FunFactController : ControllerBase
    {
        private readonly IFunFactService _service;

        public FunFactController(IFunFactService service)
        {
            _service = service;
        }

        // Need to specify topic id
        [HttpPost]
        public async Task AddFunFact(FunFact funFact)
        {
            await _service.AddFunFact(funFact);
        }
    }
}
