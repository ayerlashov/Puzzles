using SeparateDigits;
using NUnit.Framework;

namespace SeparateDigitsTests
{
    public class SeparateDigitsTests
    {
        [Test]
        public void RegexSolverTest()
        {
            RunTests(new RegExSolver());
        }

        [Test]
        public void FastSolverTest()
        {
            RunTests(new FastSolver());
        }

        [Test]
        public void StringBuilderSolverTest()
        {
            RunTests(new StringBuilderSolver());
        }

        public void RunTests(ISeparateDigitsSolver solver)
        {
            Assert.AreEqual("1 - 0 - 0 - 0 - 0", solver.SeparateDigits(10000, 1, " - "));
            Assert.AreEqual("10", solver.SeparateDigits(10));
            Assert.AreEqual("100", solver.SeparateDigits(100));
            Assert.AreEqual("10,000,000", solver.SeparateDigits(10000000));
            Assert.AreEqual("-10,000,000", solver.SeparateDigits(-10000000));
            Assert.AreEqual("-10", solver.SeparateDigits(-10));
            Assert.AreEqual("0", solver.SeparateDigits(0, 1));
            Assert.AreEqual("-1 - 0 - 0 - 0 - 0", solver.SeparateDigits(-10000, 1, " - "));
            Assert.AreEqual("10000", solver.SeparateDigits(10000, 10, " - "));
        }
    }
}