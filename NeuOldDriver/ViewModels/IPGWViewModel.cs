using System;
using System.Threading.Tasks;

using NeuOldDriver.Net;
using NeuOldDriver.Utils;
using NeuOldDriver.Models;

namespace NeuOldDriver.ViewModels {

    public class IPGWViewModel : ViewModelBase {

        private IPGWModel model = new IPGWModel() {
            username = "", password = "", logged = false,
            used = 0, used_time = 0, balance = "", ip = ""
        };
        
        public bool NotLogged {
            get { return !model.logged; }
            private set { model.logged = !value; OnPropertyChanged("NotLogged"); OnPropertyChanged("Logged"); }
        }

        public bool Logged {
            get { return model.logged; }
        }

        public string Used {
            get { return CommonUtils.SanitizeSize(model.used); }
            private set { model.used = Convert.ToUInt64(value); OnPropertyChanged("Used"); }
        }

        public string UsedTime {
            get { return CommonUtils.SanitizeTime(model.used_time); }
            private set { model.used_time = Convert.ToUInt64(value); OnPropertyChanged("UsedTime"); }
        }

        public string Balance {
            get { return model.balance; }
            private set { model.balance = value; OnPropertyChanged("Balance"); }
        }

        public string IP {
            get { return model.ip; }
            private set { model.ip = value; OnPropertyChanged("IP"); }
        }

        public async Task<bool> Login(string username, string password) {
            model.username = username;
            model.password = password;

            bool success = await IPGW.Login(username, password);
            if (success) {
                NotLogged = false;
                await UpdateInfo();
            }
            return success;
        }

        public async Task<bool> Logout() {
            var success = (await IPGW.Logout(model.username, model.password))
                            ?.Contains("网络已断开") ?? false;

            if (success) 
                NotLogged = true;
            
            return success;
        }

        public async Task<bool> UpdateInfo() {
            var result = await IPGW.AccountInfo();

            if(result != null) {
                Used = result["Used"];
                UsedTime = result["UsedTime"];
                Balance = result["Balance"];
                IP = result["IP"];
                return true;
            }
            return false;
        }
    }
}
