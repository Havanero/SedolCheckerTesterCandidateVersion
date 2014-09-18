namespace SedolValidatorBusinessLogic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using SedolValidatorInterfaces;

    /// <summary>
    /// Implementation of <c>ISedolValidationResult</c>.
    /// </summary>
    public class SedolValidationResult : ISedolValidationResult
    {
        #region Constructor

        /// <summary>
        /// Initialises a new instance of the <see cref="SedolValidationResult"/> class.
        /// </summary>
        /// <param name="inputString">The input string.</param>
        /// <param name="isValidSedol">If set to <c>true</c> is valid SEDOL.</param>
        /// <param name="isUserDefined">If set to <c>true</c> is end user defined SEDOL.</param>
        /// <param name="validationDetails">The validation details.</param>
        public SedolValidationResult(string inputString, bool isValidSedol, bool isUserDefined, string validationDetails)
        {
            this.InputString = inputString;
            this.IsValidSedol = isValidSedol;
            this.IsUserDefined = isUserDefined;
            this.ValidationDetails = validationDetails;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the input string.
        /// </summary>
        /// <value>
        /// The input string.
        /// </value>
        public string InputString { get; private set; }

        /// <summary>
        /// Gets a value indicating whether this instance is valid SEDOL.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is valid SEDOL; otherwise, <c>false</c>.
        /// </value>
        public bool IsValidSedol { get; private set; }

        /// <summary>
        /// Gets a value indicating whether this instance is user defined.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is user defined; otherwise, <c>false</c>.
        /// </value>
        public bool IsUserDefined { get; private set; }

        /// <summary>
        /// Gets the validation details.
        /// </summary>
        /// <value>
        /// The validation details.
        /// </value>
        public string ValidationDetails { get; private set; }

        #endregion
    }
}
