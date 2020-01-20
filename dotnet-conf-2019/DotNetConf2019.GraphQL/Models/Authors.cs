using System;
using System.Collections.Generic;

namespace BlogServer.Models
{
    public partial class Authors
    {
        public Authors()
        {
            Posts = new HashSet<Posts>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Posts> Posts { get; set; }
    }
}
