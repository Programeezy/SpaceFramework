using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceFramework
{
    public class Star
    {
    }

    public class StarCollection : IEnumerable<Star>
    {
        private Star[] _stars;
        public StarCollection(params Star[] stars)
        {
            if (stars.Length == 0)
            {
                throw new ArgumentException("Empty collection");
            }

            else
            {
                Array.Resize(ref _stars, stars.Length);
                _stars = stars;
            }

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