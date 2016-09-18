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
        public string Name;
        public string ImagePath;
        public StarCollection Constellations;
    }

    public class ConstellationCollection : IEnumerable<Constellation>
    {
        private Constellation[] _Constellations;

        public ConstellationCollection()
        {

        }

        public ConstellationCollection(params Constellation[] Constellations)
        {

            Array.Resize(ref _Constellations, Constellations.Length);
            _Constellations = Constellations;


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
            Array.Resize(ref _Constellations, _Constellations.Length + 1);
            _Constellations[_Constellations.Length - 1] = item;
        }

        public bool Find(string Name)
        {
            foreach (Constellation _item in this)
            {
                if (_item.Name == Name)
                    return true;
            }

            return false;
        }

      
        public IEnumerator<Constellation> GetEnumerator()
        {
            for (int i = 0; i < _Constellations.Length - 1; i++)
                yield return _Constellations[i];
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            for (int i = 0; i < _Constellations.Length - 1; i++)
                yield return _Constellations[i];
        }

        public class ConstellationEnum : IEnumerator
        {
            public Constellation[] _Constellations;
            int position = -1;

            public ConstellationEnum(Constellation[] Constellations)
            {
                _Constellations = Constellations;
            }

            public object Current
            {
                get
                {
                    try
                    {
                        return _Constellations[position];
                    }

                    catch (IndexOutOfRangeException)
                    {
                        throw new InvalidOperationException();
                    }
                }
            }

            public bool MoveNext()
            {
                position++;
                return (position < _Constellations.Length);
            }

            public void Reset()
            {
                position = -1;
            }
        }
    }
}