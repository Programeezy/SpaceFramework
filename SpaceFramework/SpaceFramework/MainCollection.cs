using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceFramework
{
    public class MainCollection<T> : IEnumerable<T>
    {
        private T[] _Collection = new T[0];
        public int Count { get; set; }

        public MainCollection()
        { }

        public MainCollection(params T[] collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException(nameof(collection));
            }
            Array.Resize(ref _Collection, collection.Length);
            _Collection = collection;
            Count = _Collection.Length;
        }

        public bool Contains(object item)
        {
            foreach (object _item in this)
            {
                if (_item == item)
                {
                    return true;
                }
            }

            return false;
        }

        public void Add(T item)
        {
            if(_Collection.Length - this.Count == 1)
                Array.Resize(ref _Collection, _Collection.Length + 16);

            _Collection[this.Count] = item;
            Count++;
        }

        public bool Remove(T item)
        {
            for(int i = 0; i < Count; i++)
            { 
                if(item.Equals(_Collection[i]))
                {
                    for (int j = i; j < Count; j++)
                        _Collection[j] = _Collection[j + 1];

                    return true;
                }
            }

            return false;
        }
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.Count - 1; i++)
                yield return _Collection[i];
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
