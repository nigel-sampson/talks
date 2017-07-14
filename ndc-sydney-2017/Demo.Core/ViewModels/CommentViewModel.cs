using System;
using Octokit;

namespace Demo.Core.ViewModels
{
    public class CommentViewModel
    {
        public CommentViewModel(IssueComment comment)
        {
            Body = comment.Body;
            Author = comment.User.Login;
        }

        public string Body { get; }
        public string Author { get; }
    }
}
