using System;
using System.Collections.Generic;
using System.Linq;
using DynamicVNET.Lib.Exceptions;

namespace DynamicVNET.Lib.Internal
{
    /// <summary>
    /// Defines a validation result
    /// </summary>
    public class ValidationRuleResult
    {
        /// <summary>
        /// Gets the name of the member.
        /// </summary>
        /// <value>
        /// The name of the member.
        /// </value>
        public string MemberName { get; }

        /// <summary>
        /// Returns true if ... is valid.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is valid; otherwise, <c>false</c>.
        /// </value>
        public bool IsValid { get; }

        /// <summary>
        /// Gets the nested results.
        /// </summary>
        /// <value>
        /// The nested results.
        /// </value>
        public IEnumerable<ValidationRuleResult> NestedResults { get; internal set; }

        /// <summary>
        /// Gets the name of the validation.
        /// </summary>
        /// <value>
        /// The name of the validation.
        /// </value>
        public string ValidationName { get; }

        /// <summary>
        /// Gets the error message.
        /// </summary>
        /// <value>
        /// The error message.
        /// </value>
        public string ErrorMessage => this.ErrorInfo?.Message;

        /// <summary>
        /// Gets the error information.
        /// </summary>
        /// <value>
        /// The error information.
        /// </value>
        public ValidationException ErrorInfo { get; }

        /// <summary>
        /// Gets a value indicating whether [exists nested results].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [exists nested results]; otherwise, <c>false</c>.
        /// </value>
        public bool HasNestedResults => NestedResults != null && NestedResults.Any() ? true : false;

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidationRuleResult"/> class.
        /// </summary>
        /// <param name="validateState">if set to <c>true</c> [validate state].</param>
        /// <param name="memberName">Name of the member.</param>
        /// <param name="validationName">Name of the validation.</param>
        /// <param name="error">The error.</param>
        /// <param name="results">The results.</param>
        /// <exception cref="ArgumentNullException">validationName</exception>
        internal ValidationRuleResult(bool validateState, string memberName,string validationName, ValidationException error, IEnumerable<ValidationRuleResult> results)
        {
            this.IsValid = validateState;
            this.MemberName = memberName;
            this.ValidationName = validationName ?? throw new ArgumentNullException(nameof(validationName));
            this.ErrorInfo = error;
            this.NestedResults = results;
        }

        /// <summary>
        /// Successes the specified member name.
        /// </summary>
        /// <param name="memberName">Name of the member.</param>
        /// <param name="validationName">Name of the validation.</param>
        /// <returns></returns>
        public static ValidationRuleResult Success(string memberName,string validationName)
        {
            return new ValidationRuleResult(true, memberName, validationName, null, null);
        }

        /// <summary>
        /// Failures the specified member name.
        /// </summary>
        /// <param name="memberName">Name of the member.</param>
        /// <param name="validationName">Name of the validation.</param>
        /// <param name="errorMessage">The error message.</param>
        /// <returns></returns>
        public static ValidationRuleResult Failure(string memberName, string validationName, string errorMessage)
        {
            return new ValidationRuleResult(false, memberName, validationName, new ValidationException(validationName,errorMessage), null);
        }

        /// <summary>
        /// Failures the specified member name.
        /// </summary>
        /// <param name="memberName">Name of the member.</param>
        /// <param name="validationName">Name of the validation.</param>
        /// <param name="errorMessage">The error message.</param>
        /// <param name="results">The results.</param>
        /// <returns></returns>
        public static ValidationRuleResult Failure(string memberName, string validationName, string errorMessage, IEnumerable<ValidationRuleResult> results)
        {
            return new ValidationRuleResult(false, memberName, validationName, new ValidationException(validationName, errorMessage), results);
        }

        /// <summary>
        /// Failures the specified member name.
        /// </summary>
        /// <param name="memberName">Name of the member.</param>
        /// <param name="validationName">Name of the validation.</param>
        /// <param name="errorInfo">The error information.</param>
        /// <param name="results">The results.</param>
        /// <returns></returns>
        public static ValidationRuleResult Failure(string memberName, string validationName,ValidationException errorInfo, IEnumerable<ValidationRuleResult> results)
        {
            return new ValidationRuleResult(false, memberName, validationName, errorInfo, results);
        }
    }
}
