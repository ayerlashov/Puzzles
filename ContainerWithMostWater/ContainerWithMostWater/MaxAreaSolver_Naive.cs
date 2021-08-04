using System;

namespace ContainerWithMostWater
{
    internal static class MaxAreaSolver_Naive
    {
        public static int Solve(int[] heights)
        {
            var res = 0;

            for (int i = 0; i < heights.Length; i++)
            {
                for (int j = i + 1; j < heights.Length; j++)
                {
                    res = Math.Max(res, Math.Min(heights[i], heights[j]) * (j - i));
                }
            }

            return res;
        }
    }
}
