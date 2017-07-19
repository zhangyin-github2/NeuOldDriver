using System;

using Windows.UI.Xaml;

namespace NeuOldDriver.Utils {

    public enum TimerState {
        Stopped, Running, Paused
    };

    public class CountdownTimer {

        private DispatcherTimer m_timer;
        private TimerState m_state;
        private uint m_seconds;
        private uint m_countdown;

        /// <summary>
        /// Current timer state
        /// </summary>
        public TimerState State { get { return m_state; } }

        /// <summary>
        /// Countdown seconds left
        /// </summary>
        public uint Seconds { get { return m_seconds; } }

        public uint Countdown {
            get { return m_countdown; }
            set {
                m_timer.Stop();
                m_seconds = m_countdown = value;
                m_state = TimerState.Stopped;
            }
        }

        public event EventHandler<uint> Tick;

        public event EventHandler Done;

        /// <summary>
        /// Create a timer
        /// </summary>
        /// <param name="seconds">countdown from seconds</param>
        /// <param name="interval">count interval (in seconds)</param>
        public CountdownTimer(uint seconds, uint interval = 1) {
            m_seconds = seconds;
            m_countdown = seconds;
            m_state = TimerState.Stopped;

            m_timer = new DispatcherTimer() {
                Interval = TimeSpan.FromSeconds(interval)
            };
            m_timer.Tick += (sender, e) => {
                System.Diagnostics.Debug.WriteLine(m_seconds);
                if (--m_seconds == 0) {
                    m_timer.Stop();
                    m_state = TimerState.Stopped;
                    Done?.Invoke(this, new EventArgs());
                }
                Tick?.Invoke(this, m_seconds);
            };
        }

        public void Start() {
            m_timer.Start();
            m_state = TimerState.Running;
        }

        public void Restart() {
            m_timer.Stop();
            m_seconds = m_countdown;
            Start();
        }

        public void Pause() {
            m_timer.Stop();
            m_state = TimerState.Paused;
        }

        public void Resume() {
            m_timer.Start();
            m_state = TimerState.Running;
        }

        public void Stop() {
            m_timer.Stop();
            m_state = TimerState.Stopped;
        }

    }
}
