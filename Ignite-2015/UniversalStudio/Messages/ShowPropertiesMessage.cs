using System;
using UniversalStudio.ViewModels;

namespace UniversalStudio.Messages
{
    public class ShowPropertiesMessage
    {
        public ShowPropertiesMessage(TabViewModel tab)
        {
            Tab = tab;
        }

        public TabViewModel Tab { get; }
    }
}
