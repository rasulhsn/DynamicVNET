using System;
using System.ComponentModel.DataAnnotations;
using DynamicVNET.Lib.Exceptions;

namespace DynamicVNET.Lib.Internal
{
    /// <seealso cref="DynamicVNET.Lib.Internal.BaseRule" />
    public class DataAnnotationRuleAdapter : BaseRule
    {
        private readonly ValidationAttribute _attribute;

        /// <summary>
        /// Initializes a new instance of the <see cref="DataAnnotationRuleAdapter"/> class.
        /// </summary>
        /// <param name="validation">The validation.</param>
        /// <param name="context">The context.</param>
        /// <exception cref="ArgumentNullException">
        /// OperationName
        /// or
        /// Member
        /// or
        /// ValidationAttribute
        /// </exception>
        public DataAnnotationRuleAdapter(ValidationAttribute validation, RuleContext context) : base(context)
        {
            if (string.IsNullOrEmpty(context.OperationName))
                throw new ArgumentNullException(nameof(context.OperationName));
            if (context.Member == null)
                throw new ArgumentNullException(nameof(context.Member));

            this._attribute = validation ?? throw new ArgumentNullException(nameof(ValidationAttribute));
        }

        /// <summary>
        /// </summary>
        /// <param name="instance"></param>
        /// <exception cref="ValidationMarkerException">
        /// Occurred exception in marker (instance is null). Please check detail error information [InnerErorr]!
        /// or
        /// Occurred exception in [{nameof(DataAnnotationRuleAdapter)}]. Please check detail error information [InnerErorr]!
        /// </exception>
        public override void Apply(object instance)
        {
            try
            {
                ValidationResult result = _attribute.GetValidationResult(Context.Member.ResolveValue(instance), new ValidationContext(instance));
                if (result != null)
                    Context.SetResult(result.ErrorMessage);
                else
                    Context.SetResult();
            }
            catch (ArgumentNullException ex)
            {
                throw new ValidationMarkerException(Context.OperationName,"Occurred exception in marker (instance is null). Please check detail error information [InnerErorr]!", ex);
            }
            catch(Exception ex)
            {
                throw new ValidationMarkerException(Context.OperationName, $"Occurred exception in [{nameof(DataAnnotationRuleAdapter)}]. Please check detail error information [InnerErorr]!", ex);
            }
        }
    }
}
