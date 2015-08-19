using System;
using UniversalStudio.ViewModels;

namespace UniversalStudio.Messages
{
    public class CloseTabMessage
    {
        public CloseTabMessage(TabViewModel tab)
        {
            Tab = tab;
        }

        public TabViewModel Tab { get; }
    }
}
