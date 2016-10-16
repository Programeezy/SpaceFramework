using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceFramework.Desktop.ViewModel
{
    class ViewModelMainWindow : ViewModelBase
    {
        public StarCollection Stars { get; set; }
        public object SelectedStar { get; set; }

        public ViewModelMainWindow()
        {
            Stars = new StarCollection();
            Stars.Add(new Star("Sun", 3, 4, 5, (LumEnum) 1, null));
        }
    }
}
