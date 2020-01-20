using HotChocolate.Types;
using HotChocolate.Types.Relay;
using System;

namespace DotNetConf2019.GraphQL.Data
{
    public class Post
    {

        public int Id { get; set; } = 0;

        public int AuthorId { get; set; } = 0;

        public string Title { get; set; } = "";

        public string Markdown { get; set; } = "";

        public DateTime PublishedOn { get; set; }
    }
}
