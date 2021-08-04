using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ContainerWithMostWater
{
    static class Program
    {
        static readonly Random Rand = new ();

        static void Main()
        {
            var rand = new Random();
            var testData = GenerateTestData(100000, 50).ToArray();

            var validationRes = Validate(MaxAreaSolver_Fast.Solve);

            var sw = new Stopwatch();

            var complexTime = 0L;
            var fastTime = 0L;

            sw.Restart();

            for (int i = 0; i < testData.Length; i++)
            {
                MaxAreaSolver_Complex.Solve(testData[i]);
            }

            sw.Stop();
            complexTime += sw.ElapsedMilliseconds;

            sw.Restart();

            for (int i = 0; i < testData.Length; i++)
            {
                MaxAreaSolver_Fast.Solve(testData[i]);
            }

            sw.Stop();
            fastTime += sw.ElapsedMilliseconds;
        }

        private static bool Validate(Func<int[], int> solver) => 
            GenerateTestData(100, 50).All(a => solver(a) == MaxAreaSolver_Naive.Solve(a));

        private static IEnumerable<int[]> GenerateTestData(int arraySize, int arrayCount) =>
            Enumerable.Range(0, arrayCount)
                .Select(_ => Enumerable.Range(0, arraySize)
                                       .Select(_ => Rand.Next(0, 100000))
                                       .ToArray());
    }
}
