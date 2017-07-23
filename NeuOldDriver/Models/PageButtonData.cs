using System;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace NeuOldDriver.Models {

    public class PageButtonData : DependencyObject {
        public string Glyph {
            get { return (string)GetValue(GlyphProperty);}
            set { SetValue(GlyphProperty, value); }
        }
        public string Label {
            get { return (string)GetValue(LabelProperty); }
            set { SetValue(LabelProperty, value); }
        }
        public Type Page {
            get { return (Type)GetValue(PageProperty); }
            set { SetValue(PageProperty, value); }
        }

        public static readonly DependencyProperty PageProperty =
            DependencyProperty.RegisterAttached(nameof(Page), typeof(Page), typeof(PageButtonData), null);

        public static readonly DependencyProperty GlyphProperty =
            DependencyProperty.RegisterAttached(nameof(Glyph), typeof(string), typeof(PageButtonData), null);

        public static readonly DependencyProperty LabelProperty =
            DependencyProperty.RegisterAttached(nameof(Page), typeof(string), typeof(PageButtonData), null);
    };
}
