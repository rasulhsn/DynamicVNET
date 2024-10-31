using System;
using System.ComponentModel.DataAnnotations;
using DynamicVNET.Lib.Exceptions;
using DynamicVNET.Lib.Internal;

namespace DynamicVNET.Lib.Core
{
    public static class RuleExtensions
    {
        // For regular expressions.
        public const string URL_PATTERN = @"(mailto\:|(news|(ht|f)tp(s?))\://)(([^[:space:]]+)|([^[:space:]]+)( #([^#]+)#)?)";
        public const string EMAIL_PATTERN = @"^([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$";

        // For errors.
        public const string ERROR_NULL = "Member is not null, validation invalid!";
        public const string ERROR_NOT_NULL = "Member is null, validation invalid!";
        public const string ERROR_CUSTOM = "Custom condition fail, validation invalid!";

        public static IRuleMarker Null(this IRuleMarker builder, IMember member, string errorMessage)
        {
            if (!member.IsNullable)
            {
                throw new ValidationMarkerException(nameof(Null), $"This method can not be apply to {member.Type.ToString()}!");
            }

            var context = new RuleContext(nameof(Null), member);
            builder.Add(new UniquePredicateRule<object>(new PredicateRule<object>(instance =>
            {
                if (member.ResolveValue(instance) == null)
                {
                    return true;
                }

                return false;
            }, errorMessage, context), context));
            return builder;
        }

        public static IRuleMarker NotNull(this IRuleMarker builder, IMember member, string errorMessage)
        {
            if (!member.IsNullable)
            {
                throw new ValidationMarkerException(nameof(NotNull), $"This method can not be apply to {member.Type.ToString()} type!");
            }

            var context = new RuleContext(nameof(NotNull), member);
            builder.Add(new UniquePredicateRule<object>(new PredicateRule<object>(instance =>
            {
                if (member.ResolveValue(instance) != null)
                {
                    return true;
                }

                return false;
            }, errorMessage, context), context));
            return builder;
        }

        public static IRuleMarker StringLen(this IRuleMarker builder, IMember member, int max, int? min = null)
        {
            StringLengthAttribute strLenAnnotation = new StringLengthAttribute(max);

            if (min != null)
            {
                strLenAnnotation.MinimumLength = min.Value;
            }

            builder.Add(new AnnotationRuleAdapter(strLenAnnotation,
                                                            new RuleContext(nameof(StringLen), member)));
            return builder;
        }

        public static IRuleMarker RegularExp(this IRuleMarker builder, IMember member, string operationName ,string pattern)
        {
            builder.Add(new AnnotationRuleAdapter(new RegularExpressionAttribute(pattern),
                                                            new RuleContext(operationName, member)));
            return builder;
        }

        public static IRuleMarker MaxLen(this IRuleMarker builder, IMember member, int length)
        {
            builder.Add(new AnnotationRuleAdapter(new MaxLengthAttribute(length),
                                                          new RuleContext(nameof(MaxLen), member)));
            return builder;
        }

        public static IRuleMarker Required(this IRuleMarker builder, IMember member)
        {
            builder.Add(new AnnotationRuleAdapter(new RequiredAttribute(),
                                                            new RuleContext(nameof(Required), member)));
            return builder;
        }

        public static IRuleMarker Range(this IRuleMarker builder, IMember member, int min, int max)
        {
            builder.Add(new AnnotationRuleAdapter(new RangeAttribute(min, max),
                                                            new RuleContext(nameof(Range), member)));
            return builder;
        }

        public static IRuleMarker Range(this IRuleMarker builder, IMember member, double min, double max)
        {
            builder.Add(new AnnotationRuleAdapter(new RangeAttribute(min, max),
                                                            new RuleContext(nameof(Range), member)));
            return builder;
        }

        public static IRuleMarker Range(this IRuleMarker builder, IMember member, Type type, string min, string max)
        {
            builder.Add(new AnnotationRuleAdapter(new RangeAttribute(type, min, max),
                                                            new RuleContext(nameof(Range), member)));
            return builder;
        }

