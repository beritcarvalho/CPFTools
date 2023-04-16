using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CpfTools.Domain
{
    public class Validator
    {
        public bool Validate(string cpf, bool replace = false)
        {
            if(replace) cpf = Regex.Replace(cpf, "[^0-9]", "");

            var isNumber = Regex.Match(cpf, "^[0-9]+$").Success;
            if(!isNumber) return false;
            

            if (cpf.Length != 11)
                return false;

            var firstValidator = GetFirstStepValidador(cpf);

            var secondValidator = GetSecondStepValidador(cpf);

            var twoLastNumbersCpf = int.Parse(cpf.Substring(9, 2));

            var validator = int.Parse(string.Concat(firstValidator + secondValidator));

            if (twoLastNumbersCpf == validator)
                return true;

            return false;
        }

        private string GetSecondStepValidador(string cpf)
        {
            int sum = 0;
            for (int i = 0; i < 10; i++)
            {
                sum += i * int.Parse(cpf.Substring(i, 1));
            }
            int restDivision = sum % 11;

            if (restDivision == 10)
                restDivision = 0;

            var secondDigitValidator = restDivision.ToString().Substring(0, 1);
            return secondDigitValidator;
        }

        private string GetFirstStepValidador(string cpf)
        {
            int sum = 0;
            for (int i = 1; i < 10; i++)
            {
                sum += i * int.Parse(cpf.Substring(i - 1, 1));
            }

            int restDivision = sum % 11;
            if (restDivision == 10)
                restDivision = 0;

            var firstDigitValidator = restDivision.ToString().Substring(0, 1);

            return firstDigitValidator;
        }
    }
}
