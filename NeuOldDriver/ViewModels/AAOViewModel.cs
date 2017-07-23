using System;
using System.Threading.Tasks;

using NeuOldDriver.API;
using NeuOldDriver.Models;

namespace NeuOldDriver.ViewModels {

    public class AAOViewModel : ViewModelBase {

        // https://stackoverflow.com/a/31899550
        private const string EMPTY_IMAGE = "x";

        private AAOModel model = new AAOModel() {
            username = "", password = "", logged = false, source = EMPTY_IMAGE,
        };

        public bool NotLogged {
            get { return !model.logged; }
            private set { model.logged = !value; OnPropertyChanged("NotLogged"); OnPropertyChanged("Logged"); }
        }

        public bool Logged {
            get { return model.logged; }
        }

        public string Source {
            get { return model.source; }
            private set { model.source = value; OnPropertyChanged("Source"); }
        }

        private async Task RefreshCaptcha() {
            Source = await AAO.CaptchaImage();
        }

        public async Task<string> Login(string username, string password, string captcha) {
            model.username = username;
            model.password = password;
            var reason = await AAO.Login(username, password, captcha);
            if (reason != null && reason.Length == 0)
                NotLogged = false;
            return reason;
        }

        public async Task<bool> Logout(string username, string password) {
            return await AAO.Logout(username, password);
        }
    }
}
