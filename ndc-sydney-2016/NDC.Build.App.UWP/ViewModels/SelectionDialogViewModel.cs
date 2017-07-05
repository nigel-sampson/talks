using System;
using System.Collections.Generic;
using Caliburn.Micro;

namespace NDC.Build.App.UWP.ViewModels
{
    public class SelectionDialogViewModel<T> : Screen
    {
        public SelectionDialogViewModel(string header, IEnumerable<T> options)
        {
            Header = header;
            Options = new BindableCollection<T>(options);
            SelectedOption = Options[0];
        }

        public string Header { get; }

        public BindableCollection<T> Options { get; }

        public T SelectedOption { get; set; }
    }
}
