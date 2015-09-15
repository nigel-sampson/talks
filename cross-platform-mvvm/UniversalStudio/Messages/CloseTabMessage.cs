using System;
using UniversalStudio.ViewModels;

namespace UniversalStudio.Messages
{
    public class CloseTabMessage
    {
        public CloseTabMessage(TabViewModel tab, bool everythingElse)
        {
            EverythingElse = everythingElse;
            Tab = tab;
        }

        public TabViewModel Tab { get; }

        public bool EverythingElse { get; }
    }
}
