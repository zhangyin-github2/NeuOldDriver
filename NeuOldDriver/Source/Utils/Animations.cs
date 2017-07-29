using System;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Hosting;

namespace NeuOldDriver.Utils {

    public static class Animations {
        
        /// <summary>
        /// Create a FadeIn/FadeOut Animation
        /// </summary>
        /// <param name="elem">element to create animation on</param>
        /// <param name="parent">parent element of elem</param>
        /// <param name="duration">duration of animation, milliseconds</param>
        /// <param name="fadein">is fade in, return fadeout anim if false</param>
        public static void StartFadeAnimation(FrameworkElement elem, FrameworkElement parent, int duration, bool fadein = true) {
            var compositor = ElementCompositionPreview.GetElementVisual(parent).Compositor;
            var fadeAnim = compositor.CreateScalarKeyFrameAnimation();
            fadeAnim.InsertKeyFrame(1f, fadein ? 1f : 0f);
            fadeAnim.Duration = TimeSpan.FromMilliseconds(duration);
            ElementCompositionPreview.GetElementVisual(elem)
                .StartAnimation("Opacity", fadeAnim);
        }
    }
}
