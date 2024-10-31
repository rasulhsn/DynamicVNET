using System.Collections.Generic;
using DynamicVNET.Lib.Internal;

namespace DynamicVNET.Lib
{
    public interface IRuleMarker
    {
        /// <summary>
        /// Get the rules.
        /// </summary>
        /// <value>
        /// The rules.
        /// </value>
        IEnumerable<IValidationRule> Rules { get; }

        /// <summary>
        /// Add the specified rule.
        /// </summary>
        /// <param name="rule">The rule.</param>
        void Add(IValidationRule rule);

        /// <summary>
        /// Add the specified rules.
        /// </summary>
        /// <param name="rules">The rules.</param>
        void Add(IEnumerable<IValidationRule> rules);
    }
}
