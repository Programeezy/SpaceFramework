/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceFramework.Desktop.ViewModel
{
     class ViewModelStarInfo : ViewModelBase
    {
        public string StarName { get; set; }
        public string StarRadius { get; set; }
        public string StarMass { get; set; }
        public string StarLuminosity { get; set; }
        public string StarType { get; set; }
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
*/