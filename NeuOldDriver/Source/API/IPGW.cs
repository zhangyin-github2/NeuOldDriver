using System;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;

using Windows.Web.Http;

using NeuOldDriver.Utils;
using NeuOldDriver.Global;

namespace NeuOldDriver.API {

    public static class IPGW {

        /// <summary>
        /// Try to login into ipgw.neu.edu.cn
        /// </summary>
        /// <param name="username">user name</param>
        /// <param name="password">password, not encrypted</param>
        /// <returns>true on success</returns>
        public static async Task<bool> Login(string username, string password) {
            var sb = new StringBuilder();
            sb.Append("action=").Append("login")
              .Append("&ac_id=").Append(1)
              .Append("&save_me=").Append(0)
              .Append("&user_ip=").Append("&nas_ip=").Append("&user_mac=").Append("&url=")
              .Append("&username=").Append(WebUtils.UrlEncode(username))
              .Append("&password=").Append(WebUtils.UrlEncode(password));

            return await WebUtils.NetworkRequest(Constants.IPGW_AUTH, sb.ToString(), (request) => {
                request.Headers.Add("Referer", Constants.IPGW_LOGIN);
                request.Headers.Add("Accept", "text/html, application/xhtml+xml, image/jxr, */*");
            }, async (response) => {
                return await Task.Run(() => {
                    string ret;
                    return response.Headers.TryGetValue("Set-Cookie", out ret) && ret.Contains("login");
                });
            }, HttpMethod.Post);
        }

        /// <summary>
        /// Try to logout from ipgw.neu.edu.cn
        /// </summary>
        /// <param name="username">username</param>
        /// <param name="password">password, not encrypted</param>
        /// <returns>result string returned from server</returns>
        public static async Task<string> Logout(string username, string password) {
            var sb = new StringBuilder();
            sb.Append("action=").Append("logout")
              .Append("&ajax=").Append(1)
              .Append("&username=").Append(WebUtils.UrlEncode(username))
              .Append("&password=").Append(WebUtils.UrlEncode(password));

            return await WebUtils.NetworkRequest(Constants.IPGW_AUTH, sb.ToString(), (request) => {
                request.Headers.Add("Referer", Constants.IPGW_AUTH);
                request.Headers.Add("Accept", "*/*");
            }, async (response) => {
                var buffer = await response.Content.ReadAsBufferAsync();
                return Encoding.UTF8.GetString(buffer.ToArray());
            }, HttpMethod.Post);
        }

        /// <summary>
        /// Get account info from server, must be called after a successful <c>Login</c>
        /// </summary>
        /// <returns>account info in lookup table format</returns>
        public static async Task<IDictionary<string, string>> AccountInfo() {
            // mysterious paramter required by API
            var rand = new Random(DateTime.Now.Millisecond).NextDouble();
            int k = Convert.ToInt32(Math.Floor(rand * (100000 + 1)));

            return await WebUtils.NetworkRequest(String.Format("{0}?k={1}", Constants.IPGW_AUTH, k),
                String.Format("action=get_online_info&key={0}", k), (request) => {
                    request.Headers.Referer = new Uri(Constants.IPGW_LOGIN);
                    request.Headers.Add("Accept", "*/*");
                }, async (response) => {
                    var content = (await response.Content.ReadAsStringAsync())?.Split(',');

                    if (content == null || content.Length == 0)
                        return null;

                    return new Dictionary<string, string>() {
                        {"Used", content[0] },
                        {"UsedTime", content[1] },
                        {"Balance", content[2] },
                        {"IP", content[5] }
                    };
                }, HttpMethod.Post);
        }

    }

}
