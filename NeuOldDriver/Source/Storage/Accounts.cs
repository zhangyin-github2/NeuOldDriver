using System;
using System.Threading.Tasks;

using Windows.Data.Json;
using Windows.Storage;

using NeuOldDriver.Json;
using NeuOldDriver.Global;

namespace NeuOldDriver.Storage {

    public class Accounts {

        public PasswordVault IPGW { get; set; }
        public PasswordVault AAO { get; set; }

        public Accounts() {
            IPGW = new PasswordVault();
            AAO = new PasswordVault();
        }

        public Accounts(JsonObject root) {
            IPGW = new PasswordVault(root.GetObject("IPGW"));
            AAO = new PasswordVault(root.GetObject("AAO"));
        }

        /// <summary>
        /// Initialize <c>Settings</c> object from a file at given path
        /// </summary>
        /// <param name="name">name of settings file</param>
        /// <returns>initialized object</returns>
        public static async Task<Accounts> Read(string path = Constants.SETTINGS) {
            var file = await ApplicationData.Current.LocalFolder.CreateFileAsync(path, CreationCollisionOption.OpenIfExists);
            var content = await FileIO.ReadTextAsync(file);
            JsonObject res;
            if (!JsonObject.TryParse(content, out res))
                return new Accounts();
            return new Accounts(res);
        }

        public async Task Save(string path = Constants.SETTINGS) {
            var file = await ApplicationData.Current.LocalFolder.CreateFileAsync(path, CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(file, this.ToString());
        }

        public void Clear() {
            IPGW = new PasswordVault();
            AAO = new PasswordVault();
        }

        public PasswordVault this[string category] {
            get {
                switch (category) {
                    case "IPGW": return IPGW;
                    case "AAO": return AAO;
                    default: return null;
                }
            }
        }

        public static explicit operator JsonObject(Accounts obj) {
            return (new JsonObject()).SetObject("IPGW", (JsonObject)obj.IPGW)
                        .SetObject("AAO", (JsonObject)obj.AAO);
        }

        public override string ToString() {
            return ((JsonObject)this).ToString();
        }
    };

}
