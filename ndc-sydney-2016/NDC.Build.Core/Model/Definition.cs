using System;

namespace NDC.Build.Core.Model
{
    public class Definition
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public override string ToString() => Name;
    }
}
