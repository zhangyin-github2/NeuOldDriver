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
            var data = new LoginData() {
                username = username.Text,
                password = password.Password,
                remember = remember.IsChecked ?? false
            };


            EventRegistrationTokenTable<EventHandler<LoginData>>
            .GetOrCreateEventRegistrationTokenTable(ref m_tokenTable)
            .InvocationList?.Invoke(this, data);
        }

        public Login() {
            this.InitializeComponent();

            okButton.Click += (sender, args) => {
                OnFinished();
            };
        }
    }
}
