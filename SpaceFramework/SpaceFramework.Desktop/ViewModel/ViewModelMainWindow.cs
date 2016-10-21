using System.Windows;
using System.Windows.Input;

namespace SpaceFramework.Desktop.ViewModel
{
    class ViewModelMainWindow : ViewModelBase
    {
        public StarCollection Stars { get; set; }
        public PlanetCollection Planets { get; set; }
        public object SelectedStar { get; set; }
        public delegate void MyCommand(object sender, RoutedEventArgs e);
        private MyCommand _RemoveStar;
       
       // public MyCommand ShowStarInfo { get; set; }

        public ViewModelMainWindow()
        {
           // ShowStarInfo = new MyCommand(ListBox_MouseDoubleClick);
            Stars = new StarCollection();
            Planets = new PlanetCollection();
            Planets.Add(new Planet("Earth", 5, 4, 2, 3, 4, null));
            Stars.Add(new Star("Sun", 3, 4, 5, (LumEnum) 1, Planets));

            //RemoveStar = new MyCommand(Button_Click);
           
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
