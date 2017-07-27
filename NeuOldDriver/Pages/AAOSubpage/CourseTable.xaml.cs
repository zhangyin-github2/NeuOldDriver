using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;

using NeuOldDriver.Net;

// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上有介绍

namespace NeuOldDriver.Pages.AAOSubPage {
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class CourseTable : Page {

        public CourseTable() {
            this.InitializeComponent();

            for (var i = 1; i <= 20; ++i)
                comboBox1.Items.Add(String.Format("第{0}周", i));
            comboBox1.SelectedIndex = 0;

            this.Loaded += LoadDataAsync;
        }

        private async void LoadDataAsync(object sender, RoutedEventArgs e) {
            vm.LoadCourses(await AAOAPI.RequestInfomation("学生课程表"));

            BindingOperations.SetBinding(comboBox1, ComboBox.SelectedIndexProperty, new Binding() {
                Source = vm,
                Path = new PropertyPath("Week"),
                Mode = BindingMode.TwoWay,
                UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
            });

            for (var cno = 1; cno <= 6; ++cno) {
                for (var weekday = 1; weekday <= 7; ++weekday) {
                    var text = new TextBlock() {
                        Foreground = new SolidColorBrush(Colors.White),
                        HorizontalAlignment = HorizontalAlignment.Center,
                        VerticalAlignment = VerticalAlignment.Center
                    };
                    Grid.SetColumn(text, weekday);
                    Grid.SetRow(text, cno);
                    CoursesContainer.Children.Add(text);
                    BindingOperations.SetBinding(text, TextBlock.TextProperty, new Binding() {
                        Source = vm[weekday - 1][cno - 1],
                        Path = new PropertyPath("Text"),
                        Mode = BindingMode.OneWay,
                        UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
                    });
                }
            }
        }

    };
}
