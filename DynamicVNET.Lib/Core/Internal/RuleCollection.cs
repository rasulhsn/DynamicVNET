using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DynamicVNET.Lib.Internal
{
    internal class RuleCollection : IEnumerable<IValidationRule>, ICollection<IValidationRule>
    {
        private ICollection<IValidationRule> _markers;

        /// <summary>
        /// Initializes a new instance of the <see cref="RuleCollection"/> class.
        /// </summary>
        public RuleCollection()
        {
            _markers = new HashSet<IValidationRule>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RuleCollection"/> class.
        /// </summary>
        /// <param name="markers">The markers.</param>
        public RuleCollection(IEnumerable<IValidationRule> markers)
        {
            _markers = new HashSet<IValidationRule>(markers);
        }

        /// <summary>
        /// Gets the number of elements contained in the <see cref="T:System.Collections.Generic.ICollection`1"></see>.
        /// </summary>
        public int Count => this._markers.Count;

        /// <summary>
        /// Gets a value indicating whether the <see cref="T:System.Collections.Generic.ICollection`1"></see> is read-only.
        /// </summary>
        public bool IsReadOnly => this._markers.IsReadOnly;

        /// <summary>
        /// Adds an item to the <see cref="T:System.Collections.Generic.ICollection`1"></see>.
        /// </summary>
        /// <param name="item">The object to add to the <see cref="T:System.Collections.Generic.ICollection`1"></see>.</param>
        public void Add(IValidationRule item)
        {
            _markers.Add(item);
        }

        /// <summary>
        /// Removes all items from the <see cref="T:System.Collections.Generic.ICollection`1"></see>.
        /// </summary>
        public void Clear()
        {
            this._markers.Clear();
        }

        /// <summary>
        /// Determines whether this instance contains the object.
        /// </summary>
        /// <param name="item">The object to locate in the <see cref="T:System.Collections.Generic.ICollection`1"></see>.</param>
        /// <returns>
        /// true if <paramref name="item">item</paramref> is found in the <see cref="T:System.Collections.Generic.ICollection`1"></see>; otherwise, false.
        /// </returns>
        public bool Contains(IValidationRule item)
        {
            return this._markers.Contains(item);
        }

        /// <summary>
        /// Copies the elements of the <see cref="T:System.Collections.Generic.ICollection`1"></see> to an <see cref="T:System.Array"></see>, starting at a particular <see cref="T:System.Array"></see> index.
        /// </summary>
        /// <param name="array">The one-dimensional <see cref="T:System.Array"></see> that is the destination of the elements copied from <see cref="T:System.Collections.Generic.ICollection`1"></see>. The <see cref="T:System.Array"></see> must have zero-based indexing.</param>
        /// <param name="arrayIndex">The zero-based index in array at which copying begins.</param>
        public void CopyTo(IValidationRule[] array, int arrayIndex)
        {
            this._markers.CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>
        /// An enumerator that can be used to iterate through the collection.
        /// </returns>
        public IEnumerator<IValidationRule> GetEnumerator()
        {
            return new RuleEnumerator(this);
        }


        /// <summary>
        /// Removes the first occurrence of a specific object from the <see cref="T:System.Collections.Generic.ICollection`1"></see>.
        /// </summary>
        /// <param name="item">The object to remove from the <see cref="T:System.Collections.Generic.ICollection`1"></see>.</param>
        /// <returns>
        /// true if <paramref name="item">item</paramref> was successfully removed from the <see cref="T:System.Collections.Generic.ICollection`1"></see>; otherwise, false. This method also returns false if <paramref name="item">item</paramref> is not found in the original <see cref="T:System.Collections.Generic.ICollection`1"></see>.
        /// </returns>
        public bool Remove(IValidationRule item)
        {
            return this._markers.Remove(item);
        }

        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Collections.IEnumerator"></see> object that can be used to iterate through the collection.
        /// </returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return new RuleEnumerator(this);
        }

        struct RuleEnumerator : IEnumerator<IValidationRule>
        {
            private RuleCollection _root;
            private IValidationRule _current;
            private int _currentIndex;
            public IValidationRule Current
            {
                get
                {
                    return _current;
                }
            }

            object IEnumerator.Current
            {
                get
                {
                    return _current;
                }
            }

            internal RuleEnumerator(RuleCollection rootCollection)
            {
                _currentIndex = 0;
                _current = null;
                _root = rootCollection;
            }

            public void Dispose()
            {
                Reset();
            }

            public bool MoveNext()
            {
                if (_currentIndex >= _root.Count)
                    return false;
                else
                {
                    _current = _root._markers.ElementAt(_currentIndex);
                    _currentIndex += 1;
                }
                return true;
            }

            public void Reset()
            {
                _currentIndex = 0;
            }
        }
    }
}
