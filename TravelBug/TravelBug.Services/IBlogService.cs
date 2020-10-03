using System.Collections.Generic;
using System.Threading.Tasks;
using TravelBug.Dtos;
using TravelBug.Entities;
using TravelBug.Entities.UserData;

namespace TravelBug.CrudServices
{
    public interface IBlogService : IBaseService<Blog, BlogDto>
    {
        Task<List<BlogDto>> ReadManyAsync(AppUser user);
        List<BlogDto> ReadOwnAsync(AppUser user);
    }
}
