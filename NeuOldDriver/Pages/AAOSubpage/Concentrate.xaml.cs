using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System.Threading;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上有介绍

namespace NeuOldDriver.Pages.AAOSubPage {
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class Concentrate : Page {

        private ThreadPoolTimer timer = null;

        internal enum State {
            Stopped, Running, Paused
        };

        private State state = State.Stopped;

        private int seconds = 0;

        public Concentrate() {
            this.InitializeComponent();
        }

        private void Button_Click(object _sender, RoutedEventArgs _e)
        {
            var button = _sender as Button;
            if (timer != null)
                timer.Cancel();

            const int count = 1800;

            switch (state)
            {
                case State.Running:
                    button.Content = "暂停";
                    state = State.Paused;
                    return;
                case State.Paused:
                    button.Content = "继续专注";
                    state = State.Running;
                    return;
                case State.Stopped:
                    button.Content = "暂停";
                    state = State.Running;
                    timer = ThreadPoolTimer.CreatePeriodicTimer(async (source) =>
                    {
                        await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                        {
                            seconds += 1;
                            double temp = (385 * Math.PI) * seconds / count / 15;
                            MyEllipse.StrokeDashArray = new DoubleCollection() { temp, 1000 };
                            txt.Text = String.Format("{0:00}:{1:00}", (count - seconds) / 60, (count - seconds) % 60);
                            if (seconds == count)
                            {
                                timer.Cancel();
                                seconds = 0;
                                timer = null;
                            }
                        });
                    }, TimeSpan.FromSeconds(1));
                    return;
            }
        }

    }
}
