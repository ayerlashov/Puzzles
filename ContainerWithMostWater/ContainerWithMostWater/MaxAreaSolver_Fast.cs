namespace ContainerWithMostWater
{
    internal static class MaxAreaSolver_Fast
    {
        public static int Solve(int[] heights)
        {
            int res = 0;
            int left = 0;
            int right = heights.Length - 1;

            while (left < right)
            {
                var leftVal = heights[left];
                var rightVal = heights[right];
                int volume = (leftVal < rightVal ? leftVal : rightVal) * (right - left);

                res = res > volume ? res : volume;

                if (rightVal < leftVal)
                    right--;
                else
                    left++;
            }

            return res;
        }
    }
}
