using System.Windows;
using System.Windows.Input;

namespace SpaceFramework.Desktop.ViewModel
{
    class ViewModelMainWindow : ViewModelBase
    {
        private StarCollection _Stars;
  
       public StarCollection Stars
        {
            get
            {
                if (SelectedConstellation != null)
                {
                    
                    return _Stars;
                }
                return new StarCollection();
            }

            set
            {
                if (SelectedConstellation != null)
                {
                    _Stars = value;
                    NotifyPropertyChanged("Stars");
                }
            }
        }
       
        public PlanetCollection Planets { get; set; }
        public ConstellationCollection Constellations { get; set; }
        private object _SelectedStar;
        public object SelectedStar
        {
            get
            {
                return _SelectedStar;
            }
            set
            {
                _SelectedStar = value;
                var current = _SelectedStar as Star;
                StarName = current.Name;
                StarRadius = current.Radius.ToString();
                StarMass = current.Mass.ToString();
                StarLuminosity = current.Luminosity.ToString();
                StarType = current.Type.ToString();
                Satellites = current.SatellitePlanets;
                NotifyPropertyChanged("SelectedStar");
            }
        }
        private object _SelectedConstellation;

        public object SelectedConstellation
        {
            get
            {   return _SelectedConstellation; }
            set
            {
                _SelectedConstellation = value;
                var current = _SelectedConstellation as Constellation;
                if(current!= null)
                    Stars = current.Stars;
                NotifyPropertyChanged("Stars");
            }
        }

        private string _StarName;
        public string StarName
        {
            get
            {   return _StarName;  }
            set
            {
                _StarName = value;
                NotifyPropertyChanged("StarName");
            }
        }

        private string _StarRadius;
        public string StarRadius
        {
            get
            {   return _StarRadius; }
            set
            {
                _StarRadius = value;
                NotifyPropertyChanged("StarRadius");
            }
        }
        private string _StarMass;
        public string StarMass
        {
            get { return _StarMass; }
            set
            {
                _StarMass = value;
                NotifyPropertyChanged("StarMass");
            }
        }
        private string _StarLuminosity;
        public string StarLuminosity
        {
            get { return _StarLuminosity; }
            set
            {
                _StarLuminosity = value;
                NotifyPropertyChanged("StarLuminosity");
            }
        }
        private string _StarType;
        public string StarType
        {
            get { return _StarType; }
            set
            {
                _StarType = value;
                NotifyPropertyChanged("StarType");
            }
        }

        private PlanetCollection _Satellites;
        public PlanetCollection Satellites
        {
            get { return _Satellites; }
            set
            {
                _Satellites = value;
                NotifyPropertyChanged("Satellites");
            }
        }

        public ViewModelMainWindow()
        {
           
            Stars = new StarCollection();
            Planets = new PlanetCollection();
            StarCollection stars = new StarCollection();
            stars.Add(new Star("Sun", 3, 4, 5, (LumEnum)1, Planets));
            Constellations = new ConstellationCollection();
            Constellations.Add(new Constellation("Libra", null, stars));
            Planets.Add(new Planet("Earth", 5, 4, 2, 3, 4, null));
            

           
        }

        /*    private void ListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
            {
                if (SelectedStar != null)
                {
                    var infoWindow = new StarInfo() { DataContext = new ViewModelStarInfo((Star)SelectedStar) };
                    infoWindow.Show();
                }
            }

        */

        public void Remove(object sender, RoutedEventArgs e)
        {
            if (SelectedConstellation!= null)
            {
                Constellations.Remove((Constellation)SelectedConstellation);
                NotifyPropertyChanged("Constellations");
            }
        }

    }
}
