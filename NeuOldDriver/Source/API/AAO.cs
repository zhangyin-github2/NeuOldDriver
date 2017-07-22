using System;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Windows.Web.Http;

using NeuOldDriver.Utils;
using NeuOldDriver.Global;

using HtmlAgilityPack;

namespace NeuOldDriver.API {

    public static class AAO {

        /// <summary>
        /// Extract captcha image source url from requested html
        /// </summary>
        /// <returns>source url of image</returns>
        public static async Task<string> CaptchaImage() {
            var content = await WebUtils.NetworkRequest(Constants.AAO_API_BASE, "", null, async (response) => {
                return await response.Content.ReadAsStringAsync();
            }, HttpMethod.Get);
            var document = new HtmlDocument();
            document.LoadHtml(content);
            // this node is the target element, should be a <img>
            var img = document.GetElementbyId("Agnomen").ParentNode.Element("img");
            return String.Format("{0}/{1}", Constants.AAO_API_BASE, img.Attributes["src"].Value);
        }

        /// <summary>
        /// Try to login into aao.neu.edu.cn
        /// </summary>
        /// <param name="username">username</param>
        /// <param name="password">password</param>
        /// <param name="captcha">captcha</param>
        /// <returns>reason of login failure, empty if success</returns>
        public static async Task<string> Login(string username, string password, string captcha) {
            var url = Constants.AAO_API_BASE + "/ACTIONLOGON.APPPROCESS?mode=";
            var sb = new StringBuilder();
            sb.Append("WebUserNO=").Append(WebUtility.UrlEncode(username))
              .Append("&Password=").Append(WebUtility.UrlEncode(password))
              .Append("&Agnomen=").Append(captcha)
              .Append("&submit7=%B5%C7%C2%BC");

            return await WebUtils.NetworkRequest(url, sb.ToString(), (request) => {
                request.Headers.Add("Accept", "text/html, application/xhtml+xml, image/jxr, */*");
                request.Headers.Add("Referer", Constants.AAO_API_BASE);
            }, async (response) => { 
                var regex = @"<script language=""JavaScript"">\s*alert\(""([^""]*)""\);\s*</script>";
                var match = Regex.Match(await response.Content.ReadAsStringAsync(), regex);
                return match.Success ? match.Groups[1].Value : "";
            }, HttpMethod.Post);
        }

        public static async Task<bool> Logout(string username, string password) {
            return await Task.Run(() => false);
        }

    }
}
