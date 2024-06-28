using System;
using DynamicVNET.Lib.Exceptions;

namespace DynamicVNET.Lib.Internal
{
    /// <seealso cref="DynamicVNET.Lib.Internal.IValidationRule" />
    public class PredicateRule<T> : IValidationRule
    {
        /// <summary>
        /// The predicate
        /// </summary>
        private readonly Func<T, bool> _predicate;

        /// <summary>
        /// The error message
        /// </summary>
        protected string ErrorMessage;

        /// <summary>
        /// Gets the context.
        /// </summary>
        /// <value>
        /// The context.
        /// </value>
        public RuleContext Context { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PredicateRule{T}"/> class.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <param name="errorMessage">The error message.</param>
        /// <param name="context">The context.</param>
        /// <exception cref="ArgumentNullException">predicate</exception>
        public PredicateRule(Func<T, bool> predicate, string errorMessage, RuleContext context)
        {
            this._predicate = predicate ?? throw new ArgumentNullException(nameof(predicate));
            this.ErrorMessage = errorMessage;
            this.Context = context;
        }

        /// <inheritdoc/>
        public virtual ValidationRuleResult Validate(object instance)
        {
            try
            {
                if (!Invoke(instance))
                {
                    return ValidationRuleResult.Failure(this.Context.Member.Name,
                                                        this.Context.OperationName,
                                                        this.ErrorMessage);
                }

                return ValidationRuleResult.Success(this.Context.Member.Name,
                                                    this.Context.OperationName);
            }
            catch (Exception ex)
            {
                throw new ValidationMarkerException(nameof(PredicateRule<T>), $"Occurred exception in [{nameof(PredicateRule<T>)}]. Please check detail error information [InnerErorr]!", ex);
            }
        }

        /// <summary>
        /// Invoke predicate with specified instance.
        /// </summary>
        /// <param name="instance">The instance.</param>
        protected bool Invoke(object instance)
        {
            return _predicate((T)instance);
        }
    }
}
