using System;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Windows.Web.Http;

using NeuOldDriver.Utils;
using NeuOldDriver.Models;
using NeuOldDriver.Global;

namespace NeuOldDriver.ViewModels {

    public class IPGWViewModel : ViewModelBase {

        internal class UserInfo {
            public ulong Used { get; set; }
            public ulong UsedTime { get; set; }
            public string Balance { get; set; }
            public string IP { get; set; }
        };

        private string username = "";
        private string password = "";
        private bool   notLogged = true;
        private UserInfo cachedInfo = new UserInfo() {
            Used = 0, UsedTime = 0, Balance = "", IP = ""
        };
        
        public bool NotLogged {
            get { return notLogged; }
            private set { notLogged = value; OnPropertyChanged("NotLogged"); }
        }

        public string Used {
            get { return CommonUtils.SanitizeSize(cachedInfo.Used); }
            private set { cachedInfo.Used = Convert.ToUInt64(value); OnPropertyChanged("Used"); }
        }

        public string UsedTime {
            get { return CommonUtils.SanitizeTime(cachedInfo.UsedTime); }
            private set { cachedInfo.UsedTime = Convert.ToUInt64(value); OnPropertyChanged("UsedTime"); }
        }

        public string Balance {
            get { return cachedInfo.Balance; }
            private set { cachedInfo.Balance = value; OnPropertyChanged("Balance"); }
        }

        public string IP {
            get { return cachedInfo.IP; }
            private set { cachedInfo.IP = value; OnPropertyChanged("IP"); }
        }

        public async Task<bool> Login(LoginData data) {
            username = data.username;
            password = data.password;

            var sb = new StringBuilder();
            sb.Append("action=").Append("login")
              .Append("&ac_id=").Append(1)
              .Append("&save_me=").Append(0)
              .Append("&user_ip=").Append("&nas_ip=").Append("&user_mac=").Append("&url=")
              .Append("&username=").Append(WebUtility.UrlEncode(username))
              .Append("&password=").Append(WebUtility.UrlEncode(password));

            var success = await WebUtils.NetworkRequest((request) => {
                request.Method = HttpMethod.Post;
                request.RequestUri = new Uri(Constants.IPGW_AUTH);
                request.Content = WebUtils.UTF8StringContent(sb.ToString());
                request.Headers.Referer = new Uri(Constants.IPGW_LOGIN);
                request.Headers.Add("Accept", "text/html, application/xhtml+xml, image/jxr, */*");
            }, async (response) => {
                // response handler must be async
                return await Task.Run(() => {
                    string ret;
                    response.Headers.TryGetValue("Set-Cookie", out ret);
                    return ret.Contains("login");
                });
            });

            if (success)
                NotLogged = false;
            return success;
        }

        public async Task<bool> Logout() {
            var sb = new StringBuilder();
            sb.Append("action=").Append("logout")
              .Append("&ajax=").Append(1)
              .Append("&username=").Append(WebUtility.UrlEncode(username))
              .Append("&password=").Append(WebUtility.UrlEncode(password));

            var success = await WebUtils.NetworkRequest((request) => {
                request.Method = HttpMethod.Post;
                request.RequestUri = new Uri(Constants.IPGW_AUTH);
                request.Headers.Referer = new Uri(Constants.IPGW_LOGIN);
                request.Content = WebUtils.UTF8StringContent(sb.ToString());
                request.Headers.Add("Accept", "*/*");
            }, async (response) => {
                return (await response.Content.ReadAsStringAsync()).Contains("网络已断开");
            });

            if (success) {
                NotLogged = true;
                Used = "0";
                UsedTime = "0";
                Balance = "";
                IP = "";
            }
            return success;
        }

        public async Task<bool> UpdateInfo() {
            var rand = new Random(DateTime.Now.Millisecond).NextDouble();
            int k = Convert.ToInt32(Math.Floor(rand * (100000 + 1)));

            var content = (await WebUtils.NetworkRequest((request) => {
                request.Method = HttpMethod.Post;
                request.RequestUri = new Uri(String.Format("{0}?k={1}", Constants.IPGW_AUTH, k));
                request.Headers.Referer = new Uri(Constants.IPGW_LOGIN);
                request.Content = WebUtils.UTF8StringContent(String.Format("action=get_online_info&key={0}", k));
                request.Headers.Add("Accept", "*/*");
            }, async (response) => {
                return await response.Content.ReadAsStringAsync();
            }))?.Split(',');

            if (content == null)
                return false;

            Used = content[0];
            UsedTime = content[1];
            Balance = content[2];
            IP = content[5];
            return true;
        }
    }
}
