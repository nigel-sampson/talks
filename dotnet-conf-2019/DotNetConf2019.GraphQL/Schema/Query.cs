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
        public async Task<IReadOnlyList<Post>> GetPosts([Service] BlogDbContext dbContext) =>
            await dbContext.Posts
                .OrderByDescending(p => p.PublishedOn)
                .ToListAsync();

        public async Task<IReadOnlyList<Author>> GetAuthors([Service] BlogDbContext dbContext) => 
            await dbContext.Authors.ToListAsync();

        public async Task<IReadOnlyList<Image>> GetImages([Service] BlogDbContext dbContext) =>
            await dbContext.Images.ToListAsync();

        public Task<Post> GetPost([Service] BlogDbContext dbContext, int id) => dbContext.Posts.FindAsync(id);
    }
}
