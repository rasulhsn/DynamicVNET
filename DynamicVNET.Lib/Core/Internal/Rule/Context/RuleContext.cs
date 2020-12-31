using System;

namespace DynamicVNET.Lib.Internal
{
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
        /// Gets a value indicating whether this instance has resulted.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance has resulted; otherwise, <c>false</c>.
        /// </value>
        public bool HasResulted => RuleResult == null ? false : true;

        /// <summary>
        /// Gets the rule result.
        /// </summary>
        /// <value>
        /// The rule result.
        /// </value>
        public ValidationRuleResult RuleResult { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="RuleContext"/> class.
        /// </summary>
        /// <param name="operationName">Name of the operation.</param>
        /// <param name="member">The member.</param>
        /// <exception cref="ArgumentNullException">operationName</exception>
        public RuleContext(string operationName, IMember member)
        {
            if (string.IsNullOrEmpty(operationName))
                throw new ArgumentNullException(nameof(operationName));

            this.OperationName = operationName;
            this.Member = member;
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        public override int GetHashCode()
        {
            return $"{OperationName}{this.Member?.EndPointName}".GetHashCode();
        }

        /// <summary>
        /// Sets the result.
        /// </summary>
        /// <param name="result">The result.</param>
        public void SetResult(ValidationRuleResult result)
        {
            this.RuleResult = result;
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
