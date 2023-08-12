using System;

namespace DynamicVNET.Lib
{
    public static class MemberRuleExtensions
    {
        /// <summary>
        /// Marker Null with specified error message.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <param name="errorMessage">The error message.</param>
        public static IMemberRuleMarker Null(this IMemberRuleMarker builder, string errorMessage = RuleExtensions.ERROR_NULL)
        {
            builder.Null(builder.Selected, errorMessage);
            return builder;
        }

        /// <summary>
        /// Marker Not null with specified error message.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <param name="errorMessage">The error message.</param>
        public static IMemberRuleMarker NotNull(this IMemberRuleMarker builder, string errorMessage = RuleExtensions.ERROR_NOT_NULL)
        {
            builder.NotNull(builder.Selected, errorMessage);
            return builder;
        }

        /// <summary>
        /// Marker String length.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <param name="max">The maximum.</param>
        public static IMemberRuleMarker StringLen(this IMemberRuleMarker builder, int max)
        {
            builder.StringLen(builder.Selected, max);
            return builder;
        }


        /// <summary>
        /// Marker Regular expressions.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <param name="pattern">The pattern.</param>
        public static IMemberRuleMarker RegularExp(this IMemberRuleMarker builder, string pattern)
        {
            builder.RegularExp(builder.Selected, nameof(RegularExp), pattern);
            return builder;
        }


        /// <summary>
        /// Marker Required
        /// </summary>
        /// <param name="builder">The builder.</param>
        public static IMemberRuleMarker Required(this IMemberRuleMarker builder)
        {
            builder.Required(builder.Selected);
            return builder;
        }


        /// <summary>
        /// Marker Maximum length.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <param name="length">The length.</param>
        public static IMemberRuleMarker MaxLen(this IMemberRuleMarker builder, int length)
        {
            builder.MaxLen(builder.Selected, length);
            return builder;
        }


        /// <summary>
        /// Marker Range with specified minimum.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <param name="min">The minimum.</param>
        /// <param name="max">The maximum.</param>
        public static IMemberRuleMarker Range(this IMemberRuleMarker builder, int min, int max)
        {
            builder.Range(builder.Selected, min, max);
            return builder;
        }


        /// <summary>
        /// Marker Range with specified minimum.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <param name="min">The minimum.</param>
        /// <param name="max">The maximum.</param>
        public static IMemberRuleMarker Range(this IMemberRuleMarker builder, double min, double max)
        {
            builder.Range(builder.Selected, min, max);
            return builder;
        }


        /// <summary>
        /// Marker Range with specified type.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <param name="type">The type.</param>
        /// <param name="min">The minimum.</param>
        /// <param name="max">The maximum.</param>
        public static IMemberRuleMarker Range(this IMemberRuleMarker builder, Type type, string min, string max)
        {
            builder.Range(builder.Selected, type, min, max);
            return builder;
        }

        /// <summary>
        /// Marker Email address.
        /// </summary>
        /// <param name="builder">The builder.</param>
        public static IMemberRuleMarker EmailAddress(this IMemberRuleMarker builder)
        {
            builder.EmailAddress(builder.Selected);
            return builder;
        }


        /// <summary>
        /// Marker URL.
        /// </summary>
        /// <param name="builder">The builder.</param>
        public static IMemberRuleMarker Url(this IMemberRuleMarker builder)
        {
            builder.Url(builder.Selected);
            return builder;
        }


        /// <summary>
        /// Marker Phone number.
        /// </summary>
        /// <param name="builder">The builder.</param>
        public static IMemberRuleMarker PhoneNumber(this IMemberRuleMarker builder)
        {
            builder.PhoneNumber(builder.Selected);
            return builder;

        }
    }
}
