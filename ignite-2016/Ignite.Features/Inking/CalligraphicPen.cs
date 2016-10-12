using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI.Input.Inking;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace Ignite.Features.Inking
{
    public class CalligraphicPen : InkToolbarCustomPen
    {
        protected override InkDrawingAttributes CreateInkDrawingAttributesCore(Brush brush, double strokeWidth)
        {
            var inkDrawingAttributes = new InkDrawingAttributes
            {
                PenTip = PenTipShape.Circle,
                IgnorePressure = false
            };

            var solidColorBrush = (SolidColorBrush) brush;

            if (solidColorBrush != null)
            {
                inkDrawingAttributes.Color = solidColorBrush.Color;
            }

            inkDrawingAttributes.Size = new Size(strokeWidth, 2.0f * strokeWidth);
            inkDrawingAttributes.PenTipTransform = System.Numerics.Matrix3x2.CreateRotation(45.0f);

            return inkDrawingAttributes;
        }
    }
}
