namespace DynamicVNET.Lib.Internal
{
    public interface IValidationRule
    {
        /// <summary>
        /// Gets the context.
        /// </summary>
        /// <value>
        /// The context.
        /// </value>
        RuleContext Context { get; }

        /// <summary>
        /// Applies the specified instance.
        /// </summary>
        /// <param name="instance">The instance.</param>
        void Apply(object instance);
    }
}
