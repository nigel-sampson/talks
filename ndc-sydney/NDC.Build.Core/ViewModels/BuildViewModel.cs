using System;
using NDC.Build.Core.Model;

namespace NDC.Build.Core.ViewModels
{
    public class BuildViewModel
    {
        public BuildViewModel(BuildDetail build)
        {
            Build = build;
        }

        public BuildDetail Build { get; }
    }
}
