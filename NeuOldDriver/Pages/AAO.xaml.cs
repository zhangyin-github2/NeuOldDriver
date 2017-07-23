using System;

using Windows.UI.Xaml.Controls;

using NeuOldDriver.Utils;
using NeuOldDriver.Global;
using NeuOldDriver.Models;
using NeuOldDriver.Controls;

// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上有介绍

namespace NeuOldDriver.Pages {
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class AAO : Page {

        public AAO() {
            this.InitializeComponent();

            this.Loaded += async (sender, e) => {
                login.ImageSource = await API.AAO.CaptchaImage();
            };

            login.Refresh += async (sender, e) => {
                return await API.AAO.CaptchaImage();
            };

            login.Submit += async (sender, e) => {
                var reason = await vm.Login(e.username, e.password, e.captcha);
                if (!String.IsNullOrEmpty(reason))
                    await Dialogs.Popup("错误", reason);
                else {
                    Globals.Settings.SetActiveUser("AAO", e.username);
                    if (e.remember || Globals.Settings.HasUser("AAO", e.username))
                        Globals.Settings.UpdateAccount("AAO", e.username, e.password);
                }
            };
            
        }

        private void PageNavigate(object sender, ItemClickEventArgs e) {
            var frame = (App.Current as App).MainFrame;
            var page = (e.ClickedItem as PageButtonData).Page;

            frame.Navigate(page);
        }
    }
}
