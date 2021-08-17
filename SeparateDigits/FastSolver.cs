using System;

namespace SeparateDigits
{
    public class FastSolver : ISeparateDigitsSolver
    {
        public string SeparateDigits(int number, int digitStepLength = 3, string separator = ",")
        {
            if (separator == null)
                throw new ArgumentNullException(nameof(separator));

            if (digitStepLength < 1)
                throw new ArgumentException("Digit step length must be greater than 0", nameof(digitStepLength));

            var isNegative = number < 0;
            var signOffset = isNegative ? 1 : 0;
            var numberSegmentLength = GetNumberLength();
            var numberLength = numberSegmentLength + signOffset;

            if (digitStepLength >= numberSegmentLength)
                return number.ToString();

            var separatorCount = Math.DivRem(numberSegmentLength, digitStepLength, out var rem) - (rem == 0 ? 1 : 0);
            var expectedStringLength = separator.Length * separatorCount + numberLength;

            return string.Create(expectedStringLength, (object)null, SpanWriter);

            void SpanWriter(Span<char> span, object state)
            {
                if (isNegative)
                    span[0] = '-';

                var sourceIndex = numberLength - 1;
                var charsUntilSeparator = digitStepLength;
                int separatorIndex = separator.Length - 1;
                int dividend = number;

                for (var targetIndex = expectedStringLength - 1; targetIndex >= signOffset; targetIndex--)
                {
                    if (charsUntilSeparator == 0)
                    {
                        span[targetIndex] = separator[separatorIndex];
                        separatorIndex--;
                        if (separatorIndex < 0)
                        {
                            separatorIndex = separator.Length - 1;
                            charsUntilSeparator = digitStepLength;
                        }
                    }
                    else
                    {
                        dividend = Math.DivRem(dividend, 10, out var current);
                        if (current < 0)
                            current = -current;
                        span[targetIndex] = (char)(current + '0');
                        sourceIndex--;
                        charsUntilSeparator--;
                    }
                }
            }

            int GetNumberLength()
            {
                if (number == int.MinValue)
                    return 10;

                var absNumber = isNegative ? -number : number;

                if (absNumber < 1_00000)
                {
                    if (absNumber < 100)
                        return absNumber < 10 ? 1 : 2;
                    else if (absNumber < 10000)
                        return absNumber < 1000 ? 3 : 4;
                    else
                        return 5;
                }
                else if (absNumber < 100_00000)
                {
                    return absNumber < 10_00000 ? 6 : 7;
                }
                else if (absNumber < 10000_00000)
                {
                    return absNumber < 1000_00000 ? 8 : 9;
                }
                else
                {
                    return 10;
                }
            }
        }
    }
}