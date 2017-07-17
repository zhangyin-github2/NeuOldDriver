using Windows.UI.Xaml.Controls;

namespace NeuOldDriver.Pages {

    public sealed partial class IPGW : Page {

        public IPGW() {
            this.InitializeComponent();

            loginControl.Finished += async (sender, e) => {
                if (await vm.Login(e))
                    await vm.UpdateInfo();
            };

            logoutButton.Click += async (sender, e) => {
                await vm.Logout();
            };
        }
    }
}
