using System;
using System.Linq;

using Windows.UI.Core;
using Windows.UI.Xaml.Controls;

using NeuOldDriver.Models;

namespace NeuOldDriver {
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page {

        public MainPage() {
            this.InitializeComponent();

            (App.Current as App).MainFrame = this.mainFrame;

            Action<Frame> SetBackButton = (frame) => {
                SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility =
                frame.CanGoBack ?
                AppViewBackButtonVisibility.Visible :
                AppViewBackButtonVisibility.Collapsed;
            };

            navMenuToggle.Click += (sender, e) => {
                navMenuContainer.IsPaneOpen = !navMenuContainer.IsPaneOpen;
            };

            navMenu.SelectionChanged += (sender, e) => {
                var page = (e.AddedItems[0] as PageButtonData).Page;
                mainFrame.Navigate(page);
            };

            mainFrame.Navigating += (sender, e) => {
                if (e.SourcePageType == mainFrame.SourcePageType) 
                    e.Cancel = true;
            };

            mainFrame.Navigated += (sender, e) => {
                var pageInList = navMenu.Items.FirstOrDefault((item) => {
                    var pageType = (item as PageButtonData).Page;
                    return pageType == e.SourcePageType;
                });

                if (pageInList != null) {
                    navMenu.SelectedItem = pageInList;
                    mainFrame.BackStack.Clear();
                }

                SetBackButton(sender as Frame);
            };

            SystemNavigationManager.GetForCurrentView().BackRequested += (sender, e) => {
                if (mainFrame.CanGoBack) {
                    e.Handled = true;
                    mainFrame.GoBack();
                }
            };

            SetBackButton(mainFrame);
            navMenu.SelectedIndex = 0;
        }
    }
}
