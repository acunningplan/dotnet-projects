using System.Collections.Generic;
using System.Threading.Tasks;
using TravelBug.Entities;

namespace TravelBug.CrudServices
{
  public interface IBlogService : IBaseService<Blog, BlogDto>
  {
    Task<List<BlogDto>> ReadManyAsync();
    Task<List<BlogDto>> ReadOwnAsync();
  }
}
