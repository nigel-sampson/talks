using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Caliburn.Micro;
using Octokit;

namespace Demo.Core.ViewModels
{
    public class IssueViewModel : Screen
    {
        private readonly Func<Task<IReadOnlyList<IssueComment>>> getComments;

        public IssueViewModel(Issue issue, Func<Task<IReadOnlyList<IssueComment>>> getComments)
        {
            this.getComments = getComments;
            Title = issue.Title;
            Author = issue.User.Login;
            Body = issue.Body;

            ThumbsUp = issue.Reactions.Plus1;
            ThumbsDown = issue.Reactions.Minus1;
            Laugh = issue.Reactions.Laugh;
            Tada = issue.Reactions.Hooray;
            Confused = issue.Reactions.Confused;
            Hearts = issue.Reactions.Heart;
        }

        public string Title { get; }
        public string Author { get; }
        public string Body { get; }

        public int ThumbsUp { get; }
        public int ThumbsDown { get; }
        public int Laugh { get; }
        public int Tada { get; }
        public int Confused { get; }
        public int Hearts { get; }

        public BindableCollection<CommentViewModel> Comments { get; } = new BindableCollection<CommentViewModel>();
    }
}
