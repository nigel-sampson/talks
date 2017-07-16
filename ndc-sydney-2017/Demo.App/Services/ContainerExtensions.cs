using System;
using Caliburn.Micro;

namespace Demo.App.Services
{
    public static class ContainerExtensions
    {
        public static SimpleContainer ViewModel<T>(this SimpleContainer container)
        {
            container.PerRequest<T>();
            container.Instance<Func<T>>(() => container.GetInstance<T>());

            return container;
        }
    }
}
