using Windows.UI.Xaml.Controls;

using NeuOldDriver.Utils;

namespace NeuOldDriver.Pages {

    public sealed partial class IPGW : Page {

        public IPGW() {
            this.InitializeComponent();

            login.Submit += async (sender, e) => {
                if (!await vm.Login(e.username, e.password)) {
                    await Dialogs.Popup("错误", "登录失败!");
                    return false;
                }
                return true;
            };

            logoutButton.Click += async (sender, e) => {
                if (!await vm.Logout())
                    await Dialogs.Popup("错误", "注销失败!");
            };
        }
    }
}
