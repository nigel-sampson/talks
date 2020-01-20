using System;
using System.Collections.Generic;

namespace BlogServer.Models
{
    public partial class Posts
    {
        public Posts()
        {
            Comments = new HashSet<Comments>();
            Images = new HashSet<Images>();
        }

        public int Id { get; set; }
        public int AuthorId { get; set; }
        public string Title { get; set; }
        public string Markdown { get; set; }
        public byte[] PublishedOn { get; set; }

        public virtual Authors Author { get; set; }
        public virtual ICollection<Comments> Comments { get; set; }
        public virtual ICollection<Images> Images { get; set; }
    }
}
