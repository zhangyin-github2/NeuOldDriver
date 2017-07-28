using System;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Controls;

using NeuOldDriver.Utils;

// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上有介绍

namespace NeuOldDriver.Pages.AAOSubPage {
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class Concentrate : Page {

        private const int countdown = 1800;

        private CountdownTimer timer = new CountdownTimer(countdown);

        public Concentrate() {
            this.InitializeComponent();

            timer.Tick += (sender, seconds) => {
                double temp = (385 * Math.PI) * seconds / 15;
                MyEllipse.StrokeDashArray = new DoubleCollection() { temp, 1000 };
                txt.Text = String.Format("{0:00}:{1:00}", seconds / 60, seconds % 60);
            };

            timer.Done += (sender, e) => {
                timer.Countdown = countdown;
                concentrateButton.Content = "开始专注";
            };
        }

        private void StateTransit(object sender, RoutedEventArgs e) {
            var button = sender as Button;
            switch(timer.State) {
                case TimerState.Running:
                    button.Content = "继续";
                    timer.Pause();
                    break;
                case TimerState.Paused:
                    button.Content = "暂停";
                    timer.Resume();
                    break;
                case TimerState.Stopped:
                    button.Content = "暂停";
                    timer.Start();
                    break;
            }
        }

    }
}
