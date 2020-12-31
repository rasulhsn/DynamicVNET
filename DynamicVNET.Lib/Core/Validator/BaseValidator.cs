using System;
using System.Collections.Generic;
using DynamicVNET.Lib.Internal;

namespace DynamicVNET.Lib
{
    public abstract class BaseValidator<T> : IValidator<T>
    {
        private IValidator<T> _validator;

        protected void Setup(Action<ValidatorBuilder<T>> builderAction)
        {
            _validator = ValidatorFacade.Create(builderAction);
        }

        public bool IsValid(T instance)
        {
            return _validator.IsValid(instance);
        }

        public bool IsValid(object instance)
        {
            return _validator.IsValid(instance);
        }

        public IEnumerable<ValidationRuleResult> Validate(T instance)
        {
            return _validator.Validate(instance);
        }

        public IEnumerable<ValidationRuleResult> Validate(object instance)
        {
            return _validator.Validate(instance);
        }
    }
}
