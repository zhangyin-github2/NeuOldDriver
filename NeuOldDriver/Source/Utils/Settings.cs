using System;
using System.Threading.Tasks;
using System.Collections.Generic;

using Windows.Data.Json;
using Windows.Storage;

using NeuOldDriver.Json;
using NeuOldDriver.Global;

namespace NeuOldDriver.Utils {

    public class Settings {

        private JsonObject root;

        public Settings(JsonObject obj) {
            root = obj;
        }

        /// <summary>
        /// Create an empty setting file
        /// </summary>
        /// <returns>basic empty settings structure in JsonObject format</returns>
        private static JsonObject EmptySetting() {
            return (new JsonObject())
                .SetObject("AAO", (new JsonObject()).SetString("active", "").SetObject("users", new JsonObject()))
                .SetObject("IPGW", (new JsonObject()).SetString("active", "").SetObject("users", new JsonObject()));
        }

        /// <summary>
        /// Initialize <c>Settings</c> object from a file at given path
        /// </summary>
        /// <param name="name">name of settings file</param>
        /// <returns>initialized object</returns>
        public static async Task<Settings> Read(string name = Constants.SETTINGS) {
            var file = await ApplicationData.Current.LocalFolder.CreateFileAsync(name, CreationCollisionOption.OpenIfExists);
            var content = await FileIO.ReadTextAsync(file);
            JsonObject res;
            if (!JsonObject.TryParse(content, out res))
                res = EmptySetting();
            return new Settings(res);
        }

        public async Task Save(string name = Constants.SETTINGS) {
            var file = await ApplicationData.Current.LocalFolder.CreateFileAsync(name, CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(file, root.ToString());
        }

        public void Clear() {
            root = EmptySetting();
        }

        private JsonObject Accounts(string category) {
            return root.GetValue(category).GetObject();
        }

        public void UpdateAccount(string category, string username, string password) {
            Accounts(category).GetObject("users").SetString(username, password);
        }
        
        public string GetPassword(string category, string username) {
            return Accounts(category).GetObject("users").GetValue(username)?.GetString();
        }

        public void SetActiveUser(string category, string username) {
            Accounts(category).SetString("active", username);
        }

        public void ActiveUser(string category, out string username, out string password) {
            var accounts = Accounts(category);
            var active = accounts.GetString("active");
            if(active != null) {
                username = active;
                password = accounts.GetObject("users").GetString(active);
            } else 
                username = password = null;
        }
        
        public ICollection<string> Users(string category) {
            return Accounts(category).GetObject("users").Keys;
        }

        public bool HasUser(string category, string username) {
            return Users(category).Contains(username);
        }
    };
}
