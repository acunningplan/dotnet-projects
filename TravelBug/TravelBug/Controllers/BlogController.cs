using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TravelBug.CrudServices;
using TravelBug.Entities;
using TravelBug.Web.Controllers;

namespace TravelBug.Controllers
{
    [Route("api/blog")]
    public class BlogController : CrudController<Blog, BlogDto>
    {
        public BlogController(IBlogService blogService) : base(blogService)
        {
        }

        public override async Task<IActionResult> ReadAsync(Guid id)
        {
            var blog = await _service.ReadAsync(id);

            if (blog == null) return NotFound();

            return Ok(blog);
        }

        [Authorize(Policy = "IsBlogAuthor")]
        public override Task<IActionResult> UpdatePartialAsync(Guid id, [FromBody] JsonPatchDocument<Blog> patchEntity)
        {
            return base.UpdatePartialAsync(id, patchEntity);
        }

        [Authorize(Policy = "IsBlogAuthor")]
        public override Task<IActionResult> DeleteAsync(Guid id)
        {
            return base.DeleteAsync(id);
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
