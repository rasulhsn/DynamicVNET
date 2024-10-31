using System;
using System.Collections.Generic;

namespace DynamicVNET.Lib
{
    /// <summary>
    /// 
    /// </summary>
    public interface IValidator
    {
        /// <summary>
        /// The type of the validated by Validator
        /// </summary>
        Type ValidateType { get; }

        /// <summary>
        /// Returns true if ... is valid.
        /// </summary>
        /// <param name="instance">The instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified instance is valid; otherwise, <c>false</c>.
        /// </returns>
        bool IsValid(object instance);

        /// <summary>
        /// Validate the specified instance.
        /// </summary>
        /// <param name="instance">The instance.</param>
        /// <returns></returns>
        IEnumerable<ValidationRuleResult> Validate(object instance);
    }

    /// <inheritdoc/>
    /// <typeparam name="T"></typeparam>
    public interface IValidator<T> : IValidator
    {
        /// <inheritdoc/>
        bool IsValid(T instance);

        /// <inheritdoc/>
        IEnumerable<ValidationRuleResult> Validate(T instance);
    }
}
