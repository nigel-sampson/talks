using NodaTime;

namespace DotNetConf2019.GraphQL.Data
{
    public class Comment
    {
        public int Id { get; set; } = 0;

        public string Text { get; set; } = null!;

        public int PostId { get; set; } = 0;

        public OffsetDateTime SubmittedOn { get; set; }
    }
}
