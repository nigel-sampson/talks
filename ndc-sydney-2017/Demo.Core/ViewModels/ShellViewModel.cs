using System;
using Caliburn.Micro;

namespace Demo.Core.ViewModels
{
    public class ShellViewModel : Screen
    {
        private readonly RepositoryDetailsViewModel details;
        private readonly IssuesListViewModel issues;
        private readonly SettingsViewModel settings;
        private Screen activeScreen;

        public ShellViewModel(
            Func<MenuViewModel> menuFactory,
            Func<RepositoryDetailsViewModel> detailsFactory,
            Func<IssuesListViewModel> issuesFactory,
            Func<SettingsViewModel> settingsFactory)
        {
            details = detailsFactory();
            issues = issuesFactory();
            settings = settingsFactory();

            Menu = menuFactory();
            Menu.ConductWith(this);

            ActiveScreen = details;
        }

        public MenuViewModel Menu { get; }

        public Screen ActiveScreen
        {
            get => activeScreen;
            set
            {
                ScreenExtensions.TryDeactivate(activeScreen, false);
                activeScreen = value;
                ScreenExtensions.TryActivate(activeScreen);
            }
        }

        public void ViewDetails()
        {
            ActiveScreen = details;
        }

        public void ViewIssues()
        {
            ActiveScreen = issues;
        }

        public void ViewSettings()
        {
            ActiveScreen = settings;
        }
    }
}
