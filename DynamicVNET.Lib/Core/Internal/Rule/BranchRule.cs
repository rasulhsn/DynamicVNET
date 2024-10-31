using System;
using System.Collections.Generic;
using System.Linq;
using DynamicVNET.Lib.Exceptions;

namespace DynamicVNET.Lib.Internal
{
    /// <seealso cref="DynamicVNET.Lib.Internal.PredicateRule{T}" />
    public class BranchRule<T> : PredicateRule<T>
    {
        private readonly IEnumerable<IValidation> _validationRules;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="validationRules"></param>
        /// <param name="predicate"></param>
        /// <param name="context"></param>
        /// <param name="errorMessage"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public BranchRule(IEnumerable<IValidation> validationRules, Func<T, bool> predicate, RuleContext context, string errorMessage = null) : base(predicate, errorMessage, context)
        {
            _validationRules = validationRules ?? throw new ArgumentNullException(nameof(validationRules));
        }

        /// <inheritdoc/>
        public override ValidationRuleResult Validate(object instance)
        {
            try
            {
                if (base.Invoke(instance))
                {
                    var childResult = new FailFirstApplier().Apply(_validationRules, instance);

                    if (childResult == null || !childResult.Any())
                    {
                        return ValidationRuleResult.Success(this.Context.Member.Name,
                                                            this.Context.OperationName);
                    }

                    return ValidationRuleResult.Failure(this.Context.Member.Name,
                                                        this.Context.OperationName,
                                                        this.ErrorMessage,
                                                        childResult);
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new ValidationMarkerException(nameof(BranchRule<T>), $"Occurred exception in [{nameof(BranchRule<T>)}]. Please check detail error information [InnerErorr]!", ex);
            }
        }
    }
}
