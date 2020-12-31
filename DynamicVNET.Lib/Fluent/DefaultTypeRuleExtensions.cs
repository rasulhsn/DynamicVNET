using DynamicVNET.Lib.Internal;
using System;
using System.Linq.Expressions;

namespace DynamicVNET.Lib
{
    public static class DefaultTypeRuleExtensions
    {

        /// <summary>
        /// Marker For selecting specified member.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TMember">The type of the member.</typeparam>
        /// <param name="builder">The builder.</param>
        /// <param name="member">The member.</param>
        /// <returns></returns>
        public static MemberRuleMarker<T> For<T, TMember>(this RuleMarker<T> builder, Expression<Func<T, TMember>> member)
        {
            ExpressionMember expMember = ExpressionMemberFactory.Create(member);
            return new MemberRuleMarker<T>(expMember, builder);
        }

        /// <summary>
        /// Marker Null.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TMember">The type of the member.</typeparam>
        /// <param name="builder">The builder.</param>
        /// <param name="member">The member.</param>
        /// <param name="errorMessage">The error message.</param>
        /// <returns></returns>
        public static RuleMarker<T> Null<T, TMember>(this RuleMarker<T> builder, Expression<Func<T, TMember>> member, string errorMessage = DefaultRuleExtensions.ERROR_NULL) where TMember : class
        {
            Utility.SafeMark<T>(() =>
            {
                ExpressionMember expMember = ExpressionMemberFactory.Create(member);
                builder.Null(expMember, errorMessage);
            }, nameof(Null));
            return builder;
        }

        /// <summary>
        /// Marker Not null.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TMember">The type of the member.</typeparam>
        /// <param name="builder">The builder.</param>
        /// <param name="member">The member.</param>
        /// <param name="errorMessage">The error message.</param>
        /// <returns></returns>
        public static RuleMarker<T> NotNull<T, TMember>(this RuleMarker<T> builder, Expression<Func<T, TMember>> member, string errorMessage = DefaultRuleExtensions.ERROR_NOT_NULL) where TMember : class
        {
            Utility.SafeMark<T>(() =>
            {
                ExpressionMember expMember = ExpressionMemberFactory.Create(member);
                builder.NotNull(expMember, errorMessage);
            }, nameof(NotNull));
            return builder;
        }



        /// <summary>
        /// Marker Predicate with specified condition.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="builder">The builder.</param>
        /// <param name="condition">The condition.</param>
        /// <param name="firstErrorMessage">The first error message.</param>
        /// <returns></returns>
        public static RuleMarker<T> Predicate<T>(this RuleMarker<T> builder, Func<T, bool> condition, string firstErrorMessage = DefaultRuleExtensions.ERROR_CUSTOM)
        {
            Utility.SafeMark<T>(() =>
            {
                ExpressionMember expMember = ExpressionMemberFactory.Create<T>();
                builder.Add(new PredicateRule<T>(condition, firstErrorMessage, new RuleContext("Custom", expMember)));
            }, nameof(Predicate));
            return builder;
        }

        /// <summary>
        /// Marker String length
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TMember">The type of the member.</typeparam>
        /// <param name="builder">The builder.</param>
        /// <param name="member">The member.</param>
        /// <param name="max">The maximum.</param>
        /// <returns></returns>
        public static RuleMarker<T> StringLen<T, TMember>(this RuleMarker<T> builder, Expression<Func<T, TMember>> member, int max)
        {
            Utility.SafeMark<T>(() =>
            {
                ExpressionMember expMember = ExpressionMemberFactory.Create(member);
                builder.StringLen(expMember, max);
            }, nameof(StringLen));
            return builder;
        }

        /// <summary>
        /// Marker Email address.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TMember">The type of the member.</typeparam>
        /// <param name="builder">The builder.</param>
        /// <param name="member">The member.</param>
        /// <returns></returns>
        public static RuleMarker<T> EmailAddress<T, TMember>(this RuleMarker<T> builder, Expression<Func<T, TMember>> member)
        {
            Utility.SafeMark<T>(() =>
            {
                ExpressionMember expMember = ExpressionMemberFactory.Create(member);
                builder.RegularExp(expMember, nameof(EmailAddress), DefaultRuleExtensions.EMAIL_PATTERN);
            }, nameof(EmailAddress));
            return builder;
        }

        /// <summary>
        /// Marker Phone number.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TMember">The type of the member.</typeparam>
        /// <param name="builder">The builder.</param>
        /// <param name="member">The member.</param>
        /// <returns></returns>
        public static RuleMarker<T> PhoneNumber<T, TMember>(this RuleMarker<T> builder, Expression<Func<T, TMember>> member)
        {
            Utility.SafeMark<T>(() =>
            {
                ExpressionMember expMember = ExpressionMemberFactory.Create(member);
                builder.RegularExp(expMember, nameof(PhoneNumber), DefaultRuleExtensions.PHONE_PATTERN);
            }, nameof(PhoneNumber));
            return builder;
        }

