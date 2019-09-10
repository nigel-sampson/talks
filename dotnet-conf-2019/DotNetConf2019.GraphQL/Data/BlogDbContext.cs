using Microsoft.EntityFrameworkCore;

namespace DotNetConf2019.GraphQL.Data
{
    public class BlogDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("server=localhost;port=5432;userid=postgres;pwd=password;database=dotnetconf", npgOptionsBuilder =>
            {
                npgOptionsBuilder.UseNodaTime();
            });
        }

        public DbSet<Post> Posts { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Author> Authors { get; set; }

        public DbSet<Image> Images { get; set; }
    }
}