        public static IRuleMarker EmailAddress(this IRuleMarker builder, IMember member)
        {
            return builder.RegularExp(member, nameof(EmailAddress) ,EMAIL_PATTERN);
        }

        public static IRuleMarker Url(this IRuleMarker builder, IMember member)
        {
            return builder.RegularExp(member, nameof(Url), URL_PATTERN);
        }

        public static IRuleMarker GreaterThan(this IRuleMarker builder, IMember member, int minValue, string errorMessage)
        {
            if (member.TypeDefinedAs != Defination.Int)
            {
                throw new ValidationMarkerException(nameof(GreaterThan), $"This method can not be apply to {member.Type.ToString()}!");
            }

            RuleContext context = new RuleContext(nameof(GreaterThan), member);

            builder.Add(new UniquePredicateRule<object>(new PredicateRule<object>(instance =>
            {
                int valueOfValidationInstance = int.Parse(member.ResolveValue(instance).ToString());
                
                if (valueOfValidationInstance > minValue)
                {
                    return true;
                }

                return false;
            }, errorMessage, context), context));
            return builder;
        }

        public static IRuleMarker LessThan(this IRuleMarker builder, IMember member, int maxValue, string errorMessage)
        {
            if (member.TypeDefinedAs != Defination.Int)
            {
                throw new ValidationMarkerException(nameof(LessThan), $"This method can not be apply to {member.Type.ToString()}!");
            }

            RuleContext context = new RuleContext(nameof(LessThan), member);

            builder.Add(new UniquePredicateRule<object>(new PredicateRule<object>(instance =>
            {
                int valueOfValidationInstance = int.Parse(member.ResolveValue(instance).ToString());

                if (valueOfValidationInstance < maxValue)
                {
                    return true;
                }

                return false;
            }, errorMessage, context), context));
            return builder;
        }

        public static IRuleMarker GreaterThan(this IRuleMarker builder, IMember member, double minValue, string errorMessage)
        {
            if (member.TypeDefinedAs != Defination.Double)
            {
                throw new ValidationMarkerException(nameof(GreaterThan), $"This method can not be apply to {member.Type.ToString()}!");
            }

            RuleContext context = new RuleContext(nameof(GreaterThan), member);

            builder.Add(new UniquePredicateRule<object>(new PredicateRule<object>(instance =>
            {
                double valueOfValidationInstance = double.Parse(member.ResolveValue(instance).ToString());

                if (valueOfValidationInstance > minValue)
                {
                    return true;
                }

                return false;
            }, errorMessage, context), context));
            return builder;
        }

        public static IRuleMarker LessThan(this IRuleMarker builder, IMember member, double maxValue, string errorMessage)
        {
            if (member.TypeDefinedAs != Defination.Double)
            {
                throw new ValidationMarkerException(nameof(LessThan), $"This method can not be apply to {member.Type.ToString()}!");
            }

            RuleContext context = new RuleContext(nameof(LessThan), member);

            builder.Add(new UniquePredicateRule<object>(new PredicateRule<object>(instance =>
            {
                double valueOfValidationInstance = double.Parse(member.ResolveValue(instance).ToString());

                if (valueOfValidationInstance < maxValue)
                {
                    return true;
                }

                return false;
            }, errorMessage, context), context));
            return builder;
        }

        public static IRuleMarker GreaterThan(this IRuleMarker builder, IMember member, decimal minValue, string errorMessage)
        {
            if (member.TypeDefinedAs != Defination.Decimal)
            {
                throw new ValidationMarkerException(nameof(GreaterThan), $"This method can not be apply to {member.Type.ToString()}!");
            }

            RuleContext context = new RuleContext(nameof(GreaterThan), member);

            builder.Add(new UniquePredicateRule<object>(new PredicateRule<object>(instance =>
            {
                decimal valueOfValidationInstance = decimal.Parse(member.ResolveValue(instance).ToString());

                if (valueOfValidationInstance > minValue)
                {
                    return true;
                }

                return false;
            }, errorMessage, context), context));
            return builder;
        }

