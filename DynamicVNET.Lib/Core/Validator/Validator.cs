using DynamicVNET.Lib.Internal;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DynamicVNET.Lib
{
    /// <summary>
    /// Default validator for validate declared type
    /// </summary>
    public class Validator : IValidator
    {
        protected readonly ValidatorContext Context;

        /// <summary>
        /// Initializes a new instance of the <see cref="Validator"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <exception cref="ArgumentNullException">IBuildStrategy</exception>
        public Validator(ValidatorContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(ValidatorContext));

            Context = context;
        }

        /// <summary>
        /// That can be true or false, if any state invalid this method returns false
        /// </summary>
        /// <param name="instance">That is declared type instance</param>
        public bool IsValid(object instance)
        {
            if (!instance.GetType().Equals(Context.TaggedType))
                throw new ArgumentException("Instance type invalid by defined type!");

            bool? isAny = Validate(instance)?
                .Any(x => !x.IsValid);

            return isAny.HasValue && isAny.Value ? false : true;
        }

        /// <summary>
        /// Circulate on all markers
        /// </summary>
        /// <param name="instance">That is declared type instance</param>
        /// <returns>Returns all state related validations</returns>
        public IEnumerable<ValidationRuleResult> Validate(object instance)
        {
            return Context.Strategy.Build(instance);
        }
    }

    /// <summary>
    /// Default validator for validate declared type
    /// </summary>
    /// <typeparam name="T">Type which uses in validation</typeparam>
    public sealed class Validator<T> : Validator, IValidator<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Validator{T}"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public Validator(ValidatorContext context) : base(context) { }

        /// <summary>
        /// That can be true or false, if any state invalid this method returns false
        /// </summary>
        /// <param name="instance">That is declared type instance</param>
        public bool IsValid(T instance)
        {
            return IsValid((object)instance);
        }

        /// <summary>
        /// Circulate on all markers
        /// </summary>
        /// <param name="instance">That is declared type instance</param>
        /// <returns>Returns all state related validations</returns>
        public IEnumerable<ValidationRuleResult> Validate(T instance)
        {
            return Validate((object)instance);
        }
    }
}
