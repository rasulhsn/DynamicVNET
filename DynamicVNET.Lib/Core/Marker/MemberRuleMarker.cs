using DynamicVNET.Lib.Internal;
using System;

namespace DynamicVNET.Lib
{
    public class MemberRuleMarker<T> : BaseRuleMarker
    {
        /// <summary>
        /// Gets or sets the selected.
        /// </summary>
        /// <value>
        /// The selected.
        /// </value>
        internal IMember Selected
        {
            get;
            set;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MemberRuleMarker{T}"/> class.
        /// </summary>
        /// <param name="selected">The selected.</param>
        /// <param name="chainMarker">The chain marker.</param>
        public MemberRuleMarker(IMember selected, BaseRuleMarker chainMarker)
        {
            this.Selected = selected;
            base.Copy(chainMarker);
        }

        private MemberRuleMarker(IMember selected)
        {
            this.Selected = selected;
        }

        /// <summary>
        /// Gets the member.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NullReferenceException">Selected</exception>
        public IMember GetMember()
        {
            return this.Selected == null ?
                   throw new NullReferenceException(nameof(this.Selected)) : this.Selected;
        }

        /// <summary>
        /// Creates new copy for <see cref="MemberRuleMarker{T}"/>.
        /// </summary>
        /// <returns><see cref="MemberRuleMarker{T}"/></returns>
        public MemberRuleMarker<T> CreateCopy()
        {
            return new MemberRuleMarker<T>(this.Selected);
        }
    }
}
