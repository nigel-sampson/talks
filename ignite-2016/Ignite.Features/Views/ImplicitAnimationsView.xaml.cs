using System;
using Windows.UI.Composition;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Hosting;

namespace Ignite.Features.Views
{
    public sealed partial class ImplicitAnimationsView
    {
        private ImplicitAnimationCollection animations;

        public ImplicitAnimationsView()
        {
            InitializeComponent();

            CreateAnimations();
        }

        private void CreateAnimations()
        {
            var compositor = ElementCompositionPreview.GetElementVisual(this).Compositor;

            var offsetAnimation = compositor.CreateVector3KeyFrameAnimation();

            offsetAnimation.Target = nameof(Visual.Offset);
            offsetAnimation.InsertExpressionKeyFrame(1.0f, "this.FinalValue");
            offsetAnimation.Duration = TimeSpan.FromMilliseconds(400);

            animations = compositor.CreateImplicitAnimationCollection();
            animations[nameof(Visual.Offset)] = offsetAnimation;
        }

        private void OnContainerContentChanging(ListViewBase sender, ContainerContentChangingEventArgs args)
        {
            var visual = ElementCompositionPreview.GetElementVisual(args.ItemContainer);

            visual.ImplicitAnimations = args.InRecycleQueue
                ? null
                : animations;
        }
    }
}
