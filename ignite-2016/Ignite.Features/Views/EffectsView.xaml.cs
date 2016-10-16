using System;
using System.Numerics;
using Windows.UI.Composition;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Hosting;
using Microsoft.Graphics.Canvas.Effects;

namespace Ignite.Features.Views
{
    public sealed partial class EffectsView
    {
        private CompositionEffectBrush brush;
        private Compositor compositor;

        public EffectsView()
        {
            InitializeComponent();
        }
        
        private void SetupBlur()
        {
            compositor = ElementCompositionPreview.GetElementVisual(this).Compositor;

            var effect = new GaussianBlurEffect
            {
                Name = "Blur",
                Source = new CompositionEffectSourceParameter("Backdrop"),
                BlurAmount = 0.0f,
                BorderMode = EffectBorderMode.Hard
            };

            var effectFactory = compositor.CreateEffectFactory(effect, new[] {"Blur.BlurAmount"});
            brush = effectFactory.CreateBrush();

            var backdrop = compositor.CreateBackdropBrush();
            brush.SetSourceParameter("Backdrop", backdrop);

            var sprite = compositor.CreateSpriteVisual();

            sprite.Brush = brush;
            sprite.Size = new Vector2((float) TargetImage.ActualWidth, (float) TargetImage.ActualHeight);

            ElementCompositionPreview.SetElementChildVisual(TargetImage, sprite);
        }

        private void OnBlurValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            brush?.Properties.InsertScalar("Blur.BlurAmount", (float) e.NewValue);
        }

        private void OnImageOpened(object sender, RoutedEventArgs e)
        {
            SetupBlur();
        }
    }
}
