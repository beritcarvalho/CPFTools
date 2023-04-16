namespace CpfTools.Domain
{
    public static class CpfTools
    {
        public static bool Validate(string cpfNumber)
        {
            Validator validator = new();
            return validator.Validate(cpfNumber);
        }
    }
}