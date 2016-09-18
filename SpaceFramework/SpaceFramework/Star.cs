using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceFramework
{
    public enum StarEnum
    {
        O, B, A, F, G, K, M
    }
    public class Star
    {
        public string Name;
        private double Radius;
        private double Mass;
        private double Luminosity;
        public StarEnum Type;
        public PlanetCollection SatellitePlanets; 
    }

    public class StarCollection : IEnumerable<Star>
    {
        private Star[] _stars;

        public StarCollection()
        {

        }

        public StarCollection(params Star[] stars)
        {
          
            Array.Resize(ref _stars, stars.Length);
            _stars = stars;
            

        }

        public bool Contains(Star item)
        {
            foreach(Star _item in this)
            {
                if (_item == item)
                {
                    return true;
                }
            }

            return false;
        }

        public void Add(Star item)
        {
            Array.Resize(ref _stars, _stars.Length + 1);
            _stars[_stars.Length - 1] = item;
        }

        public bool Find(string Name)
        {
            foreach(Star _item in this)
            {
                if (_item.Name == Name)
                    return true;
            }

            return false;
        }

        public StarCollection Find(StarEnum SType)
        {
            StarCollection stars = new StarCollection();
            foreach(Star item in this)
            {
                if (item.Type.Equals(SType))
                    stars.Add(item);
            }

            return stars;
        }
        public IEnumerator<Star> GetEnumerator()
        {
            for (int i = 0; i < _stars.Length - 1; i++)
                yield return _stars[i];
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            for (int i = 0; i < _stars.Length - 1; i++)
                yield return _stars[i];
        }

        public class StarEnum : IEnumerator
        {
            public Star[] _stars;
            int position = -1;

            public StarEnum(Star[] stars)
            {
                _stars = stars;
            }
    
            public object Current
            {
                get
                {
                    try
                    {
                        return _stars[position];
                    }

                    catch(IndexOutOfRangeException)
                    {
                        throw new InvalidOperationException();
                    }
                }
            }

            public bool MoveNext()
            {
                position++;
                return (position < _stars.Length);
            }

            public void Reset()
            {
                position = -1;
            }
        }
    }
}