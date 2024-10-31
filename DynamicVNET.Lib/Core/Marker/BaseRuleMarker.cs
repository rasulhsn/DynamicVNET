using DynamicVNET.Lib.Internal;
using System.Collections.Generic;

namespace DynamicVNET.Lib
{
    public abstract class BaseRuleMarker : IRuleMarker
    {
        private ICollection<IValidationRule> _rules;

        /// <inheritdoc/>
        public IEnumerable<IValidationRule> Rules => this._rules;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseRuleMarker"/> class.
        /// </summary>
        protected BaseRuleMarker()
        {
            this._rules = new RuleCollection();
        }

        /// <inheritdoc/>
        public void Add(IValidationRule rule)
        {
            if (rule == null)
            {
                throw new System.ArgumentNullException(nameof(rule));
            }

            this._rules.Add(rule);
        }

        /// <inheritdoc/>
        public void Add(IEnumerable<IValidationRule> rules)
        {
            if (rules == null)
            {
                throw new System.ArgumentNullException(nameof(rules));
            }

            foreach (var item in rules)
            {
                this.Add(item);
            }
        }

        /// <summary>
        /// Set the specified rules.
        /// </summary>
        /// <param name="rules">The rules.</param>
        protected void Set(IEnumerable<IValidationRule> rules)
        {
            _rules = new RuleCollection(rules);
        }
    }
}
