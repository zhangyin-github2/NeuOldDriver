using Windows.UI.Xaml.Controls;

using NeuOldDriver.Utils;
using NeuOldDriver.Global;
using NeuOldDriver.Controls;

namespace NeuOldDriver.Pages {

    public sealed partial class IPGW : Page {

        public IPGW() {
            this.InitializeComponent();

            login.Submit += async (sender, e) => {
                if (!await vm.Login(e.username, e.password))
                    await Dialogs.Popup("错误", "登录失败!");
                else {
                    Globals.Settings.SetActiveUser("IPGW", e.username);
                    if (e.remember || Globals.Settings.HasUser("IPGW", e.username)) 
                        Globals.Settings.UpdateAccount("IPGW", e.username, e.password);
                }
            };

            logoutButton.Click += async (sender, e) => {
                if (!await vm.Logout())
                    await Dialogs.Popup("错误", "注销失败!");
            };
        }
    }
}
