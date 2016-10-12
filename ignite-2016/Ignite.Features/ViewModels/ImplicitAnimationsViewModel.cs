using System;
using Windows.UI;
using Caliburn.Micro;

namespace Ignite.Features.ViewModels
{
    public class ImplicitAnimationsViewModel : Screen
    {
        public ImplicitAnimationsViewModel()
        {
            Colours = new BindableCollection<ColourViewModel>
            {
                new ColourViewModel("Red", "#F44336"),
                new ColourViewModel("Pink", "#E91E63"),
                new ColourViewModel("Purple", "#9C27B0"),
                new ColourViewModel("Deep Purple", "#673AB7"),
                new ColourViewModel("Indigo", "#3F51B5"),
                new ColourViewModel("Blue", "#2196F3"),
                new ColourViewModel("Light Blue", "#03A9F4"),
                new ColourViewModel("Cyan", "#00BCD4"),
                new ColourViewModel("Teal", "#009688"),
                new ColourViewModel("Green", "#4CAF50"),
                new ColourViewModel("Light Green", "#8BC34A"),
                new ColourViewModel("Lime", "#CDDC39"),
                new ColourViewModel("Amber", "#FFC107"),
                new ColourViewModel("Orange", "#FF9800"),
                new ColourViewModel("Deep Orange", "#FF5722"),
                new ColourViewModel("Brown", "#795548"),
                new ColourViewModel("Grey", "#9E9E9E"),
                new ColourViewModel("Blue Grey", "#607D8B")
            };
        }

        public BindableCollection<ColourViewModel> Colours { get; }
    }
}
