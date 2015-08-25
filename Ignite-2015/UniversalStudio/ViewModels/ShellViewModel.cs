using System;
using System.Linq;
using Caliburn.Micro;
using UniversalStudio.Messages;

namespace UniversalStudio.ViewModels
{
    public class ShellViewModel : Conductor<TabViewModel>.Collection.OneActive,
        IHandle<CloseTabMessage>
    {
        private int documentCount;
        private readonly IEventAggregator eventAggregator;

        public ShellViewModel(IEventAggregator eventAggregator)
        {
            this.eventAggregator = eventAggregator;
        }

        protected override void OnActivate()
        {
            eventAggregator.Subscribe(this);
        }

        protected override void OnDeactivate(bool close)
        {
            eventAggregator.Unsubscribe(this);
        }

        public void Handle(CloseTabMessage message)
        {
            if (message.EverythingElse)
            {
                var tabsToClose = Items.Except(message.Tab).ToList();

                foreach (var tab in tabsToClose)
                {
                    DeactivateItem(tab, true);
                }
            }
            else
            {
                DeactivateItem(message.Tab, true);
            }
            
        }

        public void OpenNewDocument()
        {
            ActivateItem(new DocumentViewModel(eventAggregator) { DisplayName = String.Format("Document-{0}", ++documentCount)});
        }
    }
}
