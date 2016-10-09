using System;
using Caliburn.Micro;

namespace Ignite.Features.ViewModels
{
    public class BindingViewModel : Screen
    {
        private int count = 10;

        public int Count
        {
            get { return count; }
            set
            {
                count = value;
                NotifyOfPropertyChange();
                NotifyOfPropertyChange(() => HighScore);
            }
        }

        public bool HighScore => Count > 10;

        public void Increment() => Count++;
        public void Decrement() => Count--;
    }
}
