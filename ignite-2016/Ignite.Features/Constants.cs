using System;

namespace Ignite.Features
{
    public static class Constants
    {
        public const string Lipsum = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus sit amet felis vel massa rutrum elementum non non magna. Morbi non tincidunt velit. Morbi lobortis orci at mattis tempus. Mauris rutrum quam tellus, eget sagittis justo pellentesque vitae. Aliquam varius orci vel malesuada ultricies.";
        private static readonly Random Random = new Random();

        public static string GetLipsum()
        {
            return Lipsum.Substring(Random.Next(Lipsum.Length));
        }
    }
}
