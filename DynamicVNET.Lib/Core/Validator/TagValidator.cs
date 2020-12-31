using System;
using System.Collections.Generic;

namespace DynamicVNET.Lib
{
    public sealed class TagValidator : ITagValidator
    {
        private readonly IReadOnlyDictionary<string, ValidatorContext> _tags;

        /// <summary>
        /// Gets or sets the tag.
        /// </summary>
        /// <value>
        /// The tag.
        /// </value>
        public string Tag { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TagValidator"/> class.
        /// </summary>
        /// <param name="tags">The tags.</param>
        /// <exception cref="ArgumentNullException">tags</exception>
        public TagValidator(IReadOnlyDictionary<string, ValidatorContext> tags)
        {
            _tags = tags ?? throw new ArgumentNullException(nameof(tags));
        }

        /// <summary>
        /// Get as specified tag.
        /// </summary>
        /// <param name="tag">The tag name.</param>
        /// <returns>
        ///   <see cref="IValidator" />
        /// </returns>
        /// <exception cref="Exception">Tag context can't reached, invalid or undefined!</exception>
        public IValidator GetAs(string tag)
        {
            this.Tag = tag;

            ValidatorContext context;

            if ((context = this.GetContext()) == null)
                throw new Exception("Tag context can't reached, invalid or undefined!");

            // Lazy loading with encapsulation repeat searching
            return new Validator(context);
        }

        private ValidatorContext GetContext()
        {
            if (this._tags.TryGetValue(this.Tag, out ValidatorContext value))
            {
                return value;
            }

            return null;
        }
    }
}
