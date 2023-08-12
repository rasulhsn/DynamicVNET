using System;

namespace DynamicVNET.Lib.Internal
{
    public interface IMember
    {
        /// <summary>
        /// Gets the member type.
        /// </summary>
        Type Type { get; }

        /// <summary>
        /// Gets a value indicating whether member is nullable.
        /// </summary>
        bool IsNullable { get; }

        /// <summary>
        /// Gets a value indicating whether member is field or property.
        /// </summary>
        bool IsFieldOrProperty { get; }

        /// <summary>
        /// Gets the end of the name for example name of marked property or field.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Resolves the member value.
        /// </summary>
        /// <param name="instance">The instance.</param>
        object ResolveValue(object instance);
    }
}
