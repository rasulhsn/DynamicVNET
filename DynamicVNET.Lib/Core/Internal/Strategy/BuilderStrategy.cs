using System;
using System.Collections.Generic;

namespace DynamicVNET.Lib.Internal
{
    /// <seealso cref="DynamicVNET.Lib.Internal.IBuilderStrategy" />
    public class BuilderStrategy : IBuilderStrategy
    {
        protected readonly BaseRuleMarker Marker;

        /// <summary>
        /// Initializes a new instance of the <see cref="BuilderStrategy"/> class.
        /// </summary>
        /// <param name="marker">The marker.</param>
        /// <exception cref="ArgumentNullException">BaseRuleMarker</exception>
        public BuilderStrategy(BaseRuleMarker marker)
        {
            this.Marker = marker ?? throw new ArgumentNullException(nameof(BaseRuleMarker));
        }

        /// <summary>
        /// Build the specified instance.
        /// </summary>
        /// <param name="instance">The instance.</param>
        /// <returns></returns>
        public IEnumerable<ValidationRuleResult> Build(object instance)
        {
            List<ValidationRuleResult> appliedResults = new List<ValidationRuleResult>();

            foreach (var rule in Marker.Rules)
            {
                if (IsSuitableForApplying(rule))
                {
                    rule.Apply(instance);

                    if (ResultIsSuitable(rule.Context.RuleResult))
                    {
                        appliedResults.Add(rule.Context.RuleResult);
                    }
                }
            }

            return appliedResults.Count == 0 ? null : appliedResults;
        }

        /// <summary>
        /// Determines whether [is suitable for applying] [the specified rule].
        /// </summary>
        /// <param name="rule">The rule.</param>
        /// <returns>
        ///   <c>true</c> if [is suitable for applying] [the specified rule]; otherwise, <c>false</c>.
        /// </returns>
        protected virtual bool IsSuitableForApplying(IValidationRule rule)
        {
            if (rule != null)
                return true;

            return false;
        }

        /// <summary>
        /// Result the is suitable.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <returns></returns>
        protected virtual bool ResultIsSuitable(ValidationRuleResult result)
        {
            if (result != null)
                return true;

            return false;
        }
    }
}
