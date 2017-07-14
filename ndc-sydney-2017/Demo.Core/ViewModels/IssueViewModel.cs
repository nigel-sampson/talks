using System;
using System.Linq;
using Caliburn.Micro;
using Octokit;

namespace Demo.Core.ViewModels
{
    public class IssueViewModel : Screen
    {
        private readonly IGitHubClient gitHubClient;
        private readonly string owner;
        private readonly string name;
        private readonly int number;


        public IssueViewModel(IGitHubClient gitHubClient, string owner, string name, Issue issue)
        {
            this.gitHubClient = gitHubClient;
            this.owner = owner;
            this.name = name;

            number = issue.Number;
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

        protected override async void OnInitialize()
        {
            var comments = await gitHubClient.Issue.Comment.GetAllForIssue(owner, name, number);

            Comments.AddRange(comments.Select(c => new CommentViewModel(c)));
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
