using System;
using DynamicVNET.Lib.Internal;

namespace DynamicVNET.Lib
{
    public static class DefaultMemberRuleExtensions
    {
        /// <summary>
        /// Marker Null with specified error message.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="builder">The builder.</param>
        /// <param name="errorMessage">The error message.</param>
        /// <returns></returns>
        public static MemberRuleMarker<T> Null<T>(this MemberRuleMarker<T> builder, string errorMessage = DefaultRuleExtensions.ERROR_NULL) where T : class
        {
            builder.Null(builder.GetMember(), errorMessage);
            return builder;
        }

        /// <summary>
        /// Marker Not null with specified error message.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="builder">The builder.</param>
        /// <param name="errorMessage">The error message.</param>
        /// <returns></returns>
        public static MemberRuleMarker<T> NotNull<T>(this MemberRuleMarker<T> builder, string errorMessage = DefaultRuleExtensions.ERROR_NOT_NULL) where T : class
        {
            builder.NotNull(builder.GetMember(), errorMessage);
            return builder;
        }

        /// <summary>
        /// Marker String length.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="builder">The builder.</param>
        /// <param name="max">The maximum.</param>
        /// <returns></returns>
        public static MemberRuleMarker<T> StringLen<T>(this MemberRuleMarker<T> builder, int max)
        {
            builder.StringLen(builder.GetMember(), max);
            return builder;
        }


        /// <summary>
        /// Marker Regular expressions.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="builder">The builder.</param>
        /// <param name="pattern">The pattern.</param>
        /// <returns></returns>
        public static MemberRuleMarker<T> RegularExp<T>(this MemberRuleMarker<T> builder, string pattern)
        {
            builder.RegularExp(builder.GetMember(), nameof(RegularExp), pattern);
            return builder;
        }


        /// <summary>
        /// Marker Required
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="builder">The builder.</param>
        /// <returns></returns>
        public static MemberRuleMarker<T> Required<T>(this MemberRuleMarker<T> builder)
        {
            builder.Required(builder.GetMember());
            return builder;
        }


        /// <summary>
        /// Marker Maximum length.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="builder">The builder.</param>
        /// <param name="length">The length.</param>
        /// <returns></returns>
        public static MemberRuleMarker<T> MaxLen<T>(this MemberRuleMarker<T> builder, int length)
        {
            builder.MaxLen(builder.GetMember(), length);
            return builder;
        }


        /// <summary>
        /// Marker Range with specified minimum.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="builder">The builder.</param>
        /// <param name="min">The minimum.</param>
        /// <param name="max">The maximum.</param>
        /// <returns></returns>
        public static MemberRuleMarker<T> Range<T>(this MemberRuleMarker<T> builder, int min, int max)
        {
            builder.Range(builder.GetMember(), min, max);
            return builder;
        }


        /// <summary>
        /// Marker Range with specified minimum.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="builder">The builder.</param>
        /// <param name="min">The minimum.</param>
        /// <param name="max">The maximum.</param>
        /// <returns></returns>
        public static MemberRuleMarker<T> Range<T>(this MemberRuleMarker<T> builder, double min, double max)
        {
            builder.Range(builder.GetMember(), min, max);
            return builder;
        }


        /// <summary>
        /// Marker Range with specified type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="builder">The builder.</param>
        /// <param name="type">The type.</param>
        /// <param name="min">The minimum.</param>
        /// <param name="max">The maximum.</param>
        /// <returns></returns>
        public static MemberRuleMarker<T> Range<T>(this MemberRuleMarker<T> builder, Type type, string min, string max)
        {
            builder.Range(builder.GetMember(), type, min, max);
            return builder;
        }

        /// <summary>
        /// Marker Email address.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="builder">The builder.</param>
        /// <returns></returns>
        public static MemberRuleMarker<T> EmailAddress<T>(this MemberRuleMarker<T> builder)
        {
            builder.EmailAddress(builder.GetMember());
            return builder;
        }


        /// <summary>
        /// Marker URL.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="builder">The builder.</param>
        /// <returns></returns>
        public static MemberRuleMarker<T> Url<T>(this MemberRuleMarker<T> builder)
        {
            builder.Url(builder.GetMember());
            return builder;
        }


        /// <summary>
        /// Marker Phone number.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="builder">The builder.</param>
        /// <returns></returns>
        public static MemberRuleMarker<T> PhoneNumber<T>(this MemberRuleMarker<T> builder)
        {
            builder.PhoneNumber(builder.GetMember());
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
        public static MemberRuleMarker<T> Branch<T>(this MemberRuleMarker<T> builder, Func<T, bool> condition, Action<MemberRuleMarker<T>> setup)
        {
            Utility.SafeMark<T>(() =>
            {
                if (setup == null)
                    throw new ArgumentNullException(nameof(setup) + " can not be null in " + nameof(Branch));

                var innerBuilder = builder.CreateCopy();

                setup.Invoke(innerBuilder);

                builder.Add(new BranchRule<T>(new OnlyInvalidResultStrategy(innerBuilder), condition, new RuleContext(nameof(Branch), new EmptyMember(condition.ToString(), typeof(T)))));

            }, nameof(Branch));
            return builder;
        }
    }
}
