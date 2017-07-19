using System;
using System.Threading.Tasks;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace NeuOldDriver.Utils {

    public static class UWPUtils {

        public static async Task Popup(string title, string content) {
            var grid = new Grid();
            grid.Children.Add(new TextBlock() {
                Text = content,
                FontSize = 25,
                VerticalAlignment = VerticalAlignment.Center,
            });
            var dialog = new ContentDialog() {
                Content = grid,
                PrimaryButtonText = "确认",
                IsSecondaryButtonEnabled = false
            };
            await dialog.ShowAsync();
        }

    }
}
