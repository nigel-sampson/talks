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
            Issues = new IssuesViewModel(hubbClient, eventAggregator);
            Menu = new MenuViewModel(hubbClient, eventAggregator);
            
            Issues.ConductWith(this);
            Menu.ConductWith(this);
        }

        public MenuViewModel Menu { get; }

        public IssuesViewModel Issues { get; }
    }
}
