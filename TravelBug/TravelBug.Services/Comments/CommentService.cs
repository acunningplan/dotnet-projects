using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using TravelBug.Context;
using TravelBug.CrudServices;
using TravelBug.Dtos;
using TravelBug.Entities;
using TravelBug.Entities.UserData;

namespace TravelBug.Services.Comments
{
  public class CommentService : BaseService<Comment, CommentDto>, ICommentService
  {
    public CommentService(TravelBugContext travelBugContext, IMapper mapper) : base(travelBugContext, mapper)
    {

    }

    public async Task<CommentDto> CreateAsync(Comment comment, string blogId)
    {
      var blog = await _travelBugContext.Blogs.FindAsync(Guid.Parse(blogId)) ??
          throw new RestException(HttpStatusCode.NotFound, "Blog not found.");

      blog.Comments.Add(comment);
      await _travelBugContext.SaveChangesAsync();
      return _mapper.Map<Comment, CommentDto>(comment);
    }

    public async Task DeleteAsync(string commentId, string blogId)
    {
      var blog = await _travelBugContext.Blogs.FindAsync(Guid.Parse(blogId)) ??
          throw new RestException(HttpStatusCode.NotFound, "Blog not found.");

      var comment = blog.Comments.ToList().SingleOrDefault(c => c.Id == Guid.Parse(commentId)) ??
          throw new RestException(HttpStatusCode.NotFound, "Comment not found.");

      await base.DeleteAsync(Guid.Parse(commentId));
    }
  }
}