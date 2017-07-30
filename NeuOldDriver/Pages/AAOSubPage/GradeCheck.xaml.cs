using System.Linq;

using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Controls;

using NeuOldDriver.Net;
using NeuOldDriver.Utils;
using NeuOldDriver.Extensions;

// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上有介绍

namespace NeuOldDriver.Pages.AAOSubPage {

    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class GradeCheck : Page {

        public GradeCheck() {
            this.InitializeComponent();
            this.Loaded += LoadDataAsync;

            var color2 = Resources["Color2"] as SolidColorBrush;
            var color3 = Resources["Color3"] as SolidColorBrush;

            var color = new CircularEnumerator<SolidColorBrush>(color2, color3);
            for (var row = 1; row <= 20; ++row) {
                var border = new Border() {
                    Background = color.Next()
                };
                Grid.SetRow(border, row);
                Grid.SetColumnSpan(border, 6);
                gradesContainer.Children.Add(border);
            }
        }

        private async void LoadDataAsync(object sender, RoutedEventArgs e) {
            vm.LoadGrades(await AAOAPI.RequestInfomation("学生成绩查询"));

            int row = 1, col;
            vm.Grades.Select(grade => grade.Serialize()).ForEach((list) => {
                col = 0;
                list.ForEach((prop) => {
                    var block = new TextBlock() {
                        Text = prop,
                        Foreground = new SolidColorBrush(Colors.White),
                        HorizontalAlignment = HorizontalAlignment.Center,
                        VerticalAlignment = VerticalAlignment.Center
                    };
                    Grid.SetColumn(block, col++);
                    Grid.SetRow(block, row);
                    gradesContainer.Children.Add(block);
                });
                ++row;
            });
        }
        
    }
}
