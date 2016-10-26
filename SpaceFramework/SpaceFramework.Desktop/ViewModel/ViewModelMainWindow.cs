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
                    Constellation current = SelectedConstellation as Constellation;
                    _Stars = current.Stars;
                    return _Stars;
                }
                return new StarCollection();
            }

            set
            {
                if (SelectedConstellation != null)
                {
                    Constellation current = SelectedConstellation as Constellation;
                    current.Stars = value;
                    NotifyPropertyChanged("Stars");
                }
            }
        }

        public PlanetCollection Planets { get; set; }
        public ConstellationCollection Constellations { get; set; }
        public object SelectedStar { get; set; }
        private object _SelectedConstellation;
        public object SelectedConstellation
        {
            get
            {
                return _SelectedConstellation;
            }
            set
            {
                _SelectedConstellation = value;
                var current = _SelectedConstellation as Constellation;
                Stars = current.Stars;
                NotifyPropertyChanged("Stars");
            }
        }


        public ViewModelMainWindow()
        {
           
            Stars = new StarCollection();
            Planets = new PlanetCollection();
            Constellations = new ConstellationCollection();
            Constellations.Add(new Constellation("Libra",null, Stars));
            Planets.Add(new Planet("Earth", 5, 4, 2, 3, 4, null));
            Stars.Add(new Star("Sun", 3, 4, 5, (LumEnum) 1, Planets));

           
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedStar!= null)
            {
                Stars.Remove((Star)SelectedStar);
                NotifyPropertyChanged("Stars");
            }
        }

    }
}
