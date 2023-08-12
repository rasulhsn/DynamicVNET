using System;

namespace DynamicVNET.Lib.Internal
{
    /// <seealso cref="DynamicVNET.Lib.Internal.IValidationRule" />
    public abstract class BaseRule : IValidationRule
    {
        /// <inheritdoc/>
        public RuleContext Context { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseRule"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <exception cref="ArgumentNullException">RuleContext</exception>
        protected BaseRule(RuleContext context)
        {
            this.Context = context ?? throw new ArgumentNullException(nameof(RuleContext));
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            BaseRule rule = obj as BaseRule;

            if (rule == null)
            {
                return false;
            }
            else if (rule.GetHashCode() == this.GetHashCode())
            {
                return true;
            }

            return false;
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return Context.GetHashCode();
        }

        /// <inheritdoc/>
        public abstract ValidationRuleResult Validate(object instance);
    }
}
