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

    
}