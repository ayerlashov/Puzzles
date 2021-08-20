using MinimumWindowSubstring;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [Test]
        public void BaseTest()
        {
            Assert.AreEqual("BANC", Solver.MinWindow("ADOBECODEBANC", "ABC"));
        }

        [Test]
        public void EmptyStringTest()
        {
            Assert.AreEqual("", Solver.MinWindow("ZXZXZXZXZXZAXZXBZXZ", "ABC"));
        }

        [Test]
        public void AllEqualTest()
        {
            Assert.AreEqual("aa", Solver.MinWindow("aa", "aa"));
        }

        [Test]
        public void ExtraTest()
        {
            Assert.AreEqual("ba", Solver.MinWindow("bba", "ab"));
        }
    }
}