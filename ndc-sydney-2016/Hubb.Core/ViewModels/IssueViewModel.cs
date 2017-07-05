using System;
using Caliburn.Micro;
using Octokit;

namespace Hubb.Core.ViewModels
{
    public class IssueViewModel : Screen
    {
        public IssueViewModel(Issue issue)
        {
            Issue = issue;
        }

        public Issue Issue { get; }
    }
}
