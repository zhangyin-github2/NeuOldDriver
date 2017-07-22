using System.Threading.Tasks;

using NeuOldDriver.Utils;

namespace NeuOldDriver.Global {

    public static class Globals {

        public static Settings Settings { get; private set; }

        public static async Task Initialize() {
            Settings = await Settings.Read();
        }

        public static async Task Dispose() {
            await Settings.Save();
        }

    }
}
