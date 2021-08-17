using static String_X_String.Helpers;

namespace String_X_String
{
    static class Solver
    {
        public static string StringFunc(string s, long x)
        {
            if (x == 0)
                return s;

            var source = s.ToCharArray();

            var res = Compute(source, x);

            return new string(res);
        }

        private static T[] Compute<T>(T[] source, long iterations)
        {
            iterations %= FindCycle(source.Length);

            return iterations < 8
                ? MultiPermute(source, iterations)
                : FastMultiPermute(source, iterations);
        }

        private static T[] MultiPermute<T>(T[] source, long n)
        {
            var res1 = source.Clone() as T[];
            var res2 = new T[res1.Length];

            for (int i = 0; i < n; i++)
            {
                Permute(res1, res2);
                Swap(ref res1, ref res2);
            }

            return res1;
        }

        private static T[] FastMultiPermute<T>(T[] source, long n)
        {
            var index_array1 = new int[source.Length];
            var index_array2 = GetIndexArray(source.Length);
            var result_array1 = source.Clone() as T[];
            var result_array2 = new T[source.Length];
            var exponents = GetExponents(n);

            Permute(index_array2, index_array1);

            var previousExponent = 0;

            foreach (var exponent in exponents)
            {
                for (int i = previousExponent; i < exponent; i++)
                {
                    PermuteByIndex(index_array1, index_array2, index_array1);
                    Swap(ref index_array1, ref index_array2);
                }

                PermuteByIndex(result_array1, result_array2, index_array1);
                Swap(ref result_array1, ref result_array2);

                previousExponent = exponent;
            }

            return result_array1;
        }

        private static void PermuteByIndex<T>(T[] source, T[] target, int[] indexes)
        {
            for (int i = 0; i < indexes.Length; i++)
            {
                target[i] = source[indexes[i]];
            }
        }

        private static int[] GetIndexArray(int n)
        {
            var res = new int[n];

            for (var i = 0; i < n; i++)
                res[i] = i;

            return res;
        }

        private static void Permute<T>(T[] source, T[] target)
        {
            var lim = source.Length / 2;

            for (int i = 0, j = 1; i < lim; i++, j += 2)
            {
                target[j] = source[i];
            }

            for (int i = source.Length - 1, j = 0; i >= lim; i--, j += 2)
            {
                target[j] = source[i];
            }
        }

        private static long FindCycle(long length)
        {
            if (length < 3)
                return length;

            var target = length * 2;
            var divisor = target + 1;
            var exp = 2;
            long val = 4;

            while (exp < int.MaxValue)
            {
                val %= divisor;

                if (val == 1 || val == target)
                    return exp;

                val *= 2;

                exp++;
            }

            return -1;
        }
    }
}
