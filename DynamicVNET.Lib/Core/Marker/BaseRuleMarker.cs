using DynamicVNET.Lib.Internal;
using System.Collections.Generic;

namespace DynamicVNET.Lib
{
    /// <summary>
    ///
    /// </summary>
    public abstract class BaseRuleMarker
    {
        private ICollection<IValidationRule> _rules;

        /// <summary>
        /// Gets the rules.
        /// </summary>
        /// <value>
        /// The rules.
        /// </value>
        public IEnumerable<IValidationRule> Rules => this._rules;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseRuleMarker"/> class.
        /// </summary>
        protected BaseRuleMarker()
        {
            this._rules = new RuleCollection();
        }

        /// <summary>
        /// Adds the specified rule.
        /// </summary>
        /// <param name="rule">The rule.</param>
        public virtual void Add(IValidationRule rule)
        {
            this._rules.Add(rule);
        }

        /// <summary>
        /// Adds the specified rules.
        /// </summary>
        /// <param name="rules">The rules.</param>
        public virtual void Add(IEnumerable<IValidationRule> rules)
        {
            foreach (var item in rules)
                this.Add(item);
        }

        /// <summary>
        /// Sets the specified rules.
        /// </summary>
        /// <param name="rules">The rules.</param>
        protected void Set(IEnumerable<IValidationRule> rules)
        {
            _rules = new RuleCollection(rules);
        }

        /// <summary>
        /// Copies the specified marker.
        /// </summary>
        /// <param name="marker">The marker.</param>
        protected void Copy(BaseRuleMarker marker)
        {
            this._rules = marker._rules;
        }
    }
}
