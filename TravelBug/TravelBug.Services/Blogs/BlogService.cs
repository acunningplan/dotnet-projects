using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TravelBug.Infrastructure;
using TravelBug.Context;
using TravelBug.Entities;
using System.Collections.Generic;
using TravelBug.Entities.UserData;
using System;

namespace TravelBug.CrudServices
{
    public class BlogService : BaseService<Blog, BlogDto>, IBlogService
    {
        private readonly IUserAccessor _userAccessor;
        private readonly IMapper _mapper;

        public BlogService(TravelBugContext _travelBugContext, IUserAccessor userAccessor, IMapper mapper) : base(_travelBugContext, mapper)
        {
            _userAccessor = userAccessor;
            _mapper = mapper;
        }

        private async Task<AppUser> GetUser()
        {
            var userName = _userAccessor.GetCurrentUsername();
            return await _travelBugContext.Users.SingleOrDefaultAsync(u => u.UserName == userName);
        }

        public async Task<List<BlogDto>> ReadManyAsync()
        {
            var followings = (await GetUser()).Followings;
            var blogs = new List<Blog>();
            foreach (var following in followings)
            {
                var followedUser = await _travelBugContext.Users.SingleOrDefaultAsync(u => u.Id == following.TargetId);
                blogs.AddRange(followedUser.Blogs);
            }
            blogs.Sort((x, y) => DateTimeOffset.Compare(y.Created, x.Created));

            return _mapper.Map<List<Blog>, List<BlogDto>>(blogs);
        }

        public override async Task<BlogDto> CreateAsync(Blog blog)
        {
            blog.User = await GetUser();
            return await base.CreateAsync(blog);
        }
    }
}
