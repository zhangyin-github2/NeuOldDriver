using System;

using Windows.UI.Composition;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Hosting;

namespace NeuOldDriver.Utils {
    public static class Animations {

        /// <summary>
        /// Create a FadeIn/FadeOut Animation
        /// </summary>
        /// <param name="elem">parent of element to create animation on</param>
        /// <param name="duration">duration of animation, milliseconds</param>
        /// <param name="fadein">is fade in, return fadeout anim if false</param>
        /// <returns></returns>
        public static ScalarKeyFrameAnimation FadeAnimation(FrameworkElement parent, int duration, bool fadein = true) {
            var compositor = ElementCompositionPreview.GetElementVisual(parent).Compositor;
            var fadeAnim = compositor.CreateScalarKeyFrameAnimation();
            fadeAnim.InsertKeyFrame(1f, fadein ? 1f : 0f);
            fadeAnim.Duration = TimeSpan.FromMilliseconds(duration);
            return fadeAnim;
        }

        /// <summary>
        /// Start animation on element
        /// </summary>
        /// <param name="elem"></param>
        /// <param name="anim"></param>
        public static void StartAnimation(FrameworkElement elem, KeyFrameAnimation anim, string propname) {
            ElementCompositionPreview.GetElementVisual(elem)
                .StartAnimation(propname, anim);
        }

    }
}
