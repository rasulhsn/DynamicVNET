using System;

namespace DynamicVNET.Lib.Internal
{
    public interface IMember
    {
        /// <summary>
        /// Gets the type.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        Type Type { get; }

        /// <summary>
        /// Gets a value indicating whether this instance is nullable.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is nullable; otherwise, <c>false</c>.
        /// </value>
        bool IsNullable { get; }

        /// <summary>
        /// Gets a value indicating whether this instance is field or property.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is field or property; otherwise, <c>false</c>.
        /// </value>
        bool IsFieldOrProperty { get; }

        /// <summary>
        /// Gets the end name of the point.
        /// </summary>
        /// <value>
        /// The end name of the point.
        /// </value>
        string EndPointName { get; }

        /// <summary>
        /// Resolves the member value.
        /// </summary>
        /// <param name="instance">The instance.</param>
        object ResolveValue(object instance);
    }
}
