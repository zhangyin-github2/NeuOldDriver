using System;
using System.Linq;

using Windows.UI.Core;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;

using NeuOldDriver.Controls;

namespace NeuOldDriver {
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page {

        public MainPage() {
            this.InitializeComponent();

            NavMenuToggle.Click += (sender, e) => {
                NavMenuContainer.IsPaneOpen = !NavMenuContainer.IsPaneOpen;
            };

            MainFrame.Navigated += (sender, e) => {
                SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility =
                    (sender as Frame).CanGoBack ?
                    AppViewBackButtonVisibility.Visible :
                    AppViewBackButtonVisibility.Collapsed;

                NavMenu.SelectedItem = NavMenu.Items.FirstOrDefault((item) => {
                    return ((item as NavButtonData).Page as Type) == MainFrame.SourcePageType;
                });
            };

            SystemNavigationManager.GetForCurrentView().BackRequested += (sender, e) => {
                if (MainFrame.CanGoBack) {
                    e.Handled = true;
                    MainFrame.GoBack();
                }
            };

            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility =
                MainFrame.CanGoBack ?
                AppViewBackButtonVisibility.Visible :
                AppViewBackButtonVisibility.Collapsed;
        }

        private void PageNavigate(object sender, SelectionChangedEventArgs e) {
            var page = ((sender as Selector).SelectedItem as NavButtonData).Page as Type;
            if (MainFrame.SourcePageType != page)
                MainFrame.Navigate(page);
        }
    }
}
