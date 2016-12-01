using SpaceCatalog.Desktop.View;
using System;
using System.Windows;
using System.Windows.Input;
using SpaceCatalog.IO;
using System.IO;

namespace SpaceCatalog.Desktop.ViewModel
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
        public ConstellationCollection _Constellations;
        public ConstellationCollection Constellations
        {
            get { return _Constellations; }
            set
            {
                _Constellations = value;
                NotifyPropertyChanged("Constellations");
            }
        }
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
                if (current != null)
                {
                    StarName = current.Name;
                    StarRadius = current.Radius.ToString();
                    StarMass = current.Mass.ToString();
                    StarLuminosity = current.Luminosity.ToString();
                    StarType = current.Type.ToString();
                    Satellites = current.SatellitePlanets;
                    Planets = current.SatellitePlanets;
                    NotifyPropertyChanged("Planets");
                    NotifyPropertyChanged("SelectedStar");
                }
                else
                {
                    StarName = null;
                    StarRadius = null;
                    StarMass = null;
                    StarLuminosity = null;
                    StarType = null;
                    Satellites = null;
                    Planets = null;
                    NotifyPropertyChanged("Planets");
                    NotifyPropertyChanged("Star");
                }
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
                ConstellationImage = Directory.GetCurrentDirectory() + current.ImagePath;
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

        private string _ConstellationName;
        public string ConstellationName
        {
            get { return _ConstellationName; }
            set
            {
                _ConstellationName = value;
                NotifyPropertyChanged("ConstellationName");
            }
        }

        public ICommand AddConstellationCommand
        {
            get
            {
                return new RelayCommand(AddConstellation);
            }
        }

        public ICommand AddStarCommand
        {
            get
            {
                return new RelayCommand(AddStar);
            }
        }
        
        public ICommand RemoveConstellationCommand
        {
            get
            {
                return new RelayCommand(RemoveConstellation);
            }
        }

        private string _ConstellationImage;
        public string ConstellationImage
        {
            get
            {
                return _ConstellationImage;
            }

            set
            {
                _ConstellationImage = value;
                NotifyPropertyChanged("ConstellationImage");

            }
        }

        public ViewModelMainWindow()
        {
           
            Stars = new StarCollection();
            Planets = new PlanetCollection();
            StarCollection stars = new StarCollection();
            PlanetCollection planets = new PlanetCollection();
            planets.Add(new Planet("Earth", 5, 4, 2, 3, 4));
            stars.Add(new Star("Sun", 3, 4, 5, (LumEnum)1, planets));
            Constellations = new ConstellationCollection();
            Constellations.Add(new Constellation("Libra", @"\img\libra.jpg", stars));
            foreach (Constellation item in Constellations)
               SpaceFileHandler.WriteBinaryConstellation(SpaceFileHandler.ConstellationsFile, item);
            SpaceSerializer.Serialize(Constellations, "constellations");
            Constellations.Add(SpaceFileHandler.ReadBinaryConstellation(SpaceFileHandler.ConstellationsFile));
    }


        private void AddConstellation(object name)
        {
            if (name != null)
            {
                Constellations.Add(new Constellation(name.ToString()));
            }

        }

        private void AddStar()
        {
            if (SelectedConstellation != null)
            {
                var current = SelectedConstellation as Constellation;
                var addWindow = new AddStarWindow() { DataContext = new ViewModelAddStar(current) };
                addWindow.Show();
            }
        }

        public void RemoveConstellation()
        {
            if (SelectedConstellation!= null)
            {
                Constellations.Remove((Constellation)SelectedConstellation);
                NotifyPropertyChanged("Constellations");
            }
        }

    }
}
