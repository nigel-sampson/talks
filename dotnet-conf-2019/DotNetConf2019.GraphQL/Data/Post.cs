using NodaTime;

namespace DotNetConf2019.GraphQL.Data
{
    public class Post
    {
        public int Id { get; set; }

        public int AuthorId { get; set; }

        public string Title { get; set; }

        public string Markdown { get; set; }

        public OffsetDateTime PublishedOn { get; set; }
    }
}
