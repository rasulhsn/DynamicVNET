﻿using System;
using DynamicVNET.Lib.Core;

namespace DynamicVNET.Lib
{
    public static class ValidatorFactory
    {
        /// <summary>
        /// This method helps to create/initiate a validator instance for a specific type of validation.
        /// </summary>
        /// <typeparam name="T">Type of validation</typeparam>
        /// <exception cref="ArgumentNullException">In case of setup argument is empty!</exception>
        public static IValidator<T> Create<T>(MarkerSetup<T> setup, bool failFirst = false)
        {
            if (setup == null)
            {
                throw new ArgumentNullException(nameof(setup));
            }

            var defaultMarker = new RuleMarker<T>();
            setup(defaultMarker);

            var applier = failFirst ? new FailFirstApplier() : new DefaultApplier();

            var validatorContext = new ValidatorContext(applier, typeof(T), defaultMarker.Rules);

            return new Validator<T>(validatorContext);
        }       
    }
}
