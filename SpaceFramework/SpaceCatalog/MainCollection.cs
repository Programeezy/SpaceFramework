using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceCatalog
{
    public class MainCollection<T> : IEnumerable<T>, INotifyCollectionChanged
    {
        private T[] _Collection = new T[0];

        public event NotifyCollectionChangedEventHandler CollectionChanged;

        public int Count { get; set; }

        public T this[int index]
        {
            get { return _Collection[index]; }
        }
        public MainCollection()
        {
        }

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

        public MainCollection(T item)
        {
            Add(item);
        }

        public bool Contains(T item)
        {
            foreach (var _item in this)
            {
                if (_item.Equals(item))
                {
                    return true;
                }
            }

            return false;
        }

        public void Add(T item)
        {
            if (_Collection.Length - this.Count == 1 || _Collection.Length == 0)
                Array.Resize(ref _Collection, _Collection.Length + 16);

            _Collection[Count] = item;
            Count++;
            OnCollectionChanged();
        }

        public bool Remove(T item)
        {
            for(int i = 0; i < Count; i++)
            { 
                if(item.Equals(_Collection[i]))
                {
                    for (int j = i; j <= Count; j++)
                        _Collection[j] = _Collection[j + 1];
                    _Collection[Count] = default(T);
                    Count--;
                    OnCollectionChanged();
                    return true;
                }
            }

            
            return false;
        }
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
                yield return _Collection[i];
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        
        public void OnCollectionChanged()
        {
            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }
    }
}
