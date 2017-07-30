using System;
using System.Threading.Tasks;

using NeuOldDriver.Net;
using NeuOldDriver.Utils;
using NeuOldDriver.Models;

namespace NeuOldDriver.ViewModels {

    public class IPGWViewModel : ViewModelBase {

        private IPGWModel model = new IPGWModel() {
            username = "", password = "", 
            used = 0, used_time = 0, balance = "", ip = ""
        };
        
        public string Used {
            get { return Sanitizer.SanitizeSize(model.used); }
            private set { model.used = Convert.ToUInt64(value); OnPropertyChanged(); }
        }

        public string UsedTime {
            get { return Sanitizer.SanitizeTime(model.used_time); }
            private set { model.used_time = Convert.ToUInt64(value); OnPropertyChanged(); }
        }

        public string Balance {
            get { return model.balance; }
            private set { model.balance = value; OnPropertyChanged(); }
        }

        public string IP {
            get { return model.ip; }
            private set { model.ip = value; OnPropertyChanged(); }
        }

        public async Task<bool> Login(string username, string password) {
            model.username = username;
            model.password = password;

            bool success = await IPGWAPI.Login(username, password);
            if (success) 
                await UpdateInfo();
            return success;
        }

        public async Task<bool> Logout() {
            return (await IPGWAPI.Logout(model.username, model.password))
                       ?.Contains("网络已断开") ?? false;
        }

        public async Task<bool> UpdateInfo() {
            var result = (await IPGWAPI.AccountInfo())?.Split(',');

            if (result == null || result.Length == 0)
                return false;

            Used = result[0];
            UsedTime = result[1];
            Balance = result[2];
            IP = result[5];
            return true;
        }
    }
}
