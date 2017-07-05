using System;
using System.Globalization;
using UIKit;

namespace NDC.Build.App.iOS
{
    public static class StringExtensions
    {
        public static UIColor ToUIColor(this string value)
        {
            value = value.TrimStart('#');

            var alpha = Int32.Parse(value.Substring(0, 2), NumberStyles.HexNumber);
            var red = Int32.Parse(value.Substring(2, 2), NumberStyles.HexNumber);
            var green = Int32.Parse(value.Substring(4, 2), NumberStyles.HexNumber);
            var blue = Int32.Parse(value.Substring(6, 2), NumberStyles.HexNumber);

            return UIColor.FromRGBA(red, green, blue, alpha);
        }
    }
}
