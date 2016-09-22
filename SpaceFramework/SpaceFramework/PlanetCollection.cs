using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceFramework
{
    public class PlanetCollection : IEnumerable<Planet>
    {
        private Planet[] _Planets;
        public PlanetCollection(params Planet[] Planets)
        {
            Array.Resize(ref _Planets, Planets.Length);
            _Planets = Planets;
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

    }
}
