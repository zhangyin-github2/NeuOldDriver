using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace NeuOldDriver.Pages {

    public sealed partial class IPGW : Page {

        public IPGW() {
            this.InitializeComponent();

            loginControl.Finished += async (sender, e) => {
                if (await vm.Login(e)) {
                    await vm.UpdateInfo();
                    backdrop.Visibility = Visibility.Collapsed;
                }
            };

            logoutButton.Click += async (sender, e) => {
                if (await vm.Logout())
                    backdrop.Visibility = Visibility.Visible;
            };
        }
    }
}
