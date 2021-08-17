using System;
using System.Collections.Generic;
using System.Linq;

namespace DirectionReduction
{
    public class DirReductionSolver
    {
        public static string[] Reduce(string[] arr) =>
            arr.Length < 2
            ? arr
            : Enumerable.Range(2, arr.Length-1)
                .Select(i => arr.Length - i)
                .Aggregate(
                    new Stack<string>(new[] { arr[arr.Length - 1] }),
                    (stack, i) =>
                    {
                        var dir = arr[i];
                        if (stack.Count > 0 && (Map(dir[0]) ^ Map(stack.Peek()[0])) == 1)
                            stack.Pop();
                        else
                            stack.Push(dir);

                        return stack;
                    })
                .ToArray();
            

        private static int Map(char c)
        {
            switch (char.ToUpper(c))
            {
                case 'N':
                    return 0;
                case 'S':
                    return 1;
                case 'W':
                    return 2;
                case 'E':
                    return 3;
                default:
                    throw new ArgumentOutOfRangeException(nameof(c));
            }
        }
    }
}
