using NeuOldDriver.Utils;

using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace NeuOldDriverTest {

    [TestClass]
    public class CircularEnumeratorTest {

        [TestMethod]
        public void NullTest() {
            var i = new CircularEnumerator<int>();
            Assert.AreEqual(default(int), i.Next());
        }

        [TestMethod]
        public void EnumerationTest() {
            int[] src = { 1, 2, 5, 8, -9 };
            var i = new CircularEnumerator<int>(src);
            foreach (var num in src)
                Assert.AreEqual(num, i.Next());
            foreach (var num in src)
                Assert.AreEqual(num, i.Next());
        }
    }
}
