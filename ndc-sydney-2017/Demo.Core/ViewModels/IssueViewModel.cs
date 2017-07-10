using System;
using Octokit;

namespace Demo.Core.ViewModels
{
    public class IssueViewModel
    {
        public IssueViewModel(Issue issue)
        {
            Title = issue.Title;
            Author = issue.User.Login;
            Body = issue.Body;

            Hearts = issue.Reactions.Heart;
        }

        public string Title { get; }
        public string Author { get; }
        public string Body { get; }

        public int Hearts { get; }
    }
}
