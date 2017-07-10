using System;
using System.Runtime.InteropServices.WindowsRuntime;

using Windows.UI.Xaml.Controls;

using NeuOldDriver.Models;

namespace NeuOldDriver.Controls {

    public sealed partial class Login : UserControl {

        private EventRegistrationTokenTable<EventHandler<LoginData>> m_tokenTable = null;

        public event EventHandler<LoginData> Finished {
            add {
                EventRegistrationTokenTable<EventHandler<LoginData>>
                .GetOrCreateEventRegistrationTokenTable(ref m_tokenTable)
                .AddEventHandler(value);
            }
            remove {
                EventRegistrationTokenTable<EventHandler<LoginData>>
                .GetOrCreateEventRegistrationTokenTable(ref m_tokenTable)
                .RemoveEventHandler(value);
            }
        }

        internal void OnFinished() {
            EventRegistrationTokenTable<EventHandler<LoginData>>
            .GetOrCreateEventRegistrationTokenTable(ref m_tokenTable)
            .InvocationList
            ?.Invoke(this, new LoginData(username.Text, password.Password, remember.IsChecked ?? false));
        }

        public Login() {
            this.InitializeComponent();

            okButton.Click += (sender, args) => {
                OnFinished();
            };
        }
    }
}
