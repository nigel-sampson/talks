using System;

namespace Ignite.Features.ViewModels
{
    public class FeatureViewModel
    {
        public FeatureViewModel(string title, string description, Type viewModel)
        {
            Title = title;
            Description = description;
            ViewModel = viewModel;
        }

        public string Title { get; }
        public string Description { get; }
        public Type ViewModel { get; }
    }
}
