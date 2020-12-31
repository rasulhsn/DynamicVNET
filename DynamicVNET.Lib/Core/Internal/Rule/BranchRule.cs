using System;
using System.Linq;
using DynamicVNET.Lib.Exceptions;

namespace DynamicVNET.Lib.Internal
{
    /// <seealso cref="DynamicVNET.Lib.Internal.PredicateRule{T}" />
    public class BranchRule<T> : PredicateRule<T>
    {
        private readonly IBuilderStrategy _strategy;

        /// <summary>
        /// Initializes a new instance of the <see cref="BranchRule{T}"/> class.
        /// </summary>
        /// <param name="strategy">The strategy.</param>
        /// <param name="predicate">The predicate.</param>
        /// <param name="context">The context.</param>
        /// <param name="errorMessage">The error message.</param>
        /// <exception cref="ArgumentNullException">IBuildStrategy</exception>
        public BranchRule(IBuilderStrategy strategy, Func<T, bool> predicate, RuleContext context, string errorMessage = null) : base(predicate, errorMessage, context)
        {
            _strategy = strategy ?? throw new ArgumentNullException(nameof(IBuilderStrategy));
        }

        /// <summary>
        /// </summary>
        /// <param name="instance"></param>
        /// <exception cref="ValidationMarkerException">T - Occurred exception in BranchRule<T>. Please check detail error information [InnerErorr]!</exception>
        public override void Apply(object instance)
        {
            try
            {
                if (base.Invoke(instance))
                {
                    var childResult = _strategy.Build(instance);
                    if (childResult == null || !childResult.Any())
                        Context.SetResult();
                    else
                        Context.SetResult(this.ErrorMessage, childResult);
                }
            }
            catch (Exception ex)
            {
                throw new ValidationMarkerException(nameof(BranchRule<T>), $"Occurred exception in [{nameof(BranchRule<T>)}]. Please check detail error information [InnerErorr]!", ex);
            }
        }
    }
}
