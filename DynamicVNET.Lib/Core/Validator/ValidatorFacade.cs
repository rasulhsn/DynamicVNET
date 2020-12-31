using System;

namespace DynamicVNET.Lib
{
    public static class ValidatorFacade
    {
        /// <summary>
        /// Create the specified builder action.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="builderAction">The builder action.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">builderAction</exception>
        public static IValidator<T> Create<T>(Action<ValidatorBuilder<T>> builderAction)
        {
            if (builderAction == null)
                throw new ArgumentNullException(nameof(builderAction));

            var builder = new ValidatorBuilder<T>();
            builderAction(builder);
            return builder.Build();
        }

        /// <summary>
        /// Create the specified builder action.
        /// </summary>
        /// <param name="builderAction">The builder action.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">builderAction</exception>
        public static ITagValidator Create(Action<TagValidatorBuilder> builderAction)
        {
            if (builderAction == null)
                throw new ArgumentNullException(nameof(builderAction));

            var builder = new TagValidatorBuilder();
            builderAction(builder);
            return builder.Build();
        }
    }
}
