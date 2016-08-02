using System;
using Caliburn.Micro;
using Hubb.Core.Services;
using Octokit;

namespace Hubb.Core.ViewModels
{
    public class ShellViewModel : Screen
    {
        public ShellViewModel(IHubbClient hubbClient, IEventAggregator eventAggregator)
        {
            Menu = new MenuViewModel(hubbClient, eventAggregator);
            Issues = new IssuesViewModel(hubbClient, eventAggregator);

            Menu.ConductWith(this);
            Issues.ConductWith(this);
        }

        public MenuViewModel Menu { get; }

        public IssuesViewModel Issues { get; }
    }
}
