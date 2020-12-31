using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using DynamicVNET.Lib.Internal;

namespace DynamicVNET.Lib
{
    public class TagValidatorBuilder
    {
        private readonly IDictionary<string, ValidatorContext> _tags;

        /// <summary>
        /// Initializes a new instance of the <see cref="TagValidatorBuilder"/> class.
        /// </summary>
        public TagValidatorBuilder()
        {
            _tags = new Dictionary<string, ValidatorContext>();
        }

        /// <summary>
        /// Mark as specified tag.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tag">The tag.</param>
        /// <param name="setupAction">The setup action.</param>
        /// <returns></returns>
        public TagValidatorBuilderStrategy MarkAs<T>(string tag, Action<RuleMarker<T>> setupAction)
        {
            RuleMarker<T> marker = new RuleMarker<T>();
            setupAction(marker);

            var newTagContext = new ValidatorContext(marker, typeof(T));
            _tags.Add(tag, newTagContext);

            return new TagValidatorBuilderStrategy(newTagContext);
        }

        /// <summary>
        /// Implementation helps to state pattern
        /// </summary>
        public class TagValidatorBuilderStrategy
        {
            private readonly ValidatorContext _context;

            /// <summary>
            /// Initializes a new instance of the <see cref="TagValidatorBuilderStrategy"/> class.
            /// </summary>
            /// <param name="context">The context.</param>
            internal TagValidatorBuilderStrategy(ValidatorContext context)
            {
                _context = context;
            }

            /// <summary>
            /// Set the strategy.
            /// </summary>
            /// <param name="strategy">The filter strategy.</param>
            public TagValidatorBuilderStrategy SetStrategy(IBuilderStrategy strategy)
            {
                _context.Strategy = strategy;
                return this;
            }

            /// <summary>
            /// Sets the strategy.
            /// </summary>
            /// <param name="strategy">The strategy.</param>
            public TagValidatorBuilderStrategy SetStrategy(WrapperStrategy.Wrapper strategy)
            {
                SetStrategy(new WrapperStrategy(strategy, _context.Marker));
                return this;
            }
        }

        /// <summary>
        /// Build <see cref="ITagValidator" />.
        /// </summary>
        /// <exception cref="Exception"></exception>
        public ITagValidator Build()
        {
            if (this._tags.Count == 0)
                throw new Exception($"{nameof(ITagValidator)} can't build with empty markers!");


            return new TagValidator(new ReadOnlyDictionary<string, ValidatorContext>(this._tags));
        }
    }
}
