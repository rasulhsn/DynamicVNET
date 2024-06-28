using System;
using System.Collections.Concurrent;
using System.Linq.Expressions;

namespace DynamicVNET.Lib.Internal
{
    /// <summary>
    /// Pooling factory for <see cref="ExpressionMember"/>.
    /// Safely implemented through the ConcurrentDictionary.
    /// </summary>
    public static class ExpressionMemberFactory
    {
        private static ConcurrentDictionary<int, ExpressionMember> _pool;

        /// <summary>
        /// Static initializer the <see cref="ExpressionMemberFactory"/> class.
        /// </summary>
        static ExpressionMemberFactory()
        {
            _pool = new ConcurrentDictionary<int, ExpressionMember>();
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
        /// <param name="expression">The expression.</param>
        /// <param name="inPool">if set to <c>true</c> [in pool].</param>
        /// <returns> <see cref="ExpressionMember"/></returns>
        /// <exception cref="ArgumentNullException">expression</exception>
        public static ExpressionMember Create<T, TMember>(Expression<Func<T, TMember>> expression)
        {
            int _CreateHashCode(Type type, Expression expInstance)
                    => $"{expInstance.ToString()}{type.FullName.ToString()}"
                            .GetHashCode();
           
            if (expression == null)
            {
                throw new ArgumentNullException(nameof(expression));
            }

            int memberHashCode = _CreateHashCode(typeof(T), expression);

            if (_pool.TryGetValue(memberHashCode, out ExpressionMember member))
            {
                return member;
            }
            else
            {
                var newMember = new ExpressionMember(expression, typeof(T), typeof(TMember));
                _pool.TryAdd(memberHashCode, newMember);
                return newMember;
            }
        }
    }
}
