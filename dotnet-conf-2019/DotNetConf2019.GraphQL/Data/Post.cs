using NodaTime;

namespace DotNetConf2019.GraphQL.Data
{
    public class Post
    {

        public int Id { get; set; } = 0;

        public int AuthorId { get; set; } = 0;

        public string Title { get; set; } = "";

        public string Markdown { get; set; } = "";

        public OffsetDateTime PublishedOn { get; set; }
    }
}
