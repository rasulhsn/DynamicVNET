using System;
using System.Collections.Generic;

namespace DynamicVNET.Lib
{
    public abstract class BaseValidator<T> : IValidator<T>
    {
        private readonly IValidator<T> _validator;

        public Type ValidateType => typeof(T);

        /// <summary>
        /// Allows you to abort a validation, if at least one validation fails.
        /// </summary>
        public virtual bool FailFirst { get; } = false;

        protected BaseValidator()
        {
            _validator = ValidatorFactory.Create<T>(Configure, FailFirst);
        }

        /// <inheritdoc/>
        public bool IsValid(T instance)
        {
            return _validator.IsValid(instance);
        }

        /// <inheritdoc/>
        public bool IsValid(object instance)
        {
            return _validator.IsValid(instance);
        }

        /// <inheritdoc/>
        public IEnumerable<ValidationRuleResult> Validate(T instance)
        {
            return _validator.Validate(instance);
        }

        /// <inheritdoc/>
        public IEnumerable<ValidationRuleResult> Validate(object instance)
        {
            return _validator.Validate(instance);
        }

        /// <summary>
        /// 
        /// </summary>
        protected abstract void Configure(ITypeRuleMarker<T> builder);
    }
}
