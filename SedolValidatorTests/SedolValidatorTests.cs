namespace SedolValidatorTests
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using SedolValidatorBusinessLogic;

    [TestClass]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Test methods are documented via Description attribute. Adding extra comments results in unnecessary duplication of text which increases maintenance cost.")] 
    public class SedolValidatorTests : TestBase
    {
        [TestMethod]
        [Description("CalculateChecksumDigit should call CheckCharacterWeights method.")]
        public void ConstructorShouldCallCheckCharacterWeightsMethod()
        {
            // Arrange
            var sut = new Mock<SedolValidator>() { CallBase = true };
            sut.Setup(x => x.CheckCharacterWeights(It.IsAny<int[]>())).Verifiable();

            // Act
            var constructorInvoke = sut.Object;

            // Assert
            sut.Verify(x => x.CheckCharacterWeights(It.IsAny<int[]>()), Times.Once);
        }

        [TestMethod]
        [Description("HasRightLength should return TRUE if input string has exactly 7 alpha-numeric characters.")]
        public void HasRightLengthReturnsTrueIfSedolExactlySevenCharactersLong()
        {
            // Arrange
            var sut = new SedolValidator();

            // Act
            var actual = sut.HasRightLength("1234567");

            // Assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        [Description("HasRightLength should return FALSE if input is null.")]
        public void HasRightLengthReturnsFalseIfInputIsNull()
        {
            // Arrange
            var sut = new SedolValidator();

            // Act
            var actual = sut.HasRightLength(null);

            // Assert
            Assert.IsFalse(actual);
        }

        [TestMethod]
        [Description("HasRightLength should return FALSE if input is an empty string.")]
        public void HasRightLengthReturnsFalseIfInputIsEmptyString()
        {
            // Arrange
            var sut = new SedolValidator();

            // Act
            var actual = sut.HasRightLength(string.Empty);

            // Assert
            Assert.IsFalse(actual);
        }

        [TestMethod]
        [Description("HasRightLength should return FALSE if input length is less than 7 characters.")]
        public void HasRightLengthReturnsFalseIfInputLengthIsLessThanSevenCharacters()
        {
            // Arrange
            var sut = new SedolValidator();

            // Act
            var actual = sut.HasRightLength("123456");

            // Assert
            Assert.IsFalse(actual);
        }

        [TestMethod]
        [Description("HasRightLength should return FALSE if input length is greater than 7 characters.")]
        public void HasRightLengthReturnsFalseIfInputLengthIsGreaterThanSevenCharacters()
        {
            // Arrange
            var sut = new SedolValidator();

            // Act
            var actual = sut.HasRightLength("12345678");

            // Assert
            Assert.IsFalse(actual);
        }

        [TestMethod]
        [Description("CalculateChecksumDigit should return 4 when input is 070995.")]
        public void CalculateChecksumDigitShouldReturn4WhenInputIs070995()
        {
            // Arrange
            var sut = new SedolValidator();

            // Act
            var actual = sut.CalculateChecksumDigit("070995");

            // Assert
            Assert.AreEqual('4', actual);
        }

        [TestMethod]
        [Description("CalculateChecksumDigit should throw an exception if input is null.")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CalculateChecksumDigitShouldThrowExceptionIfInputIsNull()
        {
            // Arrange
            var sut = new SedolValidator();

            // Act
            sut.CalculateChecksumDigit(null);

            // Assert - exception expected.
        }

        [TestMethod]
        [Description("CheckCharacterWeights should not throw any exception if provided with valid character weight array with size equal to expected Sedol length.")]
        public void CheckCharacterWeightsShouldNotThrowAnyExceptionIfCharacterWeightSizeEqualToExpectedSedolLength()
        {
            // Arrange
            var sut = new SedolValidator();
            var characterWeightsWithExpectedSedolLength = new int[SedolValidator.ExpectedSedolLength];

            // Act
            sut.CheckCharacterWeights(characterWeightsWithExpectedSedolLength);

            // Assert
            Assert.IsTrue(true);
        }

        [TestMethod]
        [Description("CheckCharacterWeights should throw an exception if CharacterWeights array is null.")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CheckCharacterWeightsShouldThrowExceptionIfCharacterWeightIsNull()
        {
            // Arrange
            var sut = new SedolValidator();

            // Act
            sut.CheckCharacterWeights(null);

            // Assert - exception expected.
        }

        [TestMethod]
        [Description("CheckCharacterWeights should throw an exception if CharacterWeights array size differs from expected Sedol length (as we should have weight for each input).")]
        [ExpectedException(typeof(ArgumentException))]
        public void CheckCharacterWeightsShouldThrowExceptionIfCharacterWeightSizeDiffersFromExpectedSedolLength()
        {
            // Arrange
            var sut = new SedolValidator();
            var characterWeightsBiggerThanExpectedSedol = new int[SedolValidator.ExpectedSedolLength + 1];

            // Act
            sut.CheckCharacterWeights(characterWeightsBiggerThanExpectedSedol);

            // Assert - exception expected.
        }

        [TestMethod]
        [Description("IsEndUserDefinedSedol should throw an exception if input is null.")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void IsEndUserDefinedSedolShouldThrowExceptionIfInputIsNull()
        {
            // Arrange
            var sut = new SedolValidator();

            // Act
            sut.HasEndUserDefinedSedolPrefix(null);

            // Assert - exception expected.
        }

        [TestMethod]
        [Description("IsEndUserDefinedSedol should return TRUE if input string starts with end user prefix character.")]
        public void HasEndUserDefinedSedolPrefixShouldReturnTrueIfInputStartsWithEndUserPrefixCharacter()
        {
            // Arrange
            var sut = new SedolValidator();

            // Act
            var actual = sut.HasEndUserDefinedSedolPrefix(SedolValidator.EndUserDefinedSedolRangePrefix.ToString());

            // Assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        [Description("IsEndUserDefinedSedol should return FALSE if input string does not start with end user prefix character.")]
        public void HasEndUserDefinedSedolPrefixShouldReturnFalseIfInputDoesNotStartWithEndUserPrefixCharacter()
        {
            // Arrange
            var sut = new SedolValidator();
            char shiftedEndUserDefinedSedolPrefix = (char)(SedolValidator.EndUserDefinedSedolRangePrefix + 1);

            // Act
            var actual = sut.HasEndUserDefinedSedolPrefix(shiftedEndUserDefinedSedolPrefix.ToString());

            // Assert
            Assert.IsFalse(actual);
        }

        [TestMethod]
        [Description("RemoveChecksumDigit should remove the last character from multicharacter string.")]
        public void RemoveChecksumDigitShouldRemoveLastCharacterFromMulticharacterString()
        {
            // Arrange
            var sut = new SedolValidator();

            // Act
            var actual = sut.RemoveChecksumDigit("123");

            // Assert
            Assert.AreEqual("12", actual);
        }

        [TestMethod]
        [Description("RemoveChecksumDigit should return empty string if provided input is a single character.")]
        public void RemoveChecksumDigitShouldReturnEmptyStringIfSingleCharacterProvidedAsInput()
        {
            // Arrange
            var sut = new SedolValidator();

            // Act
            var actual = sut.RemoveChecksumDigit("1");

            // Assert
            Assert.AreEqual(string.Empty, actual);
        }

        [TestMethod]
        [Description("RemoveChecksumDigit should throw an exception if null string provided.")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RemoveChecksumDigitShouldThrowExceptionIfNullInputProvided()
        {
            // Arrange
            var sut = new SedolValidator();

            // Act
            var actual = sut.RemoveChecksumDigit(null);

            // Assert - exception expected
        }

        [TestMethod]
        [Description("RemoveChecksumDigit should throw an exception if empty string provided.")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RemoveChecksumDigitShouldThrowExceptionIfEmptyStringProvided()
        {
            // Arrange
            var sut = new SedolValidator();

            // Act
            var actual = sut.RemoveChecksumDigit(string.Empty);

            // Assert - exception expected
        }
    }
}
