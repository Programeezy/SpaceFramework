using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceCatalog
{
    public class PlanetCollection : MainCollection<Planet>
    {
      
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

       

    }
}
