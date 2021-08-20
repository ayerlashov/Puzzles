using System.Collections.Generic;

namespace MinimumWindowSubstring
{
    public class Solver
    {
        public static string MinWindow(string s, string t)
        {
            var histogram = new Dictionary<char, int>();

            for (int i = 0; i < t.Length; i++)
            {
                var currentChar = t[i];

                histogram.TryGetValue(currentChar, out var count);
                histogram[currentChar] = count + 1;
            }

            var totalCharsLeft = t.Length;
            var queue = new Queue<(char value, int index)>();
            var resStartIndex = 0;
            int? resLength = null;

            for (int i = 0; i < s.Length; i++)
            {
                var currentChar = s[i];

                if (histogram.TryGetValue(currentChar, out var neededCount))
                {
                    if (neededCount > 0)
                    {
                        totalCharsLeft--;
                    }

                    histogram[currentChar] = neededCount - 1;
                    queue.Enqueue((currentChar, i));

                    while (histogram[queue.Peek().value] < 0)
                    {
                        histogram[queue.Dequeue().value]++;
                    }

                    var currentStartIndex = queue.Peek().index;
                    var currentLength = i - currentStartIndex + 1;

                    if (totalCharsLeft == 0 && (currentLength < resLength || !resLength.HasValue))
                    {
                        resStartIndex = currentStartIndex;
                        resLength = currentLength;
                    }
                }
            }

            return s.Substring(resStartIndex, resLength ?? 0);
        }
    }
}