        /// <summary>
        /// Marker URL.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TMember">The type of the member.</typeparam>
        /// <param name="builder">The builder.</param>
        /// <param name="member">The member.</param>
        /// <returns></returns>
        public static RuleMarker<T> Url<T, TMember>(this RuleMarker<T> builder, Expression<Func<T, TMember>> member)
        {
            Utility.SafeMark<T>(() =>
            {
                ExpressionMember expMember = ExpressionMemberFactory.Create(member);
                builder.RegularExp(expMember, nameof(Url), DefaultRuleExtensions.URL_PATTERN);
            }, nameof(Url));
            return builder;
        }

        /// <summary>
        /// Marker Required.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TMember">The type of the member.</typeparam>
        /// <param name="builder">The builder.</param>
        /// <param name="member">The member.</param>
        /// <returns></returns>
        public static RuleMarker<T> Required<T, TMember>(this RuleMarker<T> builder, Expression<Func<T, TMember>> member)
        {
            Utility.SafeMark<T>(() =>
            {
                ExpressionMember expMember = ExpressionMemberFactory.Create(member);
                builder.Required(expMember);
            }, nameof(Required));
            return builder;
        }



        /// <summary>
        /// Marker Maximum length.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TMember">The type of the member.</typeparam>
        /// <param name="builder">The builder.</param>
        /// <param name="member">The member.</param>
        /// <param name="length">The length.</param>
        /// <returns></returns>
        public static RuleMarker<T> MaxLen<T, TMember>(this RuleMarker<T> builder, Expression<Func<T, TMember>> member, int length = 0)
        {
            Utility.SafeMark<T>(() =>
            {
                ExpressionMember expMember = ExpressionMemberFactory.Create(member);
                builder.MaxLen(expMember, length);
            }, nameof(MaxLen));
            return builder;
        }

        /// <summary>
        /// Marker Regular expressions.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TMember">The type of the member.</typeparam>
        /// <param name="builder">The builder.</param>
        /// <param name="member">The member.</param>
        /// <param name="pattern">The pattern.</param>
        /// <returns></returns>
        public static RuleMarker<T> RegularExp<T, TMember>(this RuleMarker<T> builder, Expression<Func<T, TMember>> member, string pattern)
        {
            Utility.SafeMark<T>(() =>
            {
                ExpressionMember expMember = ExpressionMemberFactory.Create(member);
                builder.RegularExp(expMember, nameof(RegularExp), pattern);
            }, nameof(RegularExp));
            return builder;
        }

        /// <summary>
        /// Marker Range.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TMember">The type of the member.</typeparam>
        /// <param name="builder">The builder.</param>
        /// <param name="member">The member.</param>
        /// <param name="min">The minimum.</param>
        /// <param name="max">The maximum.</param>
        /// <returns></returns>
        public static RuleMarker<T> Range<T, TMember>(this RuleMarker<T> builder, Expression<Func<T, TMember>> member, double min, double max)
        {
            Utility.SafeMark<T>(() =>
            {
                ExpressionMember expMember = ExpressionMemberFactory.Create(member);
                builder.Range(expMember, min, max);
            }, nameof(Range));
            return builder;
        }

        /// <summary>
        /// Marker Range.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TMember">The type of the member.</typeparam>
        /// <param name="builder">The builder.</param>
        /// <param name="member">The member.</param>
        /// <param name="min">The minimum.</param>
        /// <param name="max">The maximum.</param>
        /// <returns></returns>
        public static RuleMarker<T> Range<T, TMember>(this RuleMarker<T> builder, Expression<Func<T, TMember>> member, int min, int max)
        {
            Utility.SafeMark<T>(() =>
            {
                ExpressionMember expMember = ExpressionMemberFactory.Create(member);
                builder.Range(expMember, min, max);
            }, nameof(Range));
            return builder;
        }

        /// <summary>
        /// Marker Range.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TMember">The type of the member.</typeparam>
        /// <param name="builder">The builder.</param>
        /// <param name="member">The member.</param>
        /// <param name="type">The type.</param>
        /// <param name="min">The minimum.</param>
        /// <param name="max">The maximum.</param>
        /// <returns></returns>
        public static RuleMarker<T> Range<T, TMember>(this RuleMarker<T> builder, Expression<Func<T, TMember>> member, Type type, string min, string max)
        {
            Utility.SafeMark<T>(() =>
            {
                ExpressionMember expMember = ExpressionMemberFactory.Create(member);
                builder.Range(expMember, type, min, max);
            }, nameof(Range));
            return builder;
        }

        /// <summary>
        /// Marker Branch with specified condition.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="builder">The builder.</param>
        /// <param name="condition">The condition.</param>
        /// <param name="setup">The setup.</param>
        /// <returns></returns>
        public static RuleMarker<T> Branch<T>(this RuleMarker<T> builder, Func<T, bool> condition, Action<RuleMarker<T>> setup)
        {
            Utility.SafeMark<T>(() =>
            {
                if (setup == null)
                    throw new ArgumentNullException(nameof(setup) + " can not be null in " + nameof(Branch));

                var innerBuilder = new RuleMarker<T>();

                setup.Invoke(innerBuilder);

                builder.Add(new BranchRule<T>(new OnlyInvalidResultStrategy(innerBuilder), condition, new RuleContext(nameof(Branch), new EmptyMember(condition.ToString(), typeof(T)))));

            }, nameof(Branch));
            return builder;
        }
    }
}
