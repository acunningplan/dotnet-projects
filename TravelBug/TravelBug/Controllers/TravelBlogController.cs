using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TravelBug.Entities;

namespace TravelBug.Controllers
{
    public class TravelBugController : BaseController
    {

        private readonly ILogger<TravelBugController> _logger;

        public TravelBugController(ILogger<TravelBugController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Blog> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new Blog
            {
            })
            .ToArray();
        }



        //[HttpPost]
        //public async Task CreateOrder(CreateCommand command)
        //{
        //    await _orderServices.CreateOrder(command);
        //}

        //[HttpPatch("edit")]
        //public async Task EditOrder(EditCommand command)
        //{
        //    await _orderServices.EditOrder(command);
        //}

        //[HttpPatch("change/{id}")]
        //public async Task ChangeOrderStatus(ChangeStatusCommand command, Guid id)
        //{
        //    await _orderServices.ChangeOrderStatus(command, id);
        //}
    }
}
