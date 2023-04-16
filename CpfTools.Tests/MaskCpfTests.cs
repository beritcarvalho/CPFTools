using CpfTools.Domain.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CpfTools.Tests
{
    [TestClass]
    public class MaskCpfTests
    {
        private readonly Regex _maskCpfExample = new Regex(@"^\d{3}\.\d{3}\.\d{3}\-\d{2}$");
        private readonly MaskCpf _maskCpf = new();

        [TestMethod]
        public void ShouldReturnSuccessWhenMaskingTheCPF()
        {
            var maskedCpf = _maskCpf.Mask("57658368873");

            Assert.IsTrue(_maskCpfExample.IsMatch(maskedCpf), "O retorno não é um CPF Mascarado");
        }

        [TestMethod]
        public void ShouldReturnErrorWhenArgumentIsInvalid()
        {
            string[] inputs = { "576.583.688.73", "576583688733333333", "aaaa" };

            foreach (string input in inputs)
            {
                string maskedCpf =_maskCpf.Mask(input);

                if (string.IsNullOrEmpty(maskedCpf))
                {
                    continue;
                }                
                
                Assert.Fail($"O argumento {input} é um argumento válido");
            }
        }

        [TestMethod]
        public void ShouldReturnSuccessIfCPFIs11CharactersLong()
        {
            var cpf = _maskCpf.RemoveCPFMask("576.583.688-73");

            Assert.IsTrue(cpf.Length == 11);
        }

        [TestMethod]
        public void ShouldReturnErrorIfCPFNotIs11CharactersLong()
        {
            string[] inputs = { "576583688733333333", "aaaa" };

            foreach (string input in inputs)
            {
                string cpf = _maskCpf.RemoveCPFMask(input);

                if (string.IsNullOrEmpty(cpf))
                {
                    continue;
                }

                Assert.Fail($"O argumento {input} é um argumento válido");
            }
        }
    }
}
