using System;
using System.Collections.Generic;
using NDC.Build.Core.Model;

namespace NDC.Build.Core.ViewModels
{
    public class BuildViewModel
    {
        private static readonly IDictionary<string, string> Colours = new Dictionary<string, string>
        {
            { "succeeded", "#FF4CAF50" },
            { "failed", "#FFF44336" },
            { "canceled", "#FFFFC107" }
        };

        public BuildViewModel(BuildDetail build)
        {
            Build = build;
        }

        public BuildDetail Build { get; }

        public string StartedOn => Build.StartTime.ToLocalTime().ToString("f");

        public string Result => Colours[Build.Result];

        public double Completed => Build.Status == "completed" ? 1.0 : 0.5;
    }
}
