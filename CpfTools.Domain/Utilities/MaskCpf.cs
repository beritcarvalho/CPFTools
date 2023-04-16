using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CpfTools.Domain.Utilities
{
    public class MaskCpf
    {
        private readonly Regex _maskCpfExample = new Regex(@"^\d{3}\.\d{3}\.\d{3}\-\d{2}$");
        public string Mask(string cpf)
        {
            if (_maskCpfExample.IsMatch(cpf))
                return cpf;

            if (!Regex.Match(cpf, "^[0-9]+$").Success) return "";

            if (cpf.Length != 11)
                return "";

            string maskedCpf = Regex.Replace(cpf, @"(\d{3})(\d{3})(\d{3})(\d{2})", "$1.$2.$3-$4");
            return maskedCpf;
        }

        public string RemoveCPFMask(string cpf)
        {
            cpf = Regex.Replace(cpf, "[^0-9]", "");

            if (cpf.Length != 11) return "";

            return cpf;
        }

    }
}
