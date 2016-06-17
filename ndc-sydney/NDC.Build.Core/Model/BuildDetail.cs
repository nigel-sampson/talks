using System;

namespace NDC.Build.Core.Model
{
    public class BuildDetail
    {
        public int Id { get; set; }

        public Definition Definition { get; set; }

        public DateTimeOffset StartTime { get; set; }
        public DateTimeOffset FinishTime { get; set; }

        public string Status { get; set; }
        public string Result { get; set; }
    }
}
