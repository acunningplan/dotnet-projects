using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TravelBug.Context;
using TravelBug.Entities;
using System.Collections.Generic;
using TravelBug.Entities.UserData;
using System;
using System.Linq;
using TravelBug.Dtos;

namespace TravelBug.CrudServices
{
    public class BlogService : BaseService<Blog, BlogDto>, IBlogService
    {
        private readonly IMapper _mapper;

        public BlogService(TravelBugContext _travelBugContext, IMapper mapper) : base(_travelBugContext, mapper)
        {
            _mapper = mapper;
        }

        public async Task<List<BlogDto>> ReadManyAsync(AppUser user)
        {
            var followings = user.Followings;
            var blogs = new List<Blog>();
            foreach (var following in followings)
            {
                var followedUser = await _travelBugContext.Users.SingleOrDefaultAsync(u => u.UserName == following.Target.UserName);
                blogs.AddRange(followedUser.Blogs.Where(b => b.Deleted == null));
            }
            //blogs.Sort((x, y) => DateTimeOffset.Compare(y.Created, x.Created));

            return _mapper.Map<List<Blog>, List<BlogDto>>(blogs);
        }

        public List<BlogDto> ReadOwnAsync(AppUser user)
        {
            var blogs = user.Blogs.Where(b => b.Deleted == null).ToList();

            blogs.Sort((x, y) => DateTimeOffset.Compare(y.Created, x.Created));

            return _mapper.Map<List<Blog>, List<BlogDto>>(blogs);
        }

        //public override async Task<BlogDto> CreateAsync(Blog blog)
        //{
        //    return await base.CreateAsync(blog);
        //}
    }
}
