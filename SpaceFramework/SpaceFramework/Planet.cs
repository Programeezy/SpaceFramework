using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceFramework
{
    public class Planet
    {
        public string Name;
        private double Radius;
        private double Mass;
        private double PeriodOfSpinning;
        private double PeriodOfRotation;
        private double RadiusOfOrbit;
        public Star Satellite;
    }

    public class PlanetCollection : IEnumerable<Planet>
    {
        private Planet[] _Planets;
        public PlanetCollection(params Planet[] Planets)
        {
            if (Planets.Length == 0)
            {
                throw new ArgumentException("Empty collection");
            }

            else
            {
                Array.Resize(ref _Planets, Planets.Length);
                _Planets = Planets;
            }

        }

        public IEnumerator<Planet> GetEnumerator()
        {
            for (int i = 0; i < _Planets.Length - 1; i++)
                yield return _Planets[i];
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            for (int i = 0; i < _Planets.Length - 1; i++)
                yield return _Planets[i];
        }

        public class PlanetEnum : IEnumerator
        {
            public Planet[] _Planets;
            int position = -1;

            public PlanetEnum(Planet[] Planets)
            {
                _Planets = Planets;
            }

            public object Current
            {
                get
                {
                    try
                    {
                        return _Planets[position];
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
                return (position < _Planets.Length);
            }

            public void Reset()
            {
                position = -1;
            }
        }
    }
}
