namespace SedolValidatorTests
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using SedolValidatorBusinessLogic;

    [TestClass]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Test methods are documented via Description attribute. Adding extra comments results in unnecessary duplication of text which increases maintenance cost.")] 
    public class SedolValidationResultTests : TestBase
    {
        [TestMethod]
        [Description("Constructor.")]
        public void Constructor_GivenValidParamenters_ConstructsValidInstance()
        {
            // Arrange
            var testInput = "testInput";
            var isValid = true;
            var isUserDefined = false;
            var testValidationDetails = "testDetails";

            // Act
            var actual = new SedolValidationResult(testInput, isValid, isUserDefined, testValidationDetails);

            // Assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(testInput, actual.InputString);
            Assert.AreEqual(isValid, actual.IsValidSedol);
            Assert.AreEqual(isUserDefined, actual.IsUserDefined);
            Assert.AreEqual(testValidationDetails, actual.ValidationDetails);
        }
    }
}
