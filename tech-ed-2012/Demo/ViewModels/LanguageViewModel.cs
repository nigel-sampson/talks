using System;
using Caliburn.Micro;

namespace Demo.ViewModels
{
    public class LanguageViewModel : PropertyChangedBase
    {
        private string _name;

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                NotifyOfPropertyChange();
            }
        }

        public BindableCollection<RepositoryViewModel> Repositories
        {
            get; set;
        }

        public int Height
        {
            get
            {
                return Repositories.Count * 2;
            }
        }
    }
}
