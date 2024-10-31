using System;

namespace DynamicVNET.Lib.Internal
{
    public enum Defination : byte
    {
        Class = 1,
        Struct = 2,
        String = 3,
        Primitive = 4,
        Other = 5,
        Decimal = 6,
        Double = 7,
        Float = 8,
        Int = 9,
        Byte = 10,
        Uknown = 11,
    }

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
        /// Gets a definition of the type.
        /// </summary>
        Defination TypeDefinedAs { get; }

        /// <summary>
        /// Resolves the member value.
        /// </summary>
        /// <param name="instance">The instance.</param>
        object ResolveValue(object instance);
    }
}
