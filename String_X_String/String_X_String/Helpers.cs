using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace String_X_String
{
    public static class Helpers
    {
        public static long PerfTest(int count, Action act)
        {
            var sw = new Stopwatch();

            sw.Start();

            for (int i = 0; i < count; i++)
            {
                act();
            }

            sw.Stop();

            return sw.ElapsedMilliseconds;
        }

        public static List<byte> GetExponents(long value)
        {
            var result = new List<byte>();

            for (byte i = 0; i < 64; i++, value >>= 1)
            {
                if ((value & 1) == 1)
                    result.Add(i);
            }

            return result;
        }

        public static void Swap<T>(ref T o1, ref T o2)
          where T : class
        {
            var temp = o1;
            o1 = o2;
            o2 = temp;
        }
    }
}
