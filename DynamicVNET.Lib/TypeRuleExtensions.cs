using DynamicVNET.Lib.Helper;
using DynamicVNET.Lib.Internal;
using System;
using System.Linq.Expressions;

namespace DynamicVNET.Lib
{
    public static class TypeRuleExtensions
    {
        /// <summary>
        /// Marker For the specified member.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TMember">The type of the member.</typeparam>
        /// <param name="builder">The builder.</param>
        /// <param name="member">The member.</param>
        public static IMemberRuleMarker For<T, TMember>(this ITypeRuleMarker<T> builder, Expression<Func<T, TMember>> member)
        {
            var expMember = ExpressionMemberFactory.Create(member);

            IMemberRuleMarker memberBuilder = builder as IMemberRuleMarker;
            
            if (memberBuilder != null)
            {
                memberBuilder.Selected = expMember;
            }

            return memberBuilder;
        }

        /// <summary>
        /// Marker Null.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TMember">The type of the member.</typeparam>
        /// <param name="builder">The builder.</param>
        /// <param name="member">The member.</param>
        /// <param name="errorMessage">The error message.</param>
        public static ITypeRuleMarker<T> Null<T, TMember>(this ITypeRuleMarker<T> builder, Expression<Func<T, TMember>> member, string errorMessage = RuleExtensions.ERROR_NULL) where TMember : class
        {
            Utility.TrackTrace<T>(() =>
            {
                var expMember = ExpressionMemberFactory.Create(member);
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
        public static ITypeRuleMarker<T> NotNull<T, TMember>(this ITypeRuleMarker<T> builder, Expression<Func<T, TMember>> member, string errorMessage = RuleExtensions.ERROR_NOT_NULL) where TMember : class
        {
            Utility.TrackTrace<T>(() =>
            {
                var expMember = ExpressionMemberFactory.Create(member);
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
        public static ITypeRuleMarker<T> Predicate<T>(this ITypeRuleMarker<T> builder, Func<T, bool> condition, string firstErrorMessage = RuleExtensions.ERROR_CUSTOM)
        {
            Utility.TrackTrace<T>(() =>
            {
                var expMember = ExpressionMemberFactory.Create<T>();
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
        public static ITypeRuleMarker<T> StringLen<T, TMember>(this ITypeRuleMarker<T> builder, Expression<Func<T, TMember>> member, int max, int? min = null)
        {
            Utility.TrackTrace<T>(() =>
            {
                var expMember = ExpressionMemberFactory.Create(member);
                builder.StringLen(expMember, max, min);
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
        public static ITypeRuleMarker<T> EmailAddress<T, TMember>(this ITypeRuleMarker<T> builder, Expression<Func<T, TMember>> member)
        {
            Utility.TrackTrace<T>(() =>
            {
                var expMember = ExpressionMemberFactory.Create(member);
                builder.RegularExp(expMember, nameof(EmailAddress), RuleExtensions.EMAIL_PATTERN);
            }, nameof(EmailAddress));
            return builder;
        }

        /// <summary>
        /// Marker URL.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TMember">The type of the member.</typeparam>
        /// <param name="builder">The builder.</param>
        /// <param name="member">The member.</param>
        public static ITypeRuleMarker<T> Url<T, TMember>(this ITypeRuleMarker<T> builder, Expression<Func<T, TMember>> member)
        {
            Utility.TrackTrace<T>(() =>
            {
                var expMember = ExpressionMemberFactory.Create(member);
                builder.RegularExp(expMember, nameof(Url), RuleExtensions.URL_PATTERN);
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
        public static ITypeRuleMarker<T> Required<T, TMember>(this ITypeRuleMarker<T> builder, Expression<Func<T, TMember>> member)
        {
            Utility.TrackTrace<T>(() =>
            {
                var expMember = ExpressionMemberFactory.Create(member);
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
        public static ITypeRuleMarker<T> MaxLen<T, TMember>(this ITypeRuleMarker<T> builder, Expression<Func<T, TMember>> member, int length = 0)
        {
            Utility.TrackTrace<T>(() =>
            {
                var expMember = ExpressionMemberFactory.Create(member);
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
        public static ITypeRuleMarker<T> RegularExp<T, TMember>(this ITypeRuleMarker<T> builder, Expression<Func<T, TMember>> member, string pattern)
        {
            Utility.TrackTrace<T>(() =>
            {
                var expMember = ExpressionMemberFactory.Create(member);
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
        public static ITypeRuleMarker<T> Range<T, TMember>(this ITypeRuleMarker<T> builder, Expression<Func<T, TMember>> member, double min, double max)
        {
            Utility.TrackTrace<T>(() =>
            {
                var expMember = ExpressionMemberFactory.Create(member);
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
        public static ITypeRuleMarker<T> Range<T, TMember>(this ITypeRuleMarker<T> builder, Expression<Func<T, TMember>> member, int min, int max)
        {
            Utility.TrackTrace<T>(() =>
            {
                var expMember = ExpressionMemberFactory.Create(member);
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
        public static ITypeRuleMarker<T> Range<T, TMember>(this ITypeRuleMarker<T> builder, Expression<Func<T, TMember>> member, Type type, string min, string max)
        {
            Utility.TrackTrace<T>(() =>
            {
                var expMember = ExpressionMemberFactory.Create(member);
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
        public static ITypeRuleMarker<T> Branch<T>(this ITypeRuleMarker<T> builder, Func<T, bool> condition, Action<ITypeRuleMarker<T>> setup)
        {
            Utility.TrackTrace<T>(() =>
            {
                if (setup == null)
                {
                    throw new ArgumentNullException(nameof(setup) + " can not be null in " + nameof(Branch));
                }

                var nestedMarker = new RuleMarker<T>();
                setup.Invoke(nestedMarker);

                builder.Add(new BranchRule<T>(nestedMarker.Rules,
                                                condition,
                                                new RuleContext(nameof(Branch),
                                                new EmptyMember(condition.ToString(),
                                                typeof(T)))));
            }, nameof(Branch));
            return builder;
        }
    }
}
