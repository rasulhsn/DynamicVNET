namespace DynamicVNET.Lib.Internal
{
    public interface IValidation
    {
        /// <summary>
        /// Validate the specified instance.
        /// </summary>
        /// <param name="instance">The instance.</param>
        ValidationRuleResult Validate(object instance);
    }
}
