namespace DynamicVNET.Lib.Internal
{
    /// <seealso cref="DynamicVNET.Lib.Internal.BuilderStrategy" />
    public class OnlyInvalidResultStrategy : BuilderStrategy
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OnlyInvalidResultStrategy"/> class.
        /// </summary>
        /// <param name="marker">The marker.</param>
        public OnlyInvalidResultStrategy(BaseRuleMarker marker) : base(marker) { }

        /// <summary>
        /// Result the is suitable.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <returns></returns>
        protected override bool ResultIsSuitable(ValidationRuleResult result)
        {
            if (base.ResultIsSuitable(result) && !result.IsValid)
                return true;

            return false;
        }
    }
}
