using System;

namespace DynamicVNET.Lib.Exceptions
{
    public class MarkerInternalException : ApplicationException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MarkerInternalException"/> class.
        /// </summary>
        /// <param name="message">A message that describes the error.</param>
        public MarkerInternalException(string message) : base(message) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="MarkerInternalException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="inner">The inner.</param>
        public MarkerInternalException(string message, System.Exception inner) : base(message, inner) { }
    }
}
