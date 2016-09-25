using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceFramework
{
    public class CoolCollection<T> : IEnumerable<T>
    {

    }

    public class ConstellationCollection : CoolCollection<Constellation>
    {
        private Constellation[] _constellation;

        public ConstellationCollection()
        {
            
        }

        public ConstellationCollection(params Constellation[] constellation)
        {
            if (constellation == null)
            {
                throw new ArgumentNullException(nameof(constellation));
            }
            Array.Resize(ref _constellation, constellation.Length);
            _constellation = constellation;


        }

        public bool Contains(Constellation item)
        {
            foreach (Constellation _item in this)
            {
                if (_item == item)
                {
                    return true;
                }
            }

            return false;
        }

        public void Add(Constellation item)
        {
            Array.Resize(ref _constellation, _constellation.Length + 1);
            _constellation[_constellation.Length - 1] = item;
        }

        public bool Remvoe(Constellation item)
        {
            throw new NotImplementedException();
        }

        public Constellation FindByName(string name)
        {
            foreach (Constellation item in this)
            {
                if (item.Name == name)
                {
                    return item;
                }
            }
            return null;
            // throw new bla=bla-bla-Exception()
        }


        public IEnumerator<Constellation> GetEnumerator()
        {
            for (int i = 0; i < _constellation.Length - 1; i++)
                yield return _constellation[i];
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

    }
}
