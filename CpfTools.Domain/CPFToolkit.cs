using CpfTools.Domain.Utilities;

namespace CpfTools.Domain
{
    public static class CPFToolkit
    {
        private static readonly Validator _validator = new Validator();
        private static readonly MaskCpf _maskUtis = new MaskCpf();

        /// <summary>
        /// Checks if the entered value is a valid CPFRemove CPF mask.
        /// </summary>
        /// <param name="cpf">Value to be validated</param>
        /// <param name="replace">Optional parameter, which activates the removal of any non-numeric character.To activate, parameterize the value true.</param>
        /// <returns>Returns true if it is a valid cpf and false if it is invalid.</returns>
        public static bool Validate(string cpfNumber)
        {
            return _validator.Validate(cpfNumber);
        }

        /// <summary>
        /// Convert the CPF number into a CPF with a default mask.
        /// </summary>
        /// <param name="cpf">The CPF to be validated must contain only numbers and have 11 digits.</param>
        /// <returns>If the conversion is successful, returns a string with a CPF mask (XXX.XXX.XXX-XX). If unsuccessful, returns an empty string.</returns>
        public static string Mask(string cpfNumber)
        {          
            return _maskUtis.Mask(cpfNumber);
        }

        /// <summary>
        /// Remove CPF mask.
        /// </summary>
        /// <param name="cpf">The parameter entered has no restriction on quantity or values, but must contain 11 numeric digits</param>
        /// <returns>Return an 11-digit numeric string. If after removing non-numeric characters, the string length is less than 11, returns an empty string</returns>
        public static string RemoveMask(string cpfNumber)
        {
            return _maskUtis.RemoveCPFMask(cpfNumber);
        }
    }
}