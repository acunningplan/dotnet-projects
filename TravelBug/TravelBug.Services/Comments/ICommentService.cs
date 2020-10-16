using System.Threading.Tasks;
using TravelBug.CrudServices;
using TravelBug.Dtos;
using TravelBug.Entities;
using TravelBug.Entities.UserData;

namespace TravelBug.Services.Comments
{
  public interface ICommentService : IBaseService<Comment, CommentDto>
  {
    Task<CommentDto> CreateAsync(Comment comment, string blogId);
    Task DeleteAsync(string commentId, string blogId);
  }
}