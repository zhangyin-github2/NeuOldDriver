using System;
using System.Linq;

using Windows.UI.Xaml.Controls;

// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上有介绍

namespace NeuOldDriver.Pages.AAOSubPage {
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class Recommend : Page {
        public Recommend() {
            this.InitializeComponent();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            var item = (sender as ComboBox).SelectedItem;
        }

        private void MyListBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            var selectedItems = MyListBox.Items.Cast<ListBoxItem>()
                                    .Where(p => p.IsSelected)
                                    .Select(t => t.Content.ToString());
            ListBoxResultTextBlock.Text = String.Join(",", selectedItems);
        }

    }
}
