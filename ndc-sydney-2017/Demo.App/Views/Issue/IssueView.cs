using System;

namespace Demo.App.Views.Issue
{
    public class IssueView
    {
        public IssueView(string context, string name)
        {
            Context = context;
            Name = name;
        }

        public string Context { get; }

        public string Name { get; }
    }
}
