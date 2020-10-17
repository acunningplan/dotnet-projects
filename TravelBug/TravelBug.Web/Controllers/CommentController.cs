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
using TravelBug.Services.Comments;
using TravelBug.Web.Controllers;



namespace TravelBug.Controllers
{
  [Route("api/comment")]
  public class CommentController : CrudController<Comment, CommentDto>
  {
    private readonly ICommentService _commentService;
    private readonly IUserAccessor _userAccessor;

    public CommentController(ICommentService commentService, IUserAccessor userAccessor) : base(commentService)
    {
      _commentService = commentService;
      _userAccessor = userAccessor;
    }

    // Create, edit, delete
    [HttpPost("{blogId}")]
    public async Task<IActionResult> CreateAsync(Comment comment, string blogId)
    {
      var user = await _userAccessor.GetCurrentAppUser();
      comment.Author = user;
      var commentDto = await _commentService.CreateAsync(comment, blogId);
      if (commentDto == null) return NotFound();
      return Ok(commentDto);
    }

    // Override endpoints in CrudController
    [Authorize(Policy = "IsCommentAuthor")]
    [HttpPatch("{commentId:Guid}")]
    public override Task<IActionResult> UpdatePartialAsync(Guid commentId, [FromBody] JsonPatchDocument<Comment> patchEntity)
    {
      return base.UpdatePartialAsync(commentId, patchEntity);
    }

    [Authorize(Policy = "IsCommentAuthor")]
    [HttpDelete("{blogId}/{commentId}")]
    public async Task<IActionResult> DeleteAsync(string commentId, string blogId)
    {
      await _commentService.DeleteAsync(commentId, blogId);
      return Ok();
    }


    // // Override endpoints in CrudController
    // [HttpPost]
    // public override async Task<IActionResult> CreateAsync(Blog blog)
    // {
    //   var user = await _userAccessor.GetCurrentAppUser();
    //   var returnedBlog = await _blogService.CreateAsync(user, blog);
    //   return Ok(returnedBlog);
    // }
  }

}