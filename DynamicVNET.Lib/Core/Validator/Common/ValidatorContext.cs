using System;

namespace DynamicVNET.Lib.Core
{
    /// <summary>
    /// Context of validator for encapsulation related objects.
    /// </summary>
    public class ValidatorContext
    {
        /// <summary>
        /// 
        /// </summary>
        public Applier Applier { get; }

        /// <summary>
        /// 
        /// </summary>
        public Type TaggedType { get; }

        /// <summary>
        /// Constructor of ValidatorContext class.
        /// </summary>
        /// <exception cref="ArgumentNullException"></exception>
        public ValidatorContext(Applier applier, Type taggedType)
        {
            this.Applier = applier ?? throw new ArgumentNullException(nameof(applier));
            this.TaggedType = taggedType ?? throw new ArgumentNullException(nameof(taggedType));
        }
    }
}
