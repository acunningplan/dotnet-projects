using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TravelBug.CrudServices;
using TravelBug.Entities;
using TravelBug.Web.Controllers;

namespace TravelBug.Controllers
{
    [Route("api/blog")]
    public class BlogController : CrudController<Blog>
    {
        public BlogController(IBlogService blogService) : base(blogService)
        {
        }

        //private readonly ILogger<BlogController> _logger;

        //public BlogController(ILogger<BlogController> logger)
        //{
        //    _logger = logger;
        //}

        //[HttpGet]
        //public IEnumerable<Blog> Get()
        //{
        //    var rng = new Random();
        //    return Enumerable.Range(1, 5).Select(index => new Blog
        //    {
        //    })
        //    .ToArray();
        //}

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
