using CpfTools.Domain.Utilities;

namespace CpfTools.Domain
{
    public static class CPFToolkit
    {
        public static bool Validate(string cpfNumber)
        {
            Validator validator = new();
            return validator.Validate(cpfNumber);
        }
    }
}