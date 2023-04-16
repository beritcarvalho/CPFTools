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
        public string Mask(string cpf)
        {
            if (cpf.Length != 11)
                throw new ArgumentException("CPF deve ter exatamente 11 caracteres.", nameof(cpf)); ;            
            
            if (!Regex.Match(cpf, "^[0-9]+$").Success) throw new ArgumentException("O parâmetro deve ter apenas números.", nameof(cpf));

            string maskedCpf = Regex.Replace(cpf, @"(\d{3})(\d{3})(\d{3})(\d{2})", "$1.$2.$3-$4");
            return maskedCpf; 

        }
        
        public string RemoveCPFMask(string cpf)
        {
            cpf = Regex.Replace(cpf, "[^0-9]", "");

            if(cpf.Length != 11) throw new ArgumentException("O valor informado para o CPF é inválido. Certifique-se de que foram informados 11 caracteres numéricos.");

            return cpf;
        }

    }
}
