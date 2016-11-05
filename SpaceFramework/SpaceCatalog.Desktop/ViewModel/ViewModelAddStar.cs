using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SpaceCatalog.Desktop.ViewModel
{
    class ViewModelAddStar : ViewModelBase
    {
        public string StarName { get; set; }
        private double _StarRadius;

        public double StarRadius
        {
            get { return _StarRadius; }
            set
            {
                if(double.IsNaN(value))
                {
                    MessageBox.Show("Enter the number!");
                }

                else
                {
                    _StarRadius = value;
                    NotifyPropertyChanged("StarRadius");
                }
            }
        }

        private double _StarMass;

        public double StarMass
        {
            get { return _StarMass; }
            set
            {
                if (double.IsNaN(value))
                {
                    MessageBox.Show("Enter the number!");
                }

                else
                {
                    _StarMass = value;
                    NotifyPropertyChanged("StarMass");
                }
            }
        }

        private double _StarLuminosity;

        public double StarLuminosity
        {
            get { return _StarLuminosity; }
            set
            {
                if (double.IsNaN(value))
                {
                    MessageBox.Show("Enter the number!");
                }

                else
                {
                    _StarLuminosity = value;
                    NotifyPropertyChanged("StarLuminosity");
                }
            }
        }

        private LumEnum _StarType;

        public LumEnum StarType
        {
            get { return _StarType; }
            set
            {

                _StarType = value;
                NotifyPropertyChanged("StarType");
            }
        }

        public ICommand AddButtonCommand
        { get { return new RelayCommand(AddButton); } }

        Constellation CurrentConstellation;

        public ViewModelAddStar()
        {

        }

        public ViewModelAddStar(Constellation constellation)
        {
            CurrentConstellation = constellation;
        }
        public void AddButton()
        {
            CurrentConstellation.Stars.Add(new Star(StarName, StarRadius, StarMass, StarLuminosity, StarType,new PlanetCollection()));
            
        }
    }
}
