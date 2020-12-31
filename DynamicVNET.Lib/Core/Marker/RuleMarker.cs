using DynamicVNET.Lib.Internal;
using System.Collections.Generic;

namespace DynamicVNET.Lib
{
    /// <summary>
    ///
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="DynamicVNET.Lib.BaseRuleMarker" />
    public class RuleMarker<T> : BaseRuleMarker
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RuleMarker{T}"/> class.
        /// </summary>
        public RuleMarker() : this(null) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="RuleMarker{T}"/> class.
        /// </summary>
        /// <param name="rules">The rules.</param>
        public RuleMarker(IEnumerable<IValidationRule> rules)
        {
            if (rules != null)
                this.Set(rules);
        }
    }
}
