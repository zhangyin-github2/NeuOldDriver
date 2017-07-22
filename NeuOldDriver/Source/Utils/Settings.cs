using System;
using System.Threading.Tasks;
using System.Collections.Generic;

using Windows.Data.Json;
using Windows.Storage;

using NeuOldDriver.Global;

namespace NeuOldDriver.Utils {

    public class Settings {

        private JsonObject root;

        public Settings(JsonObject obj) {
            root = obj;
        }

        /// <summary>
        /// Initialize <c>Settings</c> object from a file at given path
        /// </summary>
        /// <param name="name">name of settings file</param>
        /// <returns>initialized object</returns>
        public static async Task<Settings> Read(string name = Constants.SETTINGS) {
            var file = await ApplicationData.Current.LocalFolder.CreateFileAsync(name, CreationCollisionOption.OpenIfExists);
            var content = await FileIO.ReadTextAsync(file);
            System.Diagnostics.Debug.WriteLine(file.Path);
            JsonObject res;
            if (!JsonObject.TryParse(content, out res)) {
                res = new JsonObject();
                var aaoData = new JsonObject();
                aaoData.SetNamedValue("active", JsonValue.CreateStringValue(""));
                aaoData.SetNamedValue("users", new JsonObject());
                res.SetNamedValue("AAO", aaoData);
                var ipgwData = new JsonObject();
                ipgwData.SetNamedValue("active", JsonValue.CreateStringValue(""));
                ipgwData.SetNamedValue("users", new JsonObject());
                res.SetNamedValue("IPGW", ipgwData);
            }
            return new Settings(res);
        }

        public async Task Save(string name = Constants.SETTINGS) {
            var file = await ApplicationData.Current.LocalFolder.CreateFileAsync(name, CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(file, root.ToString());
        }

        private JsonObject Accounts(string category) {
            IJsonValue accounts;
            if (root.TryGetValue(category, out accounts))
                return accounts.GetObject();
            return null;
        }

        public bool UpdateAccount(string category, string username, string password) {
            IJsonValue users;
            if (Accounts(category).TryGetValue("users", out users)) {
                users.GetObject().SetNamedValue(username, JsonValue.CreateStringValue(password));
                return true;
            }
            return false;
        }
        
        public string GetPassword(string category, string username) {
            IJsonValue users;
            if (Accounts(category).TryGetValue("users", out users)) {
                IJsonValue result;
                if (users.GetObject().TryGetValue(username, out result))
                    return result.GetString();
            }
            return null;
        }

        public void SetActiveUser(string category, string username) {
            Accounts(category).SetNamedValue("active", JsonValue.CreateStringValue(username));
        }

        public void ActiveUser(string category, out string username, out string password) {
            IJsonValue active;
            if (Accounts(category).TryGetValue("active", out active)) {
                username = active.GetString();
                password = GetPassword(category, username);
            }
            username = password = null;
        }
        
        public ICollection<string> Users(string category) {
            IJsonValue users;
            if(Accounts(category).TryGetValue("users", out users))
                return users.GetObject().Keys;
            return null;
        }
    };
}
