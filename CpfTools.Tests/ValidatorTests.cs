using CpfTools.Domain;
using static System.Net.Mime.MediaTypeNames;

namespace CpfTools.Tests
{
    [TestClass]
    public class ValidatorTests
    {
        [TestMethod]
        public void ShoudReturnTrueWhenCPFIsValidWithoutReplace()
        {
            Validator validator = new();

            Assert.IsTrue(validator.Validate("39339959817"));  
        }

        [TestMethod]
        public void ShoudReturnTrueWhenCPFIsValidWithReplace()
        {
            Validator validator = new();

            Assert.IsTrue(validator.Validate("393.399.598-17", true));
        }

        [TestMethod]
        public void ShoudReturnFalseWhenCPFIsInvalidWithoutReplace()
        {
            Validator validator = new();

            Assert.IsFalse(validator.Validate("393.399.598-17") || validator.Validate("39339959818"));
        }
    }
}