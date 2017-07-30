using System;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

using NeuOldDriver.Net;
using NeuOldDriver.Utils;
using NeuOldDriver.Models;

// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上有介绍

namespace NeuOldDriver.Pages {
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class AAO : Page {

        public AAO() {
            this.InitializeComponent();

            login.Refresh += async (sender, e) => {
                return await AAOAPI.CaptchaImage();
            };

            login.Submit += async (sender, e) => {
                var reason = await AAOAPI.Login(e.username, e.password, e.captcha);
                if (!String.IsNullOrEmpty(reason)) {
                    await Dialogs.Popup("错误", reason);
                    return false;
                }
                return true;
            };
            
        }

        private async void PageNavigate(object sender, ItemClickEventArgs e) {
            var frame = (App.Current as App).MainFrame;
            var page = (e.ClickedItem as PageButtonData).Page;

            if(page == null) {
                await Dialogs.Popup("提示", "该页面尚未实现，请耐心等待下一个版本！");
                return;
            }

            frame.Navigate(page);
        }

        private async void Logout(object sender, RoutedEventArgs e) {
            await AAOAPI.Logout(login.UserName, login.Password);
            await login.ClearState();
        }
    }
}
