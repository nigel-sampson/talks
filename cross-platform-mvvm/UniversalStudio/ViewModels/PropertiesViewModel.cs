using System;
using Windows.UI.Text;
using Caliburn.Micro;

namespace UniversalStudio.ViewModels
{
    public class PropertiesViewModel : TabViewModel
    {
        private readonly TabViewModel tab;
        private string editName;

        public PropertiesViewModel(TabViewModel tab, IEventAggregator eventAggregator)
            : base(eventAggregator)
        {
            this.tab = tab;

            EditName = tab.DisplayName;
            DisplayName = String.Format("'{0}' properties", tab.DisplayName);
        }

        protected override void OnDeactivate(bool close)
        {
            base.OnDeactivate(close);

            if (close)
                tab.DisplayName = EditName;
        }

        public string EditName
        {
            get {  return editName; }
            set
            {
                editName = value;
                NotifyOfPropertyChange(nameof(EditName));
            }
        }
    }
}
