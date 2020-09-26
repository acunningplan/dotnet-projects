using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TravelBug.CrudServices;
using TravelBug.Entities;
using TravelBug.Web.Controllers;

namespace TravelBug.Controllers
{
  [Route("api/blog")]
  public class BlogController : CrudController<Blog, BlogDto>
  {
    private readonly IBlogService _blogService;
    public BlogController(IBlogService blogService) : base(blogService)
    {
      _blogService = blogService;
    }

    // Endpoints in addition to those in CrudController
    [HttpGet]
    public async Task<List<BlogDto>> GetBlogs()
    {
      var blogsToReturn = await _blogService.ReadManyAsync();
      return blogsToReturn;
    }

    [HttpGet("user")]
    public async Task<List<BlogDto>> GetOwnBlogs()
    {
        var blogsToReturn = await _blogService.ReadOwnAsync();
        return blogsToReturn;
    }

    // Override endpoints in CrudController
    [Authorize(Policy = "IsBlogAuthor")]
    [HttpPatch("{id:Guid}")]
    public override Task<IActionResult> UpdatePartialAsync(Guid id, [FromBody] JsonPatchDocument<Blog> patchEntity)
    {
      return base.UpdatePartialAsync(id, patchEntity);
    }

    [Authorize(Policy = "IsBlogAuthor")]
    [HttpDelete("{id:Guid}")]
    public override Task<IActionResult> DeleteAsync(Guid id)
    {
      return base.DeleteAsync(id);
    }
  }
}
