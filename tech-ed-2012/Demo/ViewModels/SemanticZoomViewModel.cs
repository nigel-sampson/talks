using System;
using System.Linq;
using Caliburn.Micro;
using Demo.Data;

namespace Demo.ViewModels
{
    public class SemanticZoomViewModel : ViewModelBase
    {
        public SemanticZoomViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Languages = new BindableCollection<LanguageViewModel>();
        }

        protected async override void OnInitialize()
        {
            base.OnInitialize();

            var gitHubData = new GitHubDataSource();
            var repositories = await gitHubData.LoadRepositories();

            var languages = from r in repositories
                            group r by r.Language into l
                            select new LanguageViewModel
                            {
                                Name = l.Key ?? "Unknown",
                                Repositories = new BindableCollection<RepositoryViewModel>(l)
                            };

            Languages.AddRange(languages);
        }

        public BindableCollection<LanguageViewModel> Languages
        {
            get;
            private set;
        }
    }
}
