using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceCatalog
{
    public class Planet
    {

        public Planet(string name, double radius, double mass, double PoS, double PoR, double RoO, params Star[] satellites)
        {
            IsExist = true;
            Name = name;
            Radius = radius;
            Mass = mass;
            PeriodOfSpinning = PoS;
            PeriodOfRotation = PoR;
            RadiusOfOrbit = RoO;
           if (satellites != null)
            {
                Array.Resize(ref Satellites, satellites.Length);
                Satellites = satellites;
            }
            else Satellites = null;
        }

        public Planet()
        {
            IsExist = false;
        }

        // todo: properties
        public bool IsExist;
        public string Name { get; set; }
        public double Radius { get; set; }
        public double Mass { get; set; }
        public double PeriodOfSpinning { get; set; }
        public double PeriodOfRotation { get; set; }
        public double RadiusOfOrbit { get; set; }
        public Star[] Satellites;
    }
    
}
