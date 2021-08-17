namespace SeparateDigits
{
    public interface ISeparateDigitsSolver
    {
        string SeparateDigits(int number, int digitStepLength = 3, string separator = ",");
    }
}