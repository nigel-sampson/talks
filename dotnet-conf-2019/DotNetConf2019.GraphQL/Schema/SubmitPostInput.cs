namespace DotNetConf2019.GraphQL.Schema
{
    public class SubmitPostInput
    {
        public int AuthorId { get; set; }

        public string Title { get; set; }

        public string Markdown { get; set; }
    }
}
