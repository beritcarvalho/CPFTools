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
            Assert.IsTrue(_validator.Validate("57658368873"));  
        }

        [TestMethod]
        public void ShoudReturnTrueWhenCPFIsValidWithReplace()
        {
            Assert.IsTrue(_validator.Validate("576.583.688-73", true));
        }

        [TestMethod]
        public void ShoudReturnFalseWhenCPFIsInvalidWithoutReplace()
        {
            Assert.IsFalse(_validator.Validate("576.583.688-73") || _validator.Validate("57658368874"));
        }
    }
}