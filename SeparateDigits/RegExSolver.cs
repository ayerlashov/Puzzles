using System.Text.RegularExpressions;

namespace SeparateDigits
{
    public class RegExSolver : ISeparateDigitsSolver
    {
        public string SeparateDigits(int number, int digitStepLength = 3, string separator = ",")
            => Regex.Replace(
                number.ToString(),
                @$"(?<!^-?)(\d{{{digitStepLength}}})",
                $"{separator}$&",
                RegexOptions.RightToLeft);
    }
}
