
namespace DynamicVNET.Lib.Internal
{
    /// <seealso cref="DynamicVNET.Lib.Internal.BaseRule" />
    public class UniquePredicateRule<T> : BaseRule
    {
        private readonly PredicateRule<T> _predicate;

        /// <summary>
        /// Initializes a new instance of the <see cref="UniquePredicateRule{T}"/> class.
        /// </summary>
        /// <param name="predicateRule">The predicate rule.</param>
        /// <param name="context">The context.</param>
        public UniquePredicateRule(PredicateRule<T> predicateRule, RuleContext context) : base(context)
        {
            _predicate = predicateRule;
        }

        /// <inheritdoc/>
        public override ValidationRuleResult Validate(object instance)
        {
            return this._predicate.Validate(instance);
        }
    }
}
