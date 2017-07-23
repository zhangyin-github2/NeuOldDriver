using System.Linq;

using NeuOldDriver.Storage;

using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace NeuOldDriverTest {

    [TestClass]
    public class AccountsTest {

        private Accounts accounts = null;

        public AccountsTest() {
            accounts = Accounts.Read().Result;
        }

        [TestMethod]
        public void InitTest() {
            Assert.IsNotNull(accounts);
        }

        [TestMethod]
        public void CategoryTest() {
            Assert.IsNotNull(accounts["AAO"]);
            Assert.IsNotNull(accounts["IPGW"]);
            Assert.IsNull(accounts["WTF"]);
        }

        [TestMethod]
        public void LoginTest() {
            var ipgw = accounts["IPGW"];
            ipgw["20141874"] = "7";
            Assert.AreEqual("7", ipgw["20141874"]);
            Assert.IsNotNull(ipgw.Users.FirstOrDefault((item) => {
                return item == "20141874";
            }));
            Assert.IsNotNull(ipgw["20141874"]);
        }

        [TestMethod]
        public void ActiveUserTest() {
            var aao = accounts["AAO"];

            aao["20141874"] = "7";
            Assert.AreEqual("20141874", aao.Active);
            Assert.AreEqual("7", aao[aao.Active]);

            aao["1234569"] = "78";
            Assert.AreEqual("1234569", aao.Active);
            Assert.AreEqual("78", aao[aao.Active]);
        }

        [TestMethod]
        public void RemoveTest() {
            var ipgw = accounts["IPGW"];

            ipgw["20141874"] = "123456";
            ipgw -= "20141874";

            Assert.AreEqual("", ipgw.Active);
            Assert.IsNull(ipgw["20141874"]);
        }

        [TestMethod]
        public void ClearTest() {
            accounts.Clear();

            foreach (var category in new [] { "IPGW", "AAO"} ) {
                var users = accounts[category];
                Assert.IsNotNull(users.Active);
                Assert.IsTrue(users.Active.Length == 0);
                Assert.IsTrue(users.Users.Count == 0);
            }
        }

    };

}
