using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceFramework.Desktop.ViewModel
{
    class ViewModelStarInfo : ViewModelBase
    {
        public string Name { get; set; }
        public string Radius { get; set; }
        public string Mass { get; set; }
        public string Luminosity { get; set; }
        public string Type { get; set; }
        public PlanetCollection Satellites { get; set; }

        public ViewModelStarInfo(Star star)
        {
            Name = star.Name;
            Radius = star.Radius.ToString();
            Mass = star.Mass.ToString();
            Luminosity = star.Luminosity.ToString();
            Type = star.Type.ToString();
            Satellites = star.SatellitePlanets;
            
        }
    }
}
