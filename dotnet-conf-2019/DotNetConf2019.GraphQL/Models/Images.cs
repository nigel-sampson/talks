using System;
using System.Collections.Generic;

namespace BlogServer.Models
{
    public partial class Images
    {
        public int Id { get; set; }
        public int Size { get; set; }
        public string Url { get; set; }
        public int PostId { get; set; }

        public virtual Posts Post { get; set; }
    }
}
