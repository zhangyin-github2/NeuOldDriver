using System.Threading.Tasks;

using Windows.Web.Http;

using NeuOldDriver.Storage;

namespace NeuOldDriver.Global {

    public static class Globals {

        public static Accounts Accounts { get; private set; }
        public static HttpClient Client { get; } = new HttpClient();

        public static async Task Initialize() {
            Accounts = await Storage.Accounts.Read();
        }

        public static async Task Dispose() {
            await Accounts.Save();
            Client.Dispose();
        }

    }
}
