using System;
using System.Text;

namespace SeparateDigits
{
    public class StringBuilderSolver : ISeparateDigitsSolver
    {
        public string SeparateDigits(int number, int digitStepLength = 3, string separator = ",")
        {
            if (separator == null)
                throw new ArgumentNullException(nameof(separator));

            if (digitStepLength < 1)
                throw new ArgumentException("Digit step length must be greater than 0", nameof(digitStepLength));

            var numberString = number.ToString();
            var isNegative = number < 0;
            var signOffset = (isNegative ? 1 : 0);
            var numberSegmentLength = numberString.Length - signOffset;

            if (digitStepLength >= numberSegmentLength)
                return numberString;

            var expectedStringLength = separator.Length * (numberSegmentLength / digitStepLength) + numberString.Length;

            var resultBuilder = new StringBuilder(expectedStringLength);
            var sourceIndex = 0;

            if (isNegative)
            {
                resultBuilder.Append('-');
                sourceIndex++;
            }

            resultBuilder.Append(numberString[sourceIndex]);
            sourceIndex++;

            var charsLeftUntilSeparator = (numberSegmentLength - 1) % digitStepLength;

            for (; sourceIndex < numberString.Length; sourceIndex++)
            {
                if (charsLeftUntilSeparator == 0)
                {
                    resultBuilder.Append(separator);
                    charsLeftUntilSeparator = digitStepLength - 1;
                }
                else
                {
                    charsLeftUntilSeparator--;
                }

                resultBuilder.Append(numberString[sourceIndex]);
            }

            return resultBuilder.ToString();
        }
    }
}
