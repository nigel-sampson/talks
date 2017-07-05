using System;

namespace NDC.Build.Core.Model
{
    public class BuildRequest
    {
        public Definition Definition { get; set; }

        public string SourceBranch { get; set; }
    }
}