        public static IRuleMarker LessThan(this IRuleMarker builder, IMember member, decimal maxValue, string errorMessage)
        {
            if (member.TypeDefinedAs != Defination.Decimal)
            {
                throw new ValidationMarkerException(nameof(LessThan), $"This method can not be apply to {member.Type.ToString()}!");
            }

            RuleContext context = new RuleContext(nameof(LessThan), member);

            builder.Add(new UniquePredicateRule<object>(new PredicateRule<object>(instance =>
            {
                decimal valueOfValidationInstance = decimal.Parse(member.ResolveValue(instance).ToString());

                if (valueOfValidationInstance < maxValue)
                {
                    return true;
                }

                return false;
            }, errorMessage, context), context));
            return builder;
        }

        public static IRuleMarker GreaterThan(this IRuleMarker builder, IMember member, float minValue, string errorMessage)
        {
            if (member.TypeDefinedAs != Defination.Float)
            {
                throw new ValidationMarkerException(nameof(GreaterThan), $"This method can not be apply to {member.Type.ToString()}!");
            }

            RuleContext context = new RuleContext(nameof(GreaterThan), member);

            builder.Add(new UniquePredicateRule<object>(new PredicateRule<object>(instance =>
            {
                float valueOfValidationInstance = float.Parse(member.ResolveValue(instance).ToString());

                if (valueOfValidationInstance > minValue)
                {
                    return true;
                }

                return false;
            }, errorMessage, context), context));
            return builder;
        }

        public static IRuleMarker LessThan(this IRuleMarker builder, IMember member, float maxValue, string errorMessage)
        {
            if (member.TypeDefinedAs != Defination.Float)
            {
                throw new ValidationMarkerException(nameof(LessThan), $"This method can not be apply to {member.Type.ToString()}!");
            }

            RuleContext context = new RuleContext(nameof(LessThan), member);

            builder.Add(new UniquePredicateRule<object>(new PredicateRule<object>(instance =>
            {
                float valueOfValidationInstance = float.Parse(member.ResolveValue(instance).ToString());

                if (valueOfValidationInstance < maxValue)
                {
                    return true;
                }

                return false;
            }, errorMessage, context), context));
            return builder;
        }

        public static IRuleMarker GreaterThan(this IRuleMarker builder, IMember member, byte minValue, string errorMessage)
        {
            if (member.TypeDefinedAs != Defination.Byte)
            {
                throw new ValidationMarkerException(nameof(GreaterThan), $"This method can not be apply to {member.Type.ToString()}!");
            }

            RuleContext context = new RuleContext(nameof(GreaterThan), member);

            builder.Add(new UniquePredicateRule<object>(new PredicateRule<object>(instance =>
            {
                byte valueOfValidationInstance = byte.Parse(member.ResolveValue(instance).ToString());

                if (valueOfValidationInstance > minValue)
                {
                    return true;
                }

                return false;
            }, errorMessage, context), context));
            return builder;
        }

        public static IRuleMarker LessThan(this IRuleMarker builder, IMember member, byte maxValue, string errorMessage)
        {
            if (member.TypeDefinedAs != Defination.Byte)
            {
                throw new ValidationMarkerException(nameof(LessThan), $"This method can not be apply to {member.Type.ToString()}!");
            }

            RuleContext context = new RuleContext(nameof(LessThan), member);

            builder.Add(new UniquePredicateRule<object>(new PredicateRule<object>(instance =>
            {
                byte valueOfValidationInstance = byte.Parse(member.ResolveValue(instance).ToString());

                if (valueOfValidationInstance < maxValue)
                {
                    return true;
                }

                return false;
            }, errorMessage, context), context));
            return builder;
        }
    }
}
