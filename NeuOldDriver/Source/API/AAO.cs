using System;
using System.Linq;
using System.Threading.Tasks;

using Windows.Web.Http;

using NeuOldDriver.Utils;
using NeuOldDriver.Global;

using HtmlAgilityPack;

namespace NeuOldDriver.API {

    public class AAO {

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
            var node = document.GetElementbyId("Agnomen").Descendants().First();
            return String.Format("{0}/{1}", Constants.AAO_API_BASE, node.Attributes["src"].Value);
        }

        public static async Task<bool> Login(string username, string password, int captcha) {
            return await Task.Run(() => false);
        }

        public static async Task<bool> Logout(string username, string password) {
            return await Task.Run(() => false);
        }

    }
}
