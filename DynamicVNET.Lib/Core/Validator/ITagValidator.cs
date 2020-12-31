namespace DynamicVNET.Lib
{
    public interface ITagValidator
    {
        /// <summary>
        /// Gets or sets the tag.
        /// </summary>
        /// <value>
        /// The tag.
        /// </value>
        string Tag { get; set; }

        /// <summary>
        /// Gets as.
        /// </summary>
        /// <param name="tag">The tag.</param>
        /// <returns><see cref="IValidator"/></returns>
        IValidator GetAs(string tag);
    }
}
