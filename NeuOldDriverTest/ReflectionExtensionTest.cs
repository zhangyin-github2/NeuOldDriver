using System;
using System.Linq;

using NeuOldDriver.Extensions;

using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace NeuOldDriverTest {

    [TestClass]
    public class ReflectionExtensionTest {

        internal class Tester {
            public int I { get; set; }
            public long L { get; set; }
            private double D { get; set; }

            public Tester(double d = 0) {
                D = d;
            }
        };

        [TestMethod]
        public void ReflectionGetValueTest() {
            var t = new Tester() { I = 21417, L = 1 };
            Assert.AreEqual(t.I, t.GetValue("I"));
            Assert.AreEqual(t.L, t.GetValue<long>("L"));
            Assert.IsNull(t.GetValue("D"));
            Assert.IsNull(t.GetValue("WTF"));
            Assert.ThrowsException<InvalidCastException>(() => {
                t.GetValue<double>("L");
            });
        }

        [TestMethod]
        public void ReflectionGetPropertiesTest() {
            var t = new Tester();
            var names = t.GetPropertyNames();
            Assert.IsNotNull(names);
            Assert.AreEqual(2, names.Count());
            Assert.IsTrue(names.Contains("I"));
            Assert.IsTrue(names.Contains("L"));
        }

        [TestMethod]
        public void ReflectionPropertyValueTest() {
            var t = new Tester(3.14) {
                I = 5, L = 100000
            };
            // property-name pairs
            var pvp = t.GetPropertyValuePairs();
            Assert.AreEqual(2, pvp.Count);
            Assert.IsTrue(pvp.Keys.Contains("I"));
            Assert.IsTrue(pvp.Keys.Contains("L"));
            Assert.AreEqual(t.I, pvp["I"]);
            Assert.AreEqual(t.L, pvp["L"]);
        }
    }
}
