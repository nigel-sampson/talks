using System;

namespace Ignite.Features.ViewModels
{
    public class ColourViewModel
    {
        public ColourViewModel(string name, string hex)
        {
            Name = name;
            Hex = hex;
        }

        public string Name { get; }
        public string Hex { get; }
    }
}
