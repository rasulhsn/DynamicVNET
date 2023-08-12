using System;
using System.Collections.Generic;
using System.Linq;
using DynamicVNET.Lib.Core;

namespace DynamicVNET.Lib
{
    public class Validator : IValidator
    {
        protected readonly ValidatorContext Context;

        /// <summary>
        /// Initializes a new instance of the <see cref="Validator"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <exception cref="ArgumentNullException"></exception>
        internal Validator(ValidatorContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(ValidatorContext));
            }

            this.Context = context;
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
            Applier applier = this.Context.Applier;
            return applier.ApplyAll(this.Context.Rules, instance);
        }
    }

    public sealed class Validator<T> : Validator, IValidator<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Validator{T}"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public Validator(ValidatorContext context) : base(context) { }

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
