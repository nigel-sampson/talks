using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DotNetConf2019.GraphQL.Data
{
    public class BlogDbContext : DbContext
    {
        private IConfiguration _config;
        public BlogDbContext(IConfiguration config)
        {
            _config = config;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_config.GetConnectionString("IdentityConnection"));
        }

        public DbSet<Post> Posts { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Author> Authors { get; set; }

        public DbSet<Image> Images { get; set; }
    }
}
