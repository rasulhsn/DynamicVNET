using System;

namespace DynamicVNET.Lib.Exceptions
{
    public class ValidationMarkerException : ApplicationException
    {
        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidationMarkerException"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="message">The message.</param>
        public ValidationMarkerException(string name,string message) : this(name,message,null) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidationMarkerException"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="message">The message.</param>
        /// <param name="inner">The inner.</param>
        public ValidationMarkerException(string name,string message, Exception inner) : base(message, inner)
        {
            this.Name = name;
        }
    }
}
