using System.Collections.Generic;

namespace DynamicVNET.Lib.Internal
{
    public interface IBuilderStrategy
    {
        /// <summary>
        /// Build the specified instance.
        /// </summary>
        /// <param name="instance">The instance.</param>
        IEnumerable<ValidationRuleResult> Build(object instance);
    }
}
