using System;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace NeuOldDriver.Controls {

    public class NavButtonData : Control {
        public string Glyph {
            get {
                return (string)GetValue(GlyphProperty);
            }
            set {
                SetValue(GlyphProperty, value);
            }
        }
        public string Label {
            get {
                return (string)GetValue(LabelProperty);
            }
            set {
                SetValue(LabelProperty, value);
            }
        }
        public Type Page {
            get {
                return (Type)GetValue(PageProperty);
            }
            set {
                SetValue(PageProperty, value);
            }
        }

        public static readonly DependencyProperty PageProperty =
            DependencyProperty.RegisterAttached("Page", typeof(Page), typeof(NavButtonData), new PropertyMetadata(false));

        public static readonly DependencyProperty GlyphProperty =
            DependencyProperty.RegisterAttached("Glyph", typeof(string), typeof(NavButtonData), new PropertyMetadata(false));

        public static readonly DependencyProperty LabelProperty =
            DependencyProperty.RegisterAttached("Label", typeof(string), typeof(NavButtonData), new PropertyMetadata(false));
    };
}
