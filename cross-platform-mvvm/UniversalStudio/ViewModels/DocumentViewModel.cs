using System;
using Caliburn.Micro;

namespace UniversalStudio.ViewModels
{
    public class DocumentViewModel : TabViewModel
    {
        private const string Lipsum = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam non tempor est. Phasellus at euismod ligula. Aenean vitae dolor vitae nisi auctor pellentesque. Pellentesque luctus sapien tortor, nec placerat tortor egestas eu. Nulla in arcu sodales, gravida metus vitae, ultricies metus. Quisque dolor massa, lobortis nec pulvinar non, blandit eget arcu. Integer finibus vel turpis non euismod. Duis ornare erat tortor, vitae sollicitudin nibh commodo et. Nunc a nisl eros. Donec quis ligula erat. Maecenas et lectus in arcu sagittis dignissim. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Phasellus non ex et turpis congue ultrices et et nibh. Sed ornare, turpis in pulvinar aliquam, turpis erat egestas eros, id volutpat odio ipsum gravida tortor. Sed rutrum libero ut nisi consequat ullamcorper.";
        private static readonly Random Random = new Random();
        private string body;

        public DocumentViewModel(IEventAggregator eventAggregator)
            : base(eventAggregator)
        {
            Body = Lipsum.Substring(0, Random.Next(Lipsum.Length));
        }

        public string Body
        {
            get { return body; }
            set
            {
                body = value;
                NotifyOfPropertyChange(nameof(Body));
            }
        }
    }
}
