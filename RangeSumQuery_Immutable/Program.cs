using System;
using System.Linq;

//LeetCode
namespace RangeSumQuery_Immutable
{
    class Program
    {
        static void Main(string[] args)
        {
            var r = new Random();
            var n = new NumArray(Enumerable.Range(0, 100).Select(_ => 1).ToArray());

            var a = new [] { -2, 0, 3, -5, 2, -1 };

            var na = new NumArray(a);

            var test1 = na.SumRange(0, 2);
            var test2 = na.SumRange(2, 5);
            var test3 = na.SumRange(0, 5);
        }
    }
}
