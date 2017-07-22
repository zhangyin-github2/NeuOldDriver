using System.Linq;

using NeuOldDriver.Utils;

using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace NeuOldDriverTest {

    [TestClass]
    public class SettingsTest {

        private Settings settings = null;

        public SettingsTest() {
            settings = Settings.Read().Result;
        }

        [TestMethod]
        public void InitTest() {
            Assert.IsNotNull(settings);
        }

        [TestMethod]
        public void LoginTest() {
            settings.UpdateAccount("IPGW", "20141874", "7");
            Assert.AreEqual("7", settings.GetPassword("IPGW", "20141874"));
            var users = settings.Users("IPGW");
            Assert.IsNotNull(users.FirstOrDefault((item) => {
                return item == "20141874";
            }));
        }

        [TestMethod]
        public void ActiveUserTest() {
            string username, password;
            settings.UpdateAccount("IPGW", "20141874", "7");
            settings.SetActiveUser("IPGW", "20141874");
            settings.ActiveUser("IPGW", out username, out password);
            Assert.AreEqual("20141874", username);
            Assert.AreEqual("7", password);
        }

        [TestMethod]
        public void ClearTest() {
            settings.Clear();
            string username, dummy;

            foreach (var category in new [] { "IPGW", "AAO"} ) {
                var users = settings.Users("IPGW");
                settings.ActiveUser("IPGW", out username, out dummy);
                Assert.IsTrue(users.Count == 0);
                Assert.IsTrue(username.Length == 0);
            }
        }

    };

}
