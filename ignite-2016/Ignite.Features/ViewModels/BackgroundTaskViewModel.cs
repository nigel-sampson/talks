using System;
using System.Linq;
using Windows.ApplicationModel.Background;
using Caliburn.Micro;

namespace Ignite.Features.ViewModels
{
    public class BackgroundTaskViewModel : Screen
    {
        private const string TaskName = "Single Process Background Task";
        private string feedback;

        protected override void OnInitialize()
        {
            var taskRegistered = BackgroundTaskRegistration.AllTasks
                .Any(t => t.Value.Name == TaskName);

            if (taskRegistered)
            {
                Feedback = "Task already registered";
                return;
            }

            var taskBuilder = new BackgroundTaskBuilder
            {
                Name = TaskName
            };

            taskBuilder.SetTrigger(new TimeTrigger(15, false));

            taskBuilder.Register();

            Feedback = "Task Registered";
        }

        public string Feedback
        {
            get { return feedback; }
            set
            {
                feedback = value;
                NotifyOfPropertyChange(() => Feedback);
            }
        }
    }
}
