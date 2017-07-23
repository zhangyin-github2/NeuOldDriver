using System.Collections.Generic;

using Windows.Data.Json;

using NeuOldDriver.Json;

namespace NeuOldDriver.Storage {

    public class PasswordVault {

        private string active;
        private JsonObject users;

        public PasswordVault() {
            active = "";
            users = new JsonObject();
        }

        public PasswordVault(JsonObject root) {
            active = root.GetString("active");
            users = root.GetObject("users");
        }

        /// <summary>
        /// Current active user
        /// </summary>
        public string Active {
            get { return active; }
            set { active = value; }
        }

        public ICollection<string> Users {
            get { return users.Keys; }
        }

        /// <summary>
        /// Get password, using indexer format
        /// </summary>
        /// <param name="username">username</param>
        /// <returns>password, null if not exist</returns>
        public string this[string username] {
            get { return users.GetString(username); }
            set { users.SetString(username, value); }
        }

        public static explicit operator JsonObject(PasswordVault vault) {
            return (new JsonObject()).SetString("active", vault.active)
                        .SetObject("users", vault.users);
        }

        public override string ToString() {
            return ((JsonObject)this).ToString();
        }
    };
}
