using System;
using System.ComponentModel.DataAnnotations;
using DynamicVNET.Lib.Exceptions;
using DynamicVNET.Lib.Internal;

namespace DynamicVNET.Lib
{
    public static class DefaultRuleExtensions
    {
        // For regular expressions.
        public const string URL_PATTERN = @"(mailto\:|(news|(ht|f)tp(s?))\://)(([^[:space:]]+)|([^[:space:]]+)( #([^#]+)#)?)";
        public const string PHONE_PATTERN = @"^[+]*[(]{0,1}[0-9]{1,4}[)]{0,1}[-\s\./0-9]*$";
        public const string EMAIL_PATTERN = @"^([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$";

        // For errors.
        public const string ERROR_NULL = "Member is not null, validation invalid!";
        public const string ERROR_NOT_NULL = "Member is null, validation invalid!";
        public const string ERROR_CUSTOM = "Custom condition fail, validation invalid!";

        public static BaseRuleMarker Null(this BaseRuleMarker builder, IMember member, string errorMessage)
        {
            if (!member.IsNullable)
                throw new ValidationMarkerException(nameof(Null), $"This method can not be apply to {member.Type.ToString()} type!");

            var context = new RuleContext(nameof(Null), member);
            builder.Add(new UniquePredicateRule<object>(new PredicateRule<object>(instance =>
            {
                if (member.ResolveValue(instance) == null)
                    return true;
                else
                    return false;
            }, errorMessage, context), context));
            return builder;
        }

        public static BaseRuleMarker NotNull(this BaseRuleMarker builder, IMember member, string errorMessage)
        {
            var context = new RuleContext(nameof(NotNull), member);
            builder.Add(new UniquePredicateRule<object>(new PredicateRule<object>(instance =>
            {
                if (member.ResolveValue(instance) != null)
                    return true;
                else
                    return false;
            }, errorMessage, context), context));
            return builder;
        }

        public static BaseRuleMarker StringLen(this BaseRuleMarker builder, IMember member, int max)
        {
            builder.Add(new DataAnnotationRuleAdapter(new StringLengthAttribute(max),
                                                            new RuleContext(nameof(StringLen), member)));
            return builder;
        }

        public static BaseRuleMarker RegularExp(this BaseRuleMarker builder, IMember member, string operationName ,string pattern)
        {
            builder.Add(new DataAnnotationRuleAdapter(new RegularExpressionAttribute(pattern),
                                                            new RuleContext(operationName, member)));
            return builder;
        }

        public static BaseRuleMarker MaxLen(this BaseRuleMarker builder, IMember member, int length)
        {
            builder.Add(new DataAnnotationRuleAdapter(new MaxLengthAttribute(length),
                                                          new RuleContext(nameof(MaxLen), member)));
            return builder;
        }

        public static BaseRuleMarker Required(this BaseRuleMarker builder, IMember member)
        {
            builder.Add(new DataAnnotationRuleAdapter(new RequiredAttribute(),
                                                            new RuleContext(nameof(Required), member)));
            return builder;
        }

        public static BaseRuleMarker Range(this BaseRuleMarker builder, IMember member, int min, int max)
        {
            builder.Add(new DataAnnotationRuleAdapter(new RangeAttribute(min, max),
                                                            new RuleContext(nameof(Range), member)));
            return builder;
        }

        public static BaseRuleMarker Range(this BaseRuleMarker builder, IMember member, double min, double max)
        {
            builder.Add(new DataAnnotationRuleAdapter(new RangeAttribute(min, max),
                                                            new RuleContext(nameof(Range), member)));
            return builder;
        }

        public static BaseRuleMarker Range(this BaseRuleMarker builder, IMember member, Type type, string min, string max)
        {
            builder.Add(new DataAnnotationRuleAdapter(new RangeAttribute(type, min, max),
                                                            new RuleContext(nameof(Range), member)));
            return builder;
        }

        public static BaseRuleMarker EmailAddress(this BaseRuleMarker builder, IMember member)
        {
            return builder.RegularExp(member, nameof(EmailAddress) ,EMAIL_PATTERN);
        }

        public static BaseRuleMarker PhoneNumber(this BaseRuleMarker builder, IMember member)
        {
            return builder.RegularExp(member, nameof(PhoneNumber), PHONE_PATTERN);
        }

        public static BaseRuleMarker Url(this BaseRuleMarker builder, IMember member)
        {
            return builder.RegularExp(member, nameof(Url), URL_PATTERN);
        }
    }
}
