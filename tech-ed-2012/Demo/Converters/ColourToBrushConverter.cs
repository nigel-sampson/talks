using System;
using Windows.UI;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;

namespace Demo.Converters
{
    public class ColourToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value == null)
                return null;

            var hex = value.ToString();
            var a = System.Convert.ToByte(hex.Substring(1, 2), 16);
            var r = System.Convert.ToByte(hex.Substring(3, 2), 16);
            var g = System.Convert.ToByte(hex.Substring(5, 2), 16);
            var b = System.Convert.ToByte(hex.Substring(7, 2), 16);

            return new SolidColorBrush(Color.FromArgb(a, r, g, b));
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotSupportedException();
        }
    }
}
