namespace SedolValidatorBusinessLogic
{
    using System;
    using System.Linq;
    using SedolValidatorInterfaces;

    /// <summary>
    /// SEDOL validator.
    /// </summary>
    public class SedolValidator : ISedolValidator
    {
        #region Constants

        /// <summary>
        /// The expected SEDOL length.
        /// </summary>
        public const int ExpectedSedolLength = 7;

        /// <summary>
        /// The end user defined SEDOL range prefix.
        /// </summary>
        public const char EndUserDefinedSedolRangePrefix = '9';

        /// <summary>
        /// The zero character ASCII value.
        /// </summary>
        public const int ZeroDigitAsciiValue = 48;

        /// <summary>
        /// The letter ASCII offset (for instance, B = 11).
        /// </summary>
        public const int LetterAsciiOffset = 55;

        #endregion

        #region Constructor

        /// <summary>
        /// Initialises a new instance of the <see cref="SedolValidator"/> class with default character weights.
        /// </summary>
        public SedolValidator()
            : this(new int[] { 1, 3, 1, 7, 3, 9, 1 }) 
        { 
        }

        /// <summary>
        /// Initialises a new instance of the <see cref="SedolValidator"/> class.
        /// </summary>
        /// <param name="characterWeights">The character weights.</param>
        public SedolValidator(int[] characterWeights)
        {
            this.CheckCharacterWeights(characterWeights);
            this.CharacterWeights = characterWeights;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the character weights.
        /// </summary>
        /// <value>
        /// The character weights used for checksum digit calculation.
        /// </value>
        public virtual int[] CharacterWeights { get; private set; }

        #endregion

        #region Methods

        /// <summary>
        /// Validates the SEDOL.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>
        /// Instance of validation result.
        /// </returns>
        public ISedolValidationResult ValidateSedol(string input)
        {
            bool isValid = false;
            bool isUserDefined = false;
            string validationDetails = string.Empty;

            if (this.HasRightLength(input))
            {
                var checksumDigit = this.CalculateChecksumDigit(RemoveChecksumDigit(input));

                if (input.Last() == checksumDigit)
                {
                    isValid = true;
                }
                else
                {
                    validationDetails = "Checksum digit does not agree with the first 6 characters.";
                }
            }
            else
            {
                validationDetails = string.Format("Input string was not {0}-characters long.", ExpectedSedolLength);
            }

            return new SedolValidationResult(input, isValid, isUserDefined, validationDetails);
        }

        public string RemoveChecksumDigit(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentNullException("Provided input string is null or empty.");
            }

            return input.Substring(0, input.Length - 1);
        }

        /// <summary>
        /// Determines whether the specified input has the right length.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>
        ///   <c>true</c> if the specified input has the right length; otherwise, <c>false</c>.
        /// </returns>
        public virtual bool HasRightLength(string input)
        {
            return !string.IsNullOrWhiteSpace(input) && input.Length == ExpectedSedolLength;
        }

        /// <summary>
        /// Calculates the checksum digit.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>Checksum digit.</returns>
        public virtual char CalculateChecksumDigit(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentNullException("Input not specified.");
            }

            var sum = 0;
            for (int i = 0; i < Math.Min(input.Length, this.CharacterWeights.Length); i++)
            {
                if (char.IsDigit(input[i]))            
                {
                    sum += ((int)input[i] - ZeroDigitAsciiValue) * this.CharacterWeights[i];
                }
                else if (char.IsLetter(input[i]))
                {
                    sum += ((int)char.ToUpper(input[i]) - LetterAsciiOffset) * this.CharacterWeights[i];
                }
            }

            var checkDigit = (10 - (sum % 10)) % 10;

            return checkDigit.ToString().Last();
        }

        /// <summary>
        /// Checks the character weights.
        /// </summary>
        /// <param name="characterWeights">The character weights.</param>
        /// <exception cref="System.ArgumentNullException">Character weight array is not initialised.</exception>
        /// <exception cref="System.ArgumentException">Character weight array is expected to have the same number of elements as the expected SEDOL length.</exception>
        public virtual void CheckCharacterWeights(int[] characterWeights)
        {
            if (characterWeights == null)
            {
                throw new ArgumentNullException("Character weight array is not initialised.");
            }

            if (characterWeights.Length != ExpectedSedolLength)
            {
                throw new ArgumentException("Character weight array is expected to have the same number of elements as the expected SEDOL length.");
            }
        }

        /// <summary>
        /// Determines whether the specified input has End User Defined SEDOL prefix.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>
        ///   <c>true</c> if the specified input has End User Defined SEDOL prefix; otherwise, <c>false</c>.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">Input not specified.</exception>
        public virtual bool HasEndUserDefinedSedolPrefix(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentNullException("Input not specified.");
            }

            return input[0] == EndUserDefinedSedolRangePrefix;
        }

        #endregion
    }
}
