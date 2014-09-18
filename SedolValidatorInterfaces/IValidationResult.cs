namespace SedolValidatorInterfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// SEDOL Validation Result interface.
    /// </summary>
    public interface ISedolValidationResult
    {
        /// <summary>
        /// Gets the input string.
        /// </summary>
        /// <value>
        /// The input string.
        /// </value>
        string InputString { get; }

        /// <summary>
        /// Gets a value indicating whether this instance is valid SEDOL.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is valid SEDOL; otherwise, <c>false</c>.
        /// </value>
        bool IsValidSedol { get; }

        /// <summary>
        /// Gets a value indicating whether this instance is user defined.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is user defined; otherwise, <c>false</c>.
        /// </value>
        bool IsUserDefined { get; }

        /// <summary>
        /// Gets the validation details.
        /// </summary>
        /// <value>
        /// The validation details.
        /// </value>
        string ValidationDetails { get; }
    }
}
