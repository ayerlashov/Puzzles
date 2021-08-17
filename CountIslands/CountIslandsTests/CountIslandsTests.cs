using CountIslands;
using NUnit.Framework;

namespace CountIslandsTests
{
    public class CountIslandsTests
    {
        [Test]
        public void Test1()
        {
            var source = new[,]
            {
                {1,1,0,1,0,0,0},
                {0,1,1,1,0,1,1},
                {0,0,1,1,0,1,1},
                {1,0,0,0,0,0,0},
                {0,0,0,1,1,0,0},
                {0,1,0,1,1,0,0},
                {0,0,1,0,0,0,0},
                {0,0,0,0,0,0,0},
            };

            Assert.AreEqual(6, Solver.CountIslands(source));
        }

        [Test]
        public void Test2()
        {
            var source = new[,]
            {
                {1,1,0,1},
                {0,1,1,1},
                {0,0,1,1},
            };

            Assert.AreEqual(1, Solver.CountIslands(source));
        }

        [Test]
        public void Test3()
        {
            var source = new[,]
            {
                {1,0},
                {0,1}
            };

            Assert.AreEqual(2, Solver.CountIslands(source));
        }

        [Test]
        public void Test4()
        {
            var source = new[,]
            {
                {0,0,0,0,0,0,0},
                {0,1,1,1,1,1,0},
                {0,1,0,0,0,1,0},
                {0,1,0,1,0,1,0},
                {0,1,0,0,0,0,0},
                {0,1,0,1,0,1,0},
                {0,0,1,1,1,1,0},
                {0,0,0,0,0,0,0},
            };

            Assert.AreEqual(3, Solver.CountIslands(source));
        }

        [Test]
        public void Test5()
        {
            var source = new[,]
            {
                {1,1,1,0},
                {0,1,1,0},
                {1,1,1,0},
                {0,0,0,0},
            };

            Assert.AreEqual(1, Solver.CountIslands(source));
        }

        [Test]
        public void Test6()
        {
            var source = new[,]
            {
                {1,1,1,1,1,1,0},
                {0,0,0,0,1,1,0},
                {0,0,1,1,1,1,0},
                {0,0,0,0,1,1,0},
                {1,1,1,1,1,1,0},
                {0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0},
            };

            Assert.AreEqual(1, Solver.CountIslands(source));
        }

        [Test]
        public void Test7()
        {
            var source = new[,]
            {
                {0,0,0,0,0,0,0},
                {0,1,0,0,0,1,0},
                {0,1,0,1,1,1,0},
                {0,1,0,1,0,1,0},
                {0,1,1,1,0,1,0},
                {0,1,0,0,0,1,0},
                {0,1,1,1,1,1,0},
                {0,0,0,0,0,0,0},
            };

            Assert.AreEqual(1, Solver.CountIslands(source));
        }

        [Test]
        public void Test8()
        {
            var source = new[,]
            {
                {0,1,1},
                {1,1,1},
            };

            Assert.AreEqual(1, Solver.CountIslands(source));
        }
    }
}