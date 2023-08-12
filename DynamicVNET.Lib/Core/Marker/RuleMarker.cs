using DynamicVNET.Lib.Internal;
using System;
using System.Collections.Generic;

namespace DynamicVNET.Lib
{
    /// <seealso cref="DynamicVNET.Lib.BaseRuleMarker" />
    public class RuleMarker<T> : BaseRuleMarker, ITypeRuleMarker<T>, IMemberRuleMarker
    {
        private IMember _selected;

        /// <summary>
        /// Initializes a new instance of the <see cref="RuleMarker{T}"/> class.
        /// </summary>
        public RuleMarker() : base() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="RuleMarker{T}"/> class.
        /// </summary>
        /// <param name="rules">The rules.</param>
        public RuleMarker(IEnumerable<IValidationRule> rules)
        {
            if (rules != null)
            {
                Set(rules);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RuleMarker{T}"/> class.
        /// </summary>
        /// <param name="member">The member.</param>
        /// <exception cref="ArgumentNullException">IMember</exception>
        internal RuleMarker(IMember member)
        {
            Selected = member ?? throw new ArgumentNullException(nameof(member));
        }

        /// <inheritdoc/>
        public IMember Selected
        {
            get
            {
                return _selected == null ?
                  throw new NullReferenceException(nameof(IMember)) : _selected;
            }
            set
            {
                _selected = value;
            }
        }

        /// <inheritdoc/>
        public IMemberRuleMarker Copy()
        {
            return new RuleMarker<T>(this.Selected);
        }
    }
}
