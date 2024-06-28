using DynamicVNET.Lib.Internal;

namespace DynamicVNET.Lib
{
    public interface IMemberRuleMarker : IRuleMarker
    {
        /// <summary>
        /// Get and Set the selected.
        /// </summary>
        IMember Selected { get; set; }

        /// <summary>
        /// Create the copy.
        /// </summary>
        IMemberRuleMarker Copy();
    }
}
