using System;

namespace ContainerWithMostWater
{
    internal static class MaxAreaSolver_Complex
    {
        public static int Solve(int[] heights)
        {
            var links = Init(heights);

            var first = links[0];
            var last = links[^1];

            RadixSort(links);

            int max = 0;

            for (int i = 0; i < links.Length; i++)
            {
                var current = links[i];

                int heightOfCurrent = current.Height;
                int indexOfCurrent = current.Index;

                int maxDistance = Math.Max(
                    first == null ? 0 : Math.Abs(indexOfCurrent - first.Index),
                    last == null ? 0 : Math.Abs(indexOfCurrent - last.Index));

                int currentVolume = heightOfCurrent * maxDistance;

                max = Math.Max(currentVolume, max);

                if (current.Previous != null)
                    current.Previous.Next = current.Next;

                if (current.Next != null)
                    current.Next.Previous = current.Previous;

                if (first == current)
                    first = current.Next;

                if (last == current)
                    last = current.Previous;
            }

            return max;
        }

        private static Link[] Init(int[] heights)
        {
            var length = heights.Length;

            var links = new Link[length];

            Link previous = null;

            for (int i = 0; i < length; i++)
            {
                var current = new Link
                {
                    Height = heights[i],
                    Previous = previous,
                    Index = i
                };

                if (previous != null)
                    previous.Next = current;

                previous = links[i] = current;
            }

            return links;
        }

        private static void RadixSort(Link[] links)
        {
            Span<int> counter = stackalloc int[1 << 8];
            var target = new Link[links.Length];
            var mask = 0xFF;

            for (int i = 0; i < sizeof(int); i++)
            {
                var shift = 8 * i;

                for (int j = 0; j < links.Length; j++)
                {
                    counter[(links[j].Height >> shift) & mask]++;
                }

                var previousCount = 0;

                for (int j = 0; j < counter.Length; j++)
                {
                    previousCount = counter[j] += previousCount;
                }

                for (int j = target.Length - 1; j >= 0; j--)
                {
                    var counterIndex = (links[j].Height >> shift) & mask;
                    var targetIndex = counter[counterIndex]-- - 1;
                    target[targetIndex] = links[j];
                }

                counter.Clear();

                var temp = links;
                links = target;
                target = temp;
            }
        }

        private class Link
        {
            public int Height;
            public int Index;
            public Link Previous;
            public Link Next;
        }
    }
}
