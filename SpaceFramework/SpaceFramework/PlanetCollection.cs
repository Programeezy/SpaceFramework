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
        private Planet[] _Planets = new Planet[0];

        public PlanetCollection(params Planet[] Planets)
        {
            Array.Resize(ref _Planets, Planets.Length);
            _Planets = Planets;
        }

        public void Add(Planet item)
        {
            Array.Resize(ref _Planets, _Planets.Length + 1);
            _Planets[_Planets.Length - 1] = item;
        }

        public bool Contains(Planet item)
        {
            foreach (Planet _item in this)
            {
                if (_item == item)
                {
                    return true;
                }
            }

            return false;
        }

        public PlanetCollection FindByMass(int max, int min)
        {
            PlanetCollection planets = new PlanetCollection();
            foreach(Planet i in this)
            {
                if (i.Mass > min && i.Mass < max)
                    planets.Add(i);
            }

            return planets;
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
