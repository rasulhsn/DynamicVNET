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
        protected override bool Break(ValidationRuleResult result)
        {
            return false;
        }

        /// <inheritdoc/>
        protected override ValidationRuleResult Override(ValidationRuleResult result)
        {
            return result;
        }
    }
}
