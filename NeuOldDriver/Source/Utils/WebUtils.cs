using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Windows.Web.Http;
using Windows.Web.Http.Filters;

using NeuOldDriver.Global;

namespace NeuOldDriver.Utils {

    public static class WebUtils {

        public static HttpClient Client { get; } = new HttpClient();

        private static HttpStringContent UTF8StringContent(string content) {
            return new HttpStringContent(content,
                                         Windows.Storage.Streams.UnicodeEncoding.Utf8,
                                         Constants.ACCEPT_FORM);
        }

        private static HttpCookieManager AllCookies() {
            return new HttpBaseProtocolFilter().CookieManager;
        }

        public static HttpCookie GetCookie(string name, string uri = Constants.AAO_BASE) {
            return AllCookies().GetCookies(new Uri(uri))
                               .Where((x) => x.Name == name)
                               .FirstOrDefault();
        }

        public static string GetCookieValue(string name, string uri = Constants.AAO_BASE) {
            return GetCookie(name, uri)?.Value;
        }

        public static bool HasCookie(string name, string uri = Constants.AAO_BASE) {
            return GetCookie(name, uri) != null;
        }

        public static async Task<Ret> NetworkRequest<Ret>(HttpRequestMessage request, Func<HttpResponseMessage, Task<Ret>> responseHandler, int timeout = 5) {
            using (var cts = new CancellationTokenSource()) {
                cts.CancelAfter(TimeSpan.FromSeconds(timeout));
                using (var response = await Client.SendRequestAsync(request).AsTask(cts.Token)) {
                    try {
                        return await responseHandler(response);
                    } catch(TaskCanceledException) {
                        return default(Ret);
                    } 
                }
            }
        }

        public static async Task<Ret> NetworkRequest<Ret>(string url, Func<HttpResponseMessage, Task<Ret>> responseHandler, HttpMethod method, int timeout = 5) {
            using (var request = new HttpRequestMessage(method, new Uri(url)))
                return await NetworkRequest(request, responseHandler, timeout);
        }

        public static async Task<Ret> NetworkRequest<Ret>(Action<HttpRequestMessage> requestModifier, Func<HttpResponseMessage, Task<Ret>> responseHandler, int timeout = 5) {
            using (var request = new HttpRequestMessage()) {
                requestModifier(request);
                return await NetworkRequest(request, responseHandler, timeout);
            }
        }

    }
}
