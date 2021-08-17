using System.Collections.Generic;

namespace CountIslands
{
    public static class Solver
    {
        public static int CountIslands(int[,] source)
        {
            var res = 0;
            var marker = 1;
            var width = source.GetLength(1);
            var height = source.GetLength(0);
            var scanVector = new int[width];

            for (int i = 0; i < height; i++)
            {
                int? svPrevious = null;
                var mergeMap = new Dictionary<int, int>();

                for (int j = 0; j < width; j++)
                {
                    ref int svCurrent = ref scanVector[j];

                    if (mergeMap.TryGetValue(svCurrent, out var targetVal))
                    {
                        svCurrent = targetVal;
                    }

                    if (source[i, j] == 1)
                    {
                        if ((svPrevious == null || svPrevious == 0) && svCurrent == 0)
                        {
                            res++;
                            svCurrent = marker++;
                        }
                        else if (svPrevious == null || svPrevious == 0 || svCurrent == 0)
                        {
                            svCurrent = svCurrent == 0 ? svPrevious.Value : svCurrent;
                        }
                        else if (svPrevious.Value != svCurrent)
                        {
                            res--;

                            mergeMap.Add(svCurrent, svPrevious.Value);

                            svCurrent = svPrevious.Value;
                        }
                    }
                    else
                    {
                        svCurrent = 0;
                    }

                    svPrevious = svCurrent;
                }
            }

            return res;
        }
    }
}
