using System;
using System.Collections.Generic;
using System.Text;
using TravelBug.Context;
using TravelBug.Entities;

namespace TravelBug.CrudServices
{
    public class BlogService : BaseService<Blog>, IBlogService
    {
        public BlogService(TravelBugContext _travelBugContext) : base(_travelBugContext) { }
    }
}
