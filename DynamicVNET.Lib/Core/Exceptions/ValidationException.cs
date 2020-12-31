using System;

namespace DynamicVNET.Lib.Exceptions
{
    public class ValidationException : ApplicationException
    {
        /// <summary>
        /// Gets the name of the validation.
        /// </summary>
        /// <value>
        /// The name of the validation.
        /// </value>
        public string ValidationName { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidationException"/> class.
        /// </summary>
        /// <param name="validationName">Name of the validation.</param>
        public ValidationException(string validationName) : this(validationName,null) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidationException"/> class.
        /// </summary>
        /// <param name="validationName">Name of the validation.</param>
        /// <param name="message">The message.</param>
        public ValidationException(string validationName,string message) : this(validationName,message,null) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidationException"/> class.
        /// </summary>
        /// <param name="validationName">Name of the validation.</param>
        /// <param name="message">The message.</param>
        /// <param name="inner">The inner.</param>
        public ValidationException(string validationName,string message, System.Exception inner) : base(message, inner)
        {
            this.ValidationName = ValidationName;
        }
    }
}
