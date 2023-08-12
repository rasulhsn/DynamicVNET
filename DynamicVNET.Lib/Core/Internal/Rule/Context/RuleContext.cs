using System;

namespace DynamicVNET.Lib.Internal
{
    /// <summary>
    ///
    /// </summary>
    public class RuleContext
    {
        /// <summary>
        /// Gets the name of the operation.
        /// </summary>
        /// <value>
        /// The name of the operation.
        /// </value>
        public string OperationName { get; }

        /// <summary>
        /// Gets the member.
        /// </summary>
        /// <value>
        /// The member.
        /// </value>
        public IMember Member { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="RuleContext"/> class.
        /// </summary>
        /// <param name="operationName">Name of the operation.</param>
        /// <param name="member">The member.</param>
        /// <exception cref="ArgumentNullException">operationName</exception>
        public RuleContext(string operationName, IMember member)
        {
            if (string.IsNullOrEmpty(operationName))
            {
                throw new ArgumentNullException(nameof(operationName));
            }

            this.OperationName = operationName;
            this.Member = member;
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return $"{OperationName}{this.Member?.Name}".GetHashCode();
        }

        /// <summary>
        /// Creates the copy.
        /// </summary>
        /// <param name="operationName">Name of the operation.</param>
        public RuleContext CreateCopy(string operationName)
        {
            return new RuleContext(operationName, this.Member);
        }
    }
}
