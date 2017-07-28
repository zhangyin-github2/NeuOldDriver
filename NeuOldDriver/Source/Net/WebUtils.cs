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

        public delegate void RequestModifier(HttpRequestMessage request);
        public delegate Task<Ret> ResponseHandler<Ret>(HttpResponseMessage response);

        public static HttpClient Client {
            get { return Globals.Client; }
        }

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

        /// <summary>
        /// Network request forwarder
        /// </summary>
        /// <typeparam name="Ret"></typeparam>
        /// <param name="request"></param>
        /// <param name="handler"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        private static async Task<Ret> NetworkRequest<Ret>(HttpRequestMessage request, ResponseHandler<Ret> handler, int timeout) {
            using (var cts = new CancellationTokenSource()) {
                cts.CancelAfter(TimeSpan.FromSeconds(timeout));
                try {
                    using (var response = await Client.SendRequestAsync(request).AsTask(cts.Token)) {
                        if (response.IsSuccessStatusCode)
                            return await handler(response);
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
        
        public static async Task<Ret> PostAsync<Ret>(string url, string content, RequestModifier modifier, ResponseHandler<Ret> handler, int timeout = TIMEOUT) {
            using (var request = new HttpRequestMessage(HttpMethod.Post, new Uri(url))) {
                modifier?.Invoke(request);
                request.Content = UTF8StringContent(content);
                return await NetworkRequest(request, handler, timeout);
            }
        }

        public static async Task<Ret> GetAsync<Ret>(string url, RequestModifier modifier, ResponseHandler<Ret> handler, int timeout = TIMEOUT) {
            using (var request = new HttpRequestMessage(HttpMethod.Get, new Uri(url))) {
                modifier?.Invoke(request);
                return await NetworkRequest(request, handler, timeout);
            }
        }
    }
}
