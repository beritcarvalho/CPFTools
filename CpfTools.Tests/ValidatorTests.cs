using CpfTools.Domain.Utilities;
using static System.Net.Mime.MediaTypeNames;

namespace CpfTools.Tests
{
    [TestClass]
    public class _validatorTests
    {
        private readonly Validator _validator = new();
        [TestMethod]
        public void ShoudReturnTrueWhenCPFIsValidWithoutReplace()
        {
            Assert.IsTrue(_validator.Validate("39339959817"));  
        }

        [TestMethod]
        public void ShoudReturnTrueWhenCPFIsValidWithReplace()
        {
            Assert.IsTrue(_validator.Validate("393.399.598-17", true));
        }

        [TestMethod]
        public void ShoudReturnFalseWhenCPFIsInvalidWithoutReplace()
        {
            Assert.IsFalse(_validator.Validate("393.399.598-17") || _validator.Validate("39339959818"));
        }
    }
}