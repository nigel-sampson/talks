using System;
using Android.Content;
using NDC.Build.App.Droid.Activities;
using NDC.Build.Core.Model;
using NDC.Build.Core.Services;

namespace NDC.Build.App.Droid.Services
{
    public class ApplicationNavigationService : ActivityAwareService, IApplicationNavigationService
    {
        public ApplicationNavigationService(Application application)
            : base(application)
        {
        }

        public void ToProjects()
        {
            CurrentActivity.StartActivity(typeof(ProjectsActivity));
        }

        public void ToProject(Project project)
        {
            var intent = new Intent(CurrentActivity, typeof (BuildsActivity));

            intent.PutExtra("ProjectId", project.Id);

            CurrentActivity.StartActivity(intent);
        }
    }
}