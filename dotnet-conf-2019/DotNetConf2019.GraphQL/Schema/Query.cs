using DotNetConf2019.GraphQL.Data;
using HotChocolate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetConf2019.GraphQL.Schema
{
    public class Query
    {
        public async Task<IReadOnlyList<Post>> GetPosts([Service] BlogDbContext dbContext)
        {
            return await dbContext.Posts
                .OrderByDescending(p => p.PublishedOn)
                .ToListAsync();
        }

        public Task<Post> GetPost([Service] BlogDbContext dbContext, int id) => dbContext.Posts.FindAsync(id);
    }
}
