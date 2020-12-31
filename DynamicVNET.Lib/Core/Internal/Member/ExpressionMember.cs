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
        internal ExpressionMember(LambdaExpression expression, Type parent, Type member)
        {
            this._parentType = parent;
            this.Type = member ?? throw new ArgumentNullException(nameof(member));
            this._memberExpression = expression ?? throw new ArgumentNullException(nameof(expression));

            this.Initialize();
        }

        /// <summary>
        /// Gets a value indicating whether this instance is nullable.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is nullable; otherwise, <c>false</c>.
        /// </value>
        public bool IsNullable
        {
            get
            {
                if (Type == typeof(string))
                    return true;
                else if (Type.IsClass)
                    return true;
                else
                    return Nullable.GetUnderlyingType(Type) != null;
            }
        }
        /// <summary>
        /// Gets the end name of the point.
        /// </summary>
        /// <value>
        /// The end name of the point.
        /// </value>
        public string EndPointName { get; private set; }

        /// <summary>
        /// Gets the type.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        public Type Type { get; }

        /// <summary>
        /// Gets a value indicating whether this instance is field or property.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is field or property; otherwise, <c>false</c>.
        /// </value>
        public bool IsFieldOrProperty { get; private set; }

        /// <summary>
        /// Resolves the member value.
        /// </summary>
        /// <param name="instance">The instance.</param>
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
                if (IsDefinedAs(Defination.Class) || IsDefinedAs(Defination.Struct))
                {
                    TrySetDesriptorInfo(this._memberExpression);
                }
            }

            this.EndPointName = string.IsNullOrEmpty(this.EndPointName) ? "" : this.EndPointName;
        }

        private bool TrySetDesriptorInfo(LambdaExpression memberExpression)
        {
            if (IsMember(memberExpression.Body, out MemberExpression operand))
            {
                if (operand.NodeType != ExpressionType.Parameter)
                {
                    this.EndPointName = operand.Member.Name;
                    this.IsFieldOrProperty = true;
                    return true;
                }
            }
            else if (IsMethod(memberExpression.Body, out MethodCallExpression callOperand))
            {
                if (callOperand.NodeType != ExpressionType.Parameter)
                {
                    this.EndPointName = callOperand.Method.Name;
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

        private bool IsMember(Expression toUp, out MemberExpression memberExpression)
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
            if (_parentType == typeof(string) && defination == Defination.String)
                return true;
            else if (_parentType.IsPrimitive && defination == Defination.Primitive)
                return true;
            else if (_parentType.IsValueType && defination == Defination.Struct)
                return true;
            else if (_parentType.IsClass && defination == Defination.Class)
                return true;

            return false;
        }

        enum Defination : byte
        {
            Class = 1, Struct = 2, String = 3, Primitive = 4, Other = 5
        }
    }
}
