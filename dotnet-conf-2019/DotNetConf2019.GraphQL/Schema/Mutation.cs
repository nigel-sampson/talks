using DotNetConf2019.GraphQL.Data;
using HotChocolate;
using NodaTime;
using System;
using System.Threading.Tasks;

namespace DotNetConf2019.GraphQL.Schema
{
    public class Mutation
    {
        private readonly IClock clock;

        public Mutation(IClock clock)
        {
            this.clock = clock;
        }

        public async Task<Post> SubmitPost([Service] BlogDbContext dbContext, SubmitPostInput input)
        {
            var post = new Post
            {
                AuthorId = input.AuthorId,
                Title = input.Title,
                Markdown = input.Markdown,
                PublishedOn = clock.GetCurrentInstant().WithOffset(Offset.Zero)
            };

            dbContext.Posts.Add(post);

            try
            {
                await dbContext.SaveChangesAsync();
            }
            catch(Exception ex)
            {

            }
            

            return post;
        }
    }
}
