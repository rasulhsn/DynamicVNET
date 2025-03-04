﻿using System;
using System.Collections.Generic;
using DynamicVNET.Lib.Internal;

namespace DynamicVNET.Lib
{
    public abstract class Applier
    {
        /// <summary>
        /// Apply to the specified instance.
        /// </summary>
        /// <param name="instance">The instance.</param>
        public IEnumerable<ValidationRuleResult> Apply(IEnumerable<IValidation> validations, object instance)
        {
            if (validations == null)
            {
                throw new ArgumentNullException(nameof(validations));
            }

            List<ValidationRuleResult> appliedResults = new List<ValidationRuleResult>();

            foreach (var validationRule in validations)
            {
                ValidationRuleResult validationResult = validationRule.Validate(instance);

                if (IsSuitable(validationResult))
                {
                    ValidationRuleResult validationResultCopy = validationResult.Copy();

                    validationResultCopy = Override(validationResultCopy);

                    if (validationResultCopy != null)
                    {
                        validationResult = validationResultCopy;
                    }

                    appliedResults.Add(validationResult);

                    if (Break(validationResult))
                    {
                        break;
                    }
                }
            }

            return appliedResults.Count == 0 ? null : appliedResults;
        }
       
        /// <param name="result">The result.</param>
        protected abstract bool IsSuitable(ValidationRuleResult result);

        /// <param name="result">The result.</param>
        protected abstract bool Break(ValidationRuleResult result);

        /// <param name="result"></param>
        protected abstract ValidationRuleResult Override(ValidationRuleResult result);
    }
}
