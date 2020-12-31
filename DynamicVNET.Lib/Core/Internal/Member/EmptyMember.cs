using System;

namespace DynamicVNET.Lib.Internal
{
    /// <seealso cref="DynamicVNET.Lib.Internal.IMember" />
    public class EmptyMember : IMember
    {
        public Type Type { get; }

        public bool IsNullable { get; }

        public bool IsFieldOrProperty { get; }

        public string EndPointName { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="EmptyMember"/> class.
        /// </summary>
        /// <param name="endPointName">End name of the point.</param>
        /// <param name="type">The type.</param>
        /// <param name="isNullable">if set to <c>true</c> [is nullable].</param>
        /// <param name="isFieldOrProperty">if set to <c>true</c> [is field or property].</param>
        public EmptyMember(string endPointName, Type type, bool isNullable = true, bool isFieldOrProperty = false)
        {
            this.EndPointName = endPointName;
            this.Type = type;
            this.IsNullable = isNullable;
            this.IsFieldOrProperty = isFieldOrProperty;
        }

        /// <exception cref="NotImplementedException"></exception>
        public object ResolveValue(object instance)
        {
            throw new NotImplementedException();
        }
    }
}
