using System;
using Caliburn.Micro;
using UniversalStudio.Messages;

namespace UniversalStudio.ViewModels
{
    public class TabViewModel : Screen
    {
        private readonly IEventAggregator eventAggregator;

        public TabViewModel(IEventAggregator eventAggregator)
        {
            this.eventAggregator = eventAggregator;
        }

        public void Close()
        {
            eventAggregator.PublishOnUIThread(new CloseTabMessage(this, false));
        }

        public void CloseAllButThis()
        {
            eventAggregator.PublishOnUIThread(new CloseTabMessage(this, true));
        }
    }
}
