using System;
using System.Net;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Windows.Web.Http;
using Windows.Web.Http.Filters;

using NeuOldDriver.Global;

namespace NeuOldDriver.Net {

    public static class WebUtils {

        private const int TIMEOUT = 5;

        public static HttpClient Client { get; } = new HttpClient();

        public static string UrlEncode(string url) {
            return WebUtility.UrlEncode(url);
        }

        public static HttpStringContent UTF8StringContent(string content) {
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

        private static async Task<Ret> NetworkRequest<Ret>(HttpRequestMessage request, Func<HttpResponseMessage, Task<Ret>> responseHandler, int timeout) {
            using (var cts = new CancellationTokenSource()) {
                cts.CancelAfter(TimeSpan.FromSeconds(timeout));
                try {
                    using (var response = await Client.SendRequestAsync(request).AsTask(cts.Token)) {
                        if (response.IsSuccessStatusCode)
                            return await responseHandler(response);
                        return default(Ret);
                    }
                } catch (TaskCanceledException) {
                    return default(Ret);
                } catch (Exception e) {
                    // address or host not resolvable
                    if (e.HResult == unchecked((int)(0x80072ee7)))
                        return default(Ret);
                    throw;
                }
            }
        }

        /// <summary>
        /// Issue a network request
        /// </summary>
        /// <typeparam name="Ret">expected return type after response handled</typeparam>
        /// <param name="requestModifier">modifications to be made to request</param>
        /// <param name="responseHandler">response handler</param>
        /// <param name="timeout">timeout of network request</param>
        /// <returns>returned value of response handler</returns>
        public static async Task<Ret> NetworkRequest<Ret>(Action<HttpRequestMessage> requestModifier, Func<HttpResponseMessage, Task<Ret>> responseHandler, int timeout = TIMEOUT) {
            using (var request = new HttpRequestMessage()) {
                requestModifier(request);
                return await NetworkRequest(request, responseHandler, timeout);
            }
        }

        /// <summary>
        /// Issue a network request
        /// </summary>
        /// <typeparam name="Ret">expected return type after response handled</typeparam>
        /// <param name="url">request's target url</param>
        /// <param name="content">request's content</param>
        /// <param name="responseHandler">response handler</param>
        /// <param name="method">request's method, GET, POST, etc.</param>
        /// <param name="timeout">timeout of network request</param>
        /// <returns>returned value of response handler</returns>
        public static async Task<Ret> NetworkRequest<Ret>(string url, string content, Action<HttpRequestMessage> requestModifier, Func<HttpResponseMessage, Task<Ret>> responseHandler, HttpMethod method, int timeout = TIMEOUT) {
            using (var request = new HttpRequestMessage(method, new Uri(url))) {
                requestModifier?.Invoke(request);
                if(method.Equals(HttpMethod.Post))
                    request.Content = UTF8StringContent(content);
                return await NetworkRequest(request, responseHandler, timeout);
            }
        }
    }
}
