using DynamicVNET.Lib.Internal;
using System;
using System.Collections.Generic;

namespace DynamicVNET.Lib.Core
{
    /// <summary>
    /// Context of data state for validators.
    /// </summary>
    public class ValidatorContext
    {
        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<IValidation> Rules { get; }

        /// <summary>
        /// 
        /// </summary>
        public Applier Applier { get; }

        /// <summary>
        /// 
        /// </summary>
        public Type TaggedType { get; }

        /// <param name="applier"></param>
        /// <param name="taggedType"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public ValidatorContext(Applier applier, Type taggedType, IEnumerable<IValidation> rules)
        {
            this.Applier = applier ?? throw new ArgumentNullException(nameof(applier));
            this.TaggedType = taggedType ?? throw new ArgumentNullException(nameof(taggedType));
            this.Rules = rules ?? throw new ArgumentNullException(nameof(rules));
        }
    }
}
