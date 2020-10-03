using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TravelBug.CrudServices;
using TravelBug.Dtos;
using TravelBug.Entities;
using TravelBug.Infrastructure;
using TravelBug.Web.Controllers;

namespace TravelBug.Controllers
{
    [Route("api/blog")]
    public class BlogController : CrudController<Blog, BlogDto>
    {
        private readonly IBlogService _blogService;
        private readonly IUserAccessor _userAccessor;

        public BlogController(IBlogService blogService, IUserAccessor userAccessor) : base(blogService)
        {
            _blogService = blogService;
            _userAccessor = userAccessor;
        }

        // Get the blogs of people that the user are following
        [HttpGet]
        public async Task<List<BlogDto>> GetBlogs()
        {
            var user = await _userAccessor.GetCurrentAppUser();
            var blogsToReturn = await _blogService.ReadManyAsync(user);
            return blogsToReturn;
        }

        // Get the user's own blogs
        [HttpGet("user")]
        public async Task<List<BlogDto>> GetOwnBlogs()
        {
            var user = await _userAccessor.GetCurrentAppUser();
            var blogsToReturn = _blogService.ReadOwnAsync(user);
            return blogsToReturn;
        }

        // Get the another user's blogs
        [HttpGet("user/{username}")]
        public async Task<List<BlogDto>> GetUserBlogs(string username)
        {
            var user = await _userAccessor.GetAppUser(username);
            var blogsToReturn = _blogService.ReadOwnAsync(user);
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
