using Windows.UI.Xaml.Controls;

using NeuOldDriver.Utils;
using NeuOldDriver.Global;
using NeuOldDriver.Controls;

namespace NeuOldDriver.Pages {

    public sealed partial class IPGW : Page {

        public IPGW() {
            this.InitializeComponent();

            login.Submit += async (sender, e) => {
                var window = sender as Login;
                if (!await vm.Login(window.UserName, window.Password))
                    await Dialogs.Popup("错误", "登录失败!");
                else {
                    Globals.Settings.SetActiveUser("IPGW", window.UserName);
                    if (window.RememberMe) 
                        Globals.Settings.UpdateAccount("IPGW", window.UserName, window.Password);
                }
            };

            logoutButton.Click += async (sender, e) => {
                if (!await vm.Logout())
                    await Dialogs.Popup("错误", "注销失败!");
            };
        }
    }
}
