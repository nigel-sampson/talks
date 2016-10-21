using System;
using System.Linq;
using Windows.ApplicationModel.Background;
using Caliburn.Micro;
using Ignite.Features.Messages;

namespace Ignite.Features.ViewModels
{
    public class BackgroundTaskViewModel : Screen, IHandle<BackgroundTaskMessage>
    {
        private readonly IEventAggregator eventAggregator;
        private const string TaskName = "Single Process Background Task";

        public BackgroundTaskViewModel(IEventAggregator eventAggregator)
        {
            this.eventAggregator = eventAggregator;

            Messages = new BindableCollection<string>();
        }

        protected override void OnInitialize()
        {
            var taskRegistered = BackgroundTaskRegistration.AllTasks
                .Any(t => t.Value.Name == TaskName);

            if (taskRegistered)
            {
                Messages.Add("Task already registered");
                return;
            }

            var taskBuilder = new BackgroundTaskBuilder
            {
                Name = TaskName
            };

            taskBuilder.SetTrigger(new TimeTrigger(15, false));

            taskBuilder.Register();

            Messages.Add("Task Registered");
        }

        protected override void OnActivate()
        {
            eventAggregator.Subscribe(this);
        }

        protected override void OnDeactivate(bool close)
        {
            eventAggregator.Unsubscribe(this);
        }

        public void Handle(BackgroundTaskMessage message)
        {
            Messages.Add("Task executed");
        }

        public BindableCollection<string> Messages { get; } 
    }
}
