namespace DynamicVNET.Lib.Internal
{
    public interface IValidationRule : IValidation
    {
        /// <summary>
        /// Gets the context.
        /// </summary>
        /// <value>
        /// The context.
        /// </value>
        RuleContext Context { get; }
    }
}
