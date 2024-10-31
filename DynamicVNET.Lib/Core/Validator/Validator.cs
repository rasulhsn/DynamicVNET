using System;
using System.Collections.Generic;
using System.Linq;
using DynamicVNET.Lib.Core;
using DynamicVNET.Lib.Internal;

namespace DynamicVNET.Lib
{
    public class Validator : IValidator
    {
        private readonly IEnumerable<IValidation> _validationRules;

        protected readonly ValidatorContext Context;

        /// <summary>
        /// Initializes a new instance of the <see cref="Validator"/> class.
        /// </summary>
        /// <exception cref="ArgumentNullException"></exception>
        internal Validator(IEnumerable<IValidation> validationRules, ValidatorContext context)
        {
            this._validationRules = validationRules ?? throw new ArgumentNullException(nameof(validationRules));
            this.Context = context ?? throw new ArgumentNullException(nameof(ValidatorContext));
        }

        /// <inheritdoc/>
        public bool IsValid(object instance)
        {
            if (!instance.GetType().Equals(Context.TaggedType))
            {
                throw new ArgumentException("Instance type is invalid. Or defined type is not compatible with tagged one!");
            }

            bool? isAny = Validate(instance)?
                    .Any(x => !x.IsValid);

            return isAny.HasValue && isAny.Value ? false : true;
        }

        /// <inheritdoc/>
        public IEnumerable<ValidationRuleResult> Validate(object instance)
        {
            return this.Context.Applier.Apply(_validationRules, instance);
        }
    }

    public sealed class Validator<T> : Validator, IValidator<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Validator{T}"/> class.
        /// </summary>
        public Validator(IEnumerable<IValidation> validationRules,
                                            ValidatorContext context) : base(validationRules, context) { }

        /// <inheritdoc/>
        public bool IsValid(T instance)
        {
            return IsValid((object)instance);
        }

        /// <inheritdoc/>
        public IEnumerable<ValidationRuleResult> Validate(T instance)
        {
            return Validate((object)instance);
        }
    }
}
