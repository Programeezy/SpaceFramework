using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceFramework
{
    public class Constellation
    {

    }

    public class ConstellationCollection : ICollection<Constellation>
    {
        private Tuple<Constellation>[] _constellas;

        public ConstellationCollection(params Tuple<Constellation>[] constellas)
        {
            if (constellas.Length == 0)
                throw new ArgumentException("Empty Collection");
            else
            _constellas = constellas;
        }
        public int Count
        {
            get
            {
                if (_constellas.Length < 1)
                    throw new NotImplementedException();
                else return _constellas.Length;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void Add(Constellation item)
        {
            Array.Resize(ref _constellas, _constellas.Length + 1);
            int i = _constellas.Length - 1;
            Tuple<Constellation> temp = Tuple.Create(item);
            _constellas[i] = temp;
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(Constellation item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(Constellation[] array, int arrayIndex)
        {   
            throw new NotImplementedException();
        }

        public IEnumerator<Constellation> GetEnumerator()
        {
            for (int i = 0; i < _constellas.Length - 1; i++)
                yield return _constellas[i].Item1;
        }

        public bool Remove(Constellation item)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }

}
