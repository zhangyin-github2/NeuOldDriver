using System.Linq;

using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

using NeuOldDriver.Net;
using NeuOldDriver.Utils;
using NeuOldDriver.Extensions;

// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上有介绍

namespace NeuOldDriver.Pages.AAOSubPage {
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class ExamRoom : Page {

        public ExamRoom() {
            this.InitializeComponent();
            this.Loaded += LoadDataAsync;

            var color2 = Resources["Color2"] as SolidColorBrush;
            var color3 = Resources["Color3"] as SolidColorBrush;

            using (var color = new CircularEnumerator<SolidColorBrush>(color2, color3)) {
                for (var row = 1; row <= 20; ++row) {
                    var border = new Border() {
                        Background = color.Next()
                    };
                    Grid.SetRow(border, row);
                    Grid.SetColumnSpan(border, 4);
                    roomContainer.Children.Add(border);
                }
            }
        }

        private async void LoadDataAsync(object sender, RoutedEventArgs e) {
            vm.LoadRoom(await AAOAPI.RequestInfomation("考试日程查询"));

            int row = 1, col;
            vm.Rooms.Select(room => room.Serialize()).ForEach((list) => {
                col = 0;
                list?.ForEach(prop => {
                    var block = new TextBlock() {
                        Text = prop,
                        Foreground = new SolidColorBrush(Colors.White),
                        HorizontalAlignment = HorizontalAlignment.Center,
                        VerticalAlignment = VerticalAlignment.Center
                    };
                    Grid.SetColumn(block, col++);
                    Grid.SetRow(block, row);
                    roomContainer.Children.Add(block);
                });
                ++row;
            });
        }

    }
}
