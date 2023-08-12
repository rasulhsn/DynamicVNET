
namespace DynamicVNET.Lib
{
    /// <seealso cref="DynamicVNET.Lib.DefaultApplier" />
    public sealed class FailFirstApplier : DefaultApplier
    {
        /// <inheritdoc/>
        protected override bool Terminate(ValidationRuleResult result)
        {
            if (!result.IsValid)
            {
                return true;
            }

            return base.Terminate(result);
        }

        /// <inheritdoc/>
        protected override bool IsSuitable(ValidationRuleResult result)
        {
            if (base.IsSuitable(result) && !result.IsValid)
            {
                return true;
            }

            return false;
        }
    }
}
