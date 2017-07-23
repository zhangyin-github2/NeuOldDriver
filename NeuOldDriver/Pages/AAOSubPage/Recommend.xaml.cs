using System;
using System.Linq;
using System.Collections.Generic;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;

using NeuOldDriver.Linq;
using NeuOldDriver.Models;

// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上有介绍

namespace NeuOldDriver.Pages.AAOSubPage {
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class Recommend : Page {

        private ComboBox[] combos;

        public Recommend() {
            this.InitializeComponent();
            combos = new[] {
                categoryCombo, majorCombo, termCombo
            };
            this.Loaded += (sender, e) => {
                foreach (var combo in combos) {
                    combo.SelectedIndex = 0;
                    combo.SelectionChanged += FilterClasses;
                }
            };
        }

        private void FilterClasses(object sender, SelectionChangedEventArgs e) {
            vm.Reset();
            foreach (var sel in combos)
                vm.FilterBy(sel.Tag as string, sel.SelectedIndex);
        }

        private void ClassSelectionChanged(object sender, SelectionChangedEventArgs e) {
            selectedClasses.Text = String.Join(",", classesBox.SelectedItems
                                                .Select(item => (item as CourseData).Text));
        }

        private void SortClasses(object sender, RoutedEventArgs e) {
            vm.SortClasses((sender as CheckBox).IsChecked ?? false);
        }
    }
}
