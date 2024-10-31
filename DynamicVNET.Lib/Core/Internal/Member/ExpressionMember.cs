using System;
using System.Linq.Expressions;

namespace DynamicVNET.Lib.Internal
{
    /// <seealso cref="DynamicVNET.Lib.Internal.IMember" />
    public class ExpressionMember : IMember
    {
        private readonly Type _parentType;
        private readonly LambdaExpression _memberExpression;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExpressionMember"/> class.
        /// </summary>
        /// <param name="expression">The expression.</param>
        /// <param name="parent">The parent.</param>
        /// <param name="member">The member.</param>
        /// <exception cref="ArgumentNullException">
        /// member
        /// or
        /// expression
        /// </exception>
        internal ExpressionMember(LambdaExpression expression,
                                    Type parent,
                                    Type member)
        {
            this._parentType = parent;
            this.Type = member ?? throw new ArgumentNullException(nameof(member));
            this._memberExpression = expression ?? throw new ArgumentNullException(nameof(expression));

            this.Initialize();
        }

        ///<inheritdoc cref="IMember.IsNullable"/>
        public bool IsNullable
        {
            get
            {
                if (Type == typeof(string) || Type.IsClass)
                {
                    return true;
                }

                return Nullable.GetUnderlyingType(Type) != null;
            }
        }

        ///<inheritdoc cref="IMember.Name"/>
        public string Name { get; private set; }

        ///<inheritdoc cref="IMember.Type"/>
        public Type Type { get; }

        ///<inheritdoc cref="IMember.IsFieldOrProperty"/>
        public bool IsFieldOrProperty { get; private set; }

        ///<inheritdoc cref="IMember.TypeDefinedAs"/>
        public Defination TypeDefinedAs { get; private set; }

        ///<inheritdoc cref="IMember.ResolveValue"/>
        public object ResolveValue(object instance)
        {
            try
            {
                return _memberExpression
                        .Compile()
                        .DynamicInvoke(instance);
            }
            catch
            {
                throw;
            }
        }

        private void Initialize()
        {
            if (this._memberExpression.Body.NodeType != ExpressionType.Parameter)
            {
                this.TypeDefinedAs = GetDefinedAs(this.Type);

                if (IsDefinedAs(Defination.Class) || IsDefinedAs(Defination.Struct))
                {
                    TrySetDesriptorInfo(this._memberExpression);
                }
            }

            this.Name = string.IsNullOrEmpty(this.Name) ? "" : this.Name;
        }

        private bool TrySetDesriptorInfo(LambdaExpression memberExpression)
        {
            if (IsPropertyOrField(memberExpression.Body, out MemberExpression operand))
            {
                if (operand.NodeType != ExpressionType.Parameter)
                {
                    this.Name = operand.Member.Name;
                    this.IsFieldOrProperty = true;
                    return true;
                }
            }
            else if (IsMethod(memberExpression.Body, out MethodCallExpression callOperand))
            {
                if (callOperand.NodeType != ExpressionType.Parameter)
                {
                    this.Name = callOperand.Method.Name;
                    this.IsFieldOrProperty = false;
                    return true;
                }
            }

            return false;
        }

        private bool IsMethod(Expression toUp, out MethodCallExpression methodCallExpression)
        {
            if (toUp is MethodCallExpression)
            {
                methodCallExpression = toUp as MethodCallExpression;
                return true;
            }

            methodCallExpression = default(MethodCallExpression);
            return false;
        }

        private bool IsPropertyOrField(Expression toUp, out MemberExpression memberExpression)
        {
            if (toUp is UnaryExpression upOperand)
            {
                if ((memberExpression = (upOperand.Operand as MemberExpression)) != null)
                {
                    return true;
                }
            }
            else if ((memberExpression = (toUp as MemberExpression)) != null)
            {
                return true;
            }

            memberExpression = default(MemberExpression);
            return false;
        }

        private bool IsDefinedAs(Defination defination)
        {
            if ((_parentType == typeof(string) && defination == Defination.String)
                        || (_parentType.IsPrimitive && defination == Defination.Primitive)
                        || (_parentType.IsValueType && defination == Defination.Struct)
                        || (_parentType.IsClass && defination == Defination.Class))
            {
                return true;
            }

            return false;
        }

        private Defination GetDefinedAs(Type memberType)
        {
            if (memberType == typeof(string))
                return Defination.String;
            else if (memberType == typeof(double))
                return Defination.Double;
            else if (memberType == typeof(decimal))
                return Defination.Decimal;
            else if (memberType == typeof(float))
                return Defination.Float;
            else if (memberType == typeof(int))
                return Defination.Int;
            else if (memberType == typeof(byte))
                return Defination.Byte;
            else if (memberType.IsPrimitive)
                return Defination.Primitive;
            else if (memberType.IsValueType)
                return Defination.Struct;
            else if (memberType.IsClass)
                return Defination.Class;
            else
                return Defination.Uknown;
        }
    }
}
