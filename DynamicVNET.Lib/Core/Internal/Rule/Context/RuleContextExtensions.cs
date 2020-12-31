using System.Collections.Generic;

namespace DynamicVNET.Lib.Internal
{
    /// <seealso cref="DynamicVNET.Lib.Internal.RuleContext" />
    public static class RuleContextExtensions
    {
        /// <summary>
        /// Sets the result.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        public static ValidationRuleResult SetResult(this RuleContext context)
        {
            ValidationRuleResult result = ValidationRuleResult.Success(context.Member.EndPointName, context.OperationName);
            context.SetResult(result);
            return result;
        }

        /// <summary>
        /// Sets the result.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public static ValidationRuleResult SetResult(this RuleContext context, string message)
        {
            ValidationRuleResult result = ValidationRuleResult.Failure(context.Member.EndPointName, context.OperationName, message);
            context.SetResult(result);
            return result;
        }

        /// <summary>
        /// Sets the result.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="message">The message.</param>
        /// <param name="nested">The nested.</param>
        /// <returns></returns>
        public static ValidationRuleResult SetResult(this RuleContext context, string message, IEnumerable<ValidationRuleResult> nested)
        {
            ValidationRuleResult result = ValidationRuleResult.Failure(context.Member.EndPointName, context.OperationName, message, nested);
            context.SetResult(result);
            return result;
        }
    }
}
