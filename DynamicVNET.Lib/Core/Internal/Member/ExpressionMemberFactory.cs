using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DynamicVNET.Lib.Internal
{
    /// <summary>
    /// Factory for pooling <see cref="ExpressionMember"/>. Safely implemented with synchronization context.
    /// </summary>
    public static class ExpressionMemberFactory
    {
        private static object _LOCK_OBJ = new object();
        private static IDictionary<int, ExpressionMember> _membersPool { get; }

        /// <summary>
        /// Initializes the <see cref="ExpressionMemberFactory"/> class.
        /// </summary>
        static ExpressionMemberFactory()
        {
            _membersPool = new Dictionary<int, ExpressionMember>();
        }

        /// <summary>
        /// Creates for <see cref="{T}"/> instance.
        /// </summary>
        /// <returns><see cref="ExpressionMember"/></returns>
        public static ExpressionMember Create<T>()
        {
            Type type = typeof(T);
            Expression<Func<T, T>> expression = x => x;
            ExpressionMember newMember = new ExpressionMember(expression, type, type);
            return newMember;
        }

        /// <summary>
        /// Creates the specified expression.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TMember">The type of the member.</typeparam>
        /// <param name="expression">The expression.</param>
        /// <param name="inPool">if set to <c>true</c> [in pool].</param>
        /// <returns> <see cref="ExpressionMember"/></returns>
        /// <exception cref="ArgumentNullException">expression</exception>
        public static ExpressionMember Create<T, TMember>(Expression<Func<T, TMember>> expression, bool inPool = true)
        {
            if (expression == null)
                throw new ArgumentNullException(nameof(expression));

            ExpressionMember createExpMember() => new ExpressionMember(expression, typeof(T), typeof(TMember));

            if (inPool)
            {
                lock (_LOCK_OBJ)
                {
                    int expHashCode = CreateHashCode(typeof(T), expression);

                    if (_membersPool.TryGetValue(expHashCode, out ExpressionMember member))
                    {
                        return member;
                    }
                    else
                    {
                        var newMember = createExpMember();
                        _membersPool.Add(expHashCode, newMember);
                        return newMember;
                    }
                }
            }
            else
            {
                return createExpMember();
            }
        }

        private static int CreateHashCode(Type type, Expression expression)
        {
            string expStr = expression.ToString();
            string nameStr = type.FullName.ToString();
            return $"{expStr}{nameStr}".GetHashCode();
        }
    }
}
