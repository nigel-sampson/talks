using System;
using System.Collections.Generic;

namespace BlogServer.Models
{
    public partial class Comments
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int PostId { get; set; }
        public byte[] SubmittedOn { get; set; }

        public virtual Posts Post { get; set; }
    }
}
