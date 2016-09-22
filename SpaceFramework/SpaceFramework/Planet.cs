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
        public Planet(string name, double radius, double mass, double PoS, double PoR, double RoO, params Star[] satellites)
        {
            IsExist = true;
            Name = name;
            Radius = radius;
            Mass = mass;
            PeriodOfSpinning = PoS;
            PeriodOfRotation = PoR;
            RadiusOfOrbit = RoO;
            Array.Resize(ref Satellites, satellites.Length);
            Satellites = satellites;
        }

        public Planet()
        {
            IsExist = false;
        }

        public bool IsExist;
        public string Name;
        private double Radius;
        private double Mass;
        private double PeriodOfSpinning;
        private double PeriodOfRotation;
        private double RadiusOfOrbit;
        public Star[] Satellites;
    }
    
}
