using System.Collections.Generic;
using DynamicVNET.Lib.Internal;

namespace DynamicVNET.Lib
{
    public interface IValidator
    {
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

    public interface IValidator<T> : IValidator
    {
        /// <summary>
        /// Returns true if ... is valid.
        /// </summary>
        /// <param name="instance">The instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified instance is valid; otherwise, <c>false</c>.
        /// </returns>
        bool IsValid(T instance);

        /// <summary>
        /// Validate the specified instance.
        /// </summary>
        /// <param name="instance">The instance.</param>
        /// <returns></returns>
        IEnumerable<ValidationRuleResult> Validate(T instance);
    }
}
