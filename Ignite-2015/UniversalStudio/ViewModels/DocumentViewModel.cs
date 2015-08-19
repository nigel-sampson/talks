using System;
using Caliburn.Micro;

namespace UniversalStudio.ViewModels
{
    public class DocumentViewModel : TabViewModel
    {
        private string body;

        public DocumentViewModel(IEventAggregator eventAggregator)
            : base(eventAggregator)
        {
            
        }

        public string Body
        {
            get { return body; }
            set
            {
                body = value;
                NotifyOfPropertyChange(nameof(Body));
            }
        }
    }
}
