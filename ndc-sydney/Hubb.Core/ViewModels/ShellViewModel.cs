using System;
using Caliburn.Micro;
using Octokit;

namespace Hubb.Core.ViewModels
{
    public class ShellViewModel : Screen
    {
        public ShellViewModel(IGitHubClient gitHubClient, IEventAggregator eventAggregator)
        {
            Menu = new MenuViewModel(gitHubClient, eventAggregator);
            Issues = new IssuesViewModel(gitHubClient, eventAggregator);

            Menu.ConductWith(this);
            Issues.ConductWith(this);
        }

        public MenuViewModel Menu { get; }

        public IssuesViewModel Issues { get; }
    }
}
