using System;

namespace DynamicVNET.Lib.Internal
{
    /// <seealso cref="IMember" />
    public class EmptyMember : IMember
    {
        ///<inheritdoc cref="IMember.Type"/>
        public Type Type { get; }

        ///<inheritdoc cref="IMember.IsNullable"/>
        public bool IsNullable { get; }

        ///<inheritdoc cref="IMember.IsFieldOrProperty"/>
        public bool IsFieldOrProperty { get; }

        ///<inheritdoc cref="IMember.Name"/>
        public string Name { get; }

        ///<inheritdoc cref="IMember.TypeDefinedAs"/>
        public Defination TypeDefinedAs { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="EmptyMember"/> class.
        /// </summary>
        public EmptyMember(string name,
                            Type type,
                            bool isNullable = true,
                            bool isFieldOrProperty = false,
                            Defination typeDefinedAs = Defination.Primitive)
        {
            this.Name = name;
            this.Type = type;
            this.IsNullable = isNullable;
            this.IsFieldOrProperty = isFieldOrProperty;
            this.TypeDefinedAs = typeDefinedAs;
        }

        /// <exception cref="NotImplementedException"></exception>
        public object ResolveValue(object instance)
        {
            throw new NotImplementedException();
        }
    }
}
