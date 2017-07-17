using System;
using System.Threading.Tasks;

using Windows.Web.Http;

namespace NeuOldDriver.Utils {

    public static class WebUtils {

        public static HttpClient Client { get; } = new HttpClient();

        public static async Task<Ret> NetworkRequest<Ret>(string url, HttpMethod method, Func<HttpResponseMessage, Task<Ret>> responseHandler) {
            using (var request = new HttpRequestMessage(method, new Uri(url)))
            using (var response = await Client.SendRequestAsync(request))
                return await responseHandler(response);
        }

        public static async Task<Ret> NetworkRequest<Ret>(Action<HttpRequestMessage> requestModifier, Func<HttpResponseMessage, Task<Ret>> responseHandler) {
            using (var request = new HttpRequestMessage()) {
                requestModifier(request);
                using (var response = await Client.SendRequestAsync(request))
                    return await responseHandler(response);
            }
        }

    }
}
