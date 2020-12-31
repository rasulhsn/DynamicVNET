using System;
using DynamicVNET.Lib.Internal;

namespace DynamicVNET.Lib
{
    /// <summary>
    /// Decrease dependency and resolving complexity
    /// </summary>
    public class ValidatorContext
    {
        private IBuilderStrategy _strategy;

        /// <summary>
        /// Gets the type of the tagged.
        /// </summary>
        /// <value>
        /// The type of the tagged.
        /// </value>
        public Type TaggedType { get; }

        /// <summary>
        /// Gets the marker.
        /// </summary>
        /// <value>
        /// The marker.
        /// </value>
        public BaseRuleMarker Marker { get; }

        /// <summary>
        /// Gets or sets the strategy.
        /// </summary>
        /// <value>
        /// The strategy.
        /// </value>
        public IBuilderStrategy Strategy
        {
            get
            {
                if(_strategy == null)
                {
                    _strategy = new OnlyInvalidResultStrategy(this.Marker);
                }

                return _strategy;
            }
            internal set
            {
                _strategy = value;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidatorContext"/> class.
        /// </summary>
        /// <param name="marker">The marker.</param>
        /// <param name="taggedType">Type of the tagged.</param>
        /// <exception cref="ArgumentNullException">
        /// marker
        /// or
        /// taggedType
        /// </exception>
        public ValidatorContext(BaseRuleMarker marker, Type taggedType)
        {
            Marker = marker ?? throw new ArgumentNullException(nameof(marker));
            TaggedType = taggedType ?? throw new ArgumentNullException(nameof(taggedType));
        }
    }
}
