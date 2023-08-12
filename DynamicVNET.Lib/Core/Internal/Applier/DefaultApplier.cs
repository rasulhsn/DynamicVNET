
namespace DynamicVNET.Lib
{
    /// <seealso cref="DynamicVNET.Lib.Applier" />
    public class DefaultApplier : Applier
    {
        /// <inheritdoc/>
        protected override bool IsSuitable(ValidationRuleResult result)
        {
            if (result != null)
            {
                return true;
            }

            return false;
        }

        /// <inheritdoc/>
        protected override bool Terminate(ValidationRuleResult result)
        {
            return false;
        }

        /// <inheritdoc/>
        protected override ValidationRuleResult RewriteResult(ValidationRuleResult result)
        {
            return result;
        }
    }
}
