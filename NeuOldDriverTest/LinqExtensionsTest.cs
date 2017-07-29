using System;

using NeuOldDriver.Extensions;

using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace NeuOldDriverTest {

    [TestClass]
    public class LinqExtensionsTest {

        [TestMethod]
        public void ForEachTest() {
            int[] empty = { };
            int[] src = { 1, 2, 3, 4, 6 };
            // random init value for res1, res2
            int res1 = 8464, res2 = 5;
            empty.ForEach(i => res1 += i);
            src.ForEach(i => res2 += i);

            Assert.AreEqual(8464, res1);
            Assert.AreEqual(21, res2);
        }

        [TestMethod]
        public void ForEachBreakTest() {
            int[] src = { 1, -9, 5, 88, 75 };
            int res = 0;
            src.ForEach((i) => {
                if (i <= 10) {
                    res += i;
                    return true;
                } else
                    return false;
            });

            Assert.AreEqual(-3, res);
        }

        [TestMethod]
        public void MergeTest() {
            int[] src1 = { 1, 2, 3 };
            int[] src2 = { };
            int[] src3 = { 4 };

            int[][] src = { src1, src2, src3 };

            int res = 0;

            src.Merge().ForEach(i => res += i);
            Assert.AreEqual(10, res);
        }

        [TestMethod]
        public void SameTest() {
            int[] src1 = { 1, 2, 3 };
            int[] src2 = { 1, 2 };
            int[] src3 = { 1, 2, 4 };
            int[] src4 = { 1, 2, 3 };

            Assert.IsTrue(src1.Same(src1));
            Assert.ThrowsException<NullReferenceException>(() => {
                src1.Same(null);
            });
            Assert.IsFalse(src1.Same(src2));
            Assert.IsFalse(src1.Same(src3));
            Assert.IsTrue(src1.Same(src4));
        }
    }
}
