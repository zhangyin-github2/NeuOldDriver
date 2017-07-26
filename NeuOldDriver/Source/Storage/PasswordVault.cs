using System.Collections.Generic;

using Windows.Data.Json;

using NeuOldDriver.Extensions;

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
        /// Remove a user's username and password, if he is active, then active set to empty
        /// </summary>
        /// <param name="username"></param>
        public void RemoveUser(string username) {
            if (users.Remove(username)) {
                if (active == username)
                    active = "";
            }
        }

        /// <summary>
        /// Get or set password, using indexer format
        /// <para>will also set active account if we are setting a password</para>
        /// </summary>
        /// <param name="username">username</param>
        /// <returns>password, null if not exist</returns>
        public string this[string username] {
            get { return users.GetString(username); }
            set {
                users.SetString(username, value);
                active = username;
            }
        }

        /// <summary>
        /// Remove a user, do nothing if the user not exist
        /// </summary>
        /// <param name="vault">PasswordVault container</param>
        /// <param name="username"></param>
        /// <returns>modified PasswordVault object</returns>
        public static PasswordVault operator-(PasswordVault vault, string username) {
            vault.RemoveUser(username);
            return vault;
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
