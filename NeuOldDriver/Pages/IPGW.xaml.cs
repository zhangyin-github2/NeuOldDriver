using Windows.UI.Xaml.Controls;

// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上有介绍

namespace NeuOldDriver.Pages {
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class IPGW : Page {
        public IPGW() {
            this.InitializeComponent();
        }

        private void Login_Finished(object sender, Models.LoginData e) {
            split.IsPaneOpen = false;
        }
    }
}
