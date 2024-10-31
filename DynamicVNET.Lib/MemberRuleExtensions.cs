using DynamicVNET.Lib.Core;
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
        /// <param name="max">The maximum len.</param>
        /// <param name="min">The minimum len.</param>
        public static IMemberRuleMarker StringLen(this IMemberRuleMarker builder, int max, int? min = null)
        {
            builder.StringLen(builder.Selected, max, min);
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
        /// 
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="minValue"></param>
        /// <param name="errorMessage"></param>
        public static IMemberRuleMarker GreaterThan(this IMemberRuleMarker builder, int minValue , string errorMessage = null)
        {
            errorMessage = errorMessage ?? $"Value of the instance should greather than {minValue}";
            builder.GreaterThan(builder.Selected, minValue, errorMessage);
            return builder;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="minValue"></param>
        /// <param name="errorMessage"></param>
        public static IMemberRuleMarker LessThan(this IMemberRuleMarker builder, int maxValue, string errorMessage = null)
        {
            errorMessage = errorMessage ?? $"Value of the instance should less than {maxValue}";
            builder.LessThan(builder.Selected, maxValue, errorMessage);
            return builder;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="minValue"></param>
        /// <param name="errorMessage"></param>
        public static IMemberRuleMarker GreaterThan(this IMemberRuleMarker builder, double minValue, string errorMessage = null)
        {
            errorMessage = errorMessage ?? $"Value of the instance should greather than {minValue}";
            builder.GreaterThan(builder.Selected, minValue, errorMessage);
            return builder;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="minValue"></param>
        /// <param name="errorMessage"></param>
        public static IMemberRuleMarker LessThan(this IMemberRuleMarker builder, double maxValue, string errorMessage = null)
        {
            errorMessage = errorMessage ?? $"Value of the instance should less than {maxValue}";
            builder.LessThan(builder.Selected, maxValue, errorMessage);
            return builder;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="minValue"></param>
        /// <param name="errorMessage"></param>
        public static IMemberRuleMarker GreaterThan(this IMemberRuleMarker builder, decimal minValue, string errorMessage = null)
        {
            errorMessage = errorMessage ?? $"Value of the instance should greather than {minValue}";
            builder.GreaterThan(builder.Selected, minValue, errorMessage);
            return builder;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="minValue"></param>
        /// <param name="errorMessage"></param>
        public static IMemberRuleMarker LessThan(this IMemberRuleMarker builder, decimal maxValue, string errorMessage = null)
        {
            errorMessage = errorMessage ?? $"Value of the instance should less than {maxValue}";
            builder.LessThan(builder.Selected, maxValue, errorMessage);
            return builder;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="minValue"></param>
        /// <param name="errorMessage"></param>
        public static IMemberRuleMarker GreaterThan(this IMemberRuleMarker builder, float minValue, string errorMessage = null)
        {
            errorMessage = errorMessage ?? $"Value of the instance should greather than {minValue}";
            builder.GreaterThan(builder.Selected, minValue, errorMessage);
            return builder;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="minValue"></param>
        /// <param name="errorMessage"></param>
        public static IMemberRuleMarker LessThan(this IMemberRuleMarker builder, float maxValue, string errorMessage = null)
        {
            errorMessage = errorMessage ?? $"Value of the instance should less than {maxValue}";
            builder.LessThan(builder.Selected, maxValue, errorMessage);
            return builder;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="minValue"></param>
        /// <param name="errorMessage"></param>
        public static IMemberRuleMarker GreaterThan(this IMemberRuleMarker builder, byte minValue, string errorMessage = null)
        {
            errorMessage = errorMessage ?? $"Value of the instance should greather than {minValue}";
            builder.GreaterThan(builder.Selected, minValue, errorMessage);
            return builder;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="minValue"></param>
        /// <param name="errorMessage"></param>
        public static IMemberRuleMarker LessThan(this IMemberRuleMarker builder, byte maxValue, string errorMessage = null)
        {
            errorMessage = errorMessage ?? $"Value of the instance should less than {maxValue}";
            builder.LessThan(builder.Selected, maxValue, errorMessage);
            return builder;
        }
    }
}
