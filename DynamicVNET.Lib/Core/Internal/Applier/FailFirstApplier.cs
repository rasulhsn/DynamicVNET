namespace DynamicVNET.Lib
{
    /// <seealso cref="DynamicVNET.Lib.DefaultApplier" />
    public class FailFirstApplier : DefaultApplier
    {
        /// <inheritdoc/>
        protected override bool Break(ValidationRuleResult result)
        {
            if (!result.IsValid)
            {
                return true;
            }

            return base.Break(result);
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
