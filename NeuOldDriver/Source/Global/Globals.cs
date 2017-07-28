using System.Threading.Tasks;

using Windows.Web.Http;

using NeuOldDriver.Storage;

namespace NeuOldDriver.Global {

    public static class Globals {
        
        // used for synchronization
        private static volatile bool initialized = false;
        private static Accounts accounts;

        public static Accounts Accounts {
            get {
                while (!initialized) ;
                return accounts;
            }
        }

        public static HttpClient Client { get; } = new HttpClient();

        public static async Task Initialize() {
            accounts = await Storage.Accounts.Read();
            initialized = true;
        }

        public static async Task Dispose() {
            await Accounts.Save();
            Client.Dispose();
        }

    }
}
