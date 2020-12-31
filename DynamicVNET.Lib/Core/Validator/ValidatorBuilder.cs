using DynamicVNET.Lib.Internal;

namespace DynamicVNET.Lib
{
    public class ValidatorBuilder<T>
    {
        private readonly ValidatorContext _context;

        /// <summary>
        /// Initial marker for all validation
        /// </summary>
        public RuleMarker<T> Marker { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidatorBuilder{T}"/> class.
        /// </summary>
        public ValidatorBuilder()
        {
            Marker = new RuleMarker<T>();
            _context = new ValidatorContext(Marker, typeof(T));
        }

        /// <summary>
        /// Set the strategy.
        /// </summary>
        /// <param name="strategy">The build strategy.</param>
        /// <returns></returns>
        public ValidatorBuilder<T> SetStrategy(IBuilderStrategy strategy)
        {
            _context.Strategy = strategy;
            return this;
        }

        /// <summary>
        /// Sets the strategy.
        /// </summary>
        /// <param name="strategy">The strategy.</param>
        /// <returns></returns>
        public ValidatorBuilder<T> SetStrategy(WrapperStrategy.Wrapper strategy)
        {
            SetStrategy(new WrapperStrategy(strategy, Marker));
            return this;
        }

        /// <summary>
        /// Build <see cref="IValidator{T}"/>.
        /// </summary>
        public virtual IValidator<T> Build()
        {
            return new Validator<T>(_context);
        }
    }
}
