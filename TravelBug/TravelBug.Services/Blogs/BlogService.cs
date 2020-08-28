using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TravelBug.Infrastructure;
using TravelBug.Context;
using TravelBug.Entities;

namespace TravelBug.CrudServices
{
    public class BlogService : BaseService<Blog, BlogDto>, IBlogService
    {
        private readonly IUserAccessor _userAccessor;

        public BlogService(TravelBugContext _travelBugContext, IUserAccessor userAccessor, IMapper mapper) : base(_travelBugContext, mapper)
        {
            _userAccessor = userAccessor;
        }

        public override async Task<BlogDto> CreateAsync(Blog entity)
        {
            var userName = _userAccessor.GetCurrentUsername();
            entity.User = await _travelBugContext.Users.SingleOrDefaultAsync(u => u.UserName == userName);
            return await base.CreateAsync(entity);
        }
    }
}
