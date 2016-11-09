using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceCatalog
{
    public enum LumEnum
    {
        O, B, A, F, G, K, M
    }
    public class Star
    {
        public Star(string name, double rad, double mass, double luminosity, LumEnum type, PlanetCollection satellite)
        {
            Name = name;
            Radius = rad;
            Mass = mass;
            Luminosity = luminosity;
            Type = type;
            if(satellite != null)
                SatellitePlanets = satellite;
        }

        public Star()
        {

        }
        
        //todo:Properties
        public string Name { get; set; }
        public double Radius { get; set; }
        public double Mass { get; set;  }
        public double Luminosity { get; set; }
        public LumEnum Type { get; set; }
        public PlanetCollection SatellitePlanets { get; set; } 

    }

    
}