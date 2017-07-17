using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;

using NeuOldDriver.Models;

// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上有介绍

namespace NeuOldDriver.Pages {
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class AAO : Page {

        public AAO() {
            this.InitializeComponent();
        }

        private void PageNavigate(object sender, ItemClickEventArgs e) {
            var frame = (App.Current as App).MainFrame;
            var page = (e.ClickedItem as PageButtonData).Page;

            // disable selection, we do not want selected effect
            (sender as Selector).SelectedIndex = -1;

            frame.Navigate(page);
        }
    }
}
