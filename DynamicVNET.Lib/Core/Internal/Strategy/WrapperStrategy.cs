namespace DynamicVNET.Lib.Internal
{
    /// <seealso cref="DynamicVNET.Lib.Internal.BuilderStrategy" />
    public class WrapperStrategy : BuilderStrategy
    {
        private readonly Wrapper _wrapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="WrapperStrategy"/> class.
        /// </summary>
        /// <param name="wrapper">The wrapper.</param>
        /// <param name="marker">The marker.</param>
        public WrapperStrategy(Wrapper wrapper, BaseRuleMarker marker) : base(marker)
        {
            _wrapper = wrapper;
        }

        /// <summary>
        /// Result the is suitable.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <returns></returns>
        protected override bool ResultIsSuitable(ValidationRuleResult result)
        {
            if(base.ResultIsSuitable(result))
            {
                return _wrapper(result);
            }

            return false;
        }

        public delegate bool Wrapper(ValidationRuleResult result);
    }
}
