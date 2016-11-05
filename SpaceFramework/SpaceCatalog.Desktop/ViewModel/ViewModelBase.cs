using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SpaceCatalog.Desktop.ViewModel
{
    class ViewModelBase : INotifyPropertyChanged
    {
        internal void NotifyPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }

    class RelayCommand : ICommand
    {
        private Action<object> execute;
        private Action addStar;

        public event EventHandler CanExecuteChanged;

        public RelayCommand(Action<object> execute)
        {
            this.execute = execute;
        }

        public RelayCommand(Action addStar)
        {
            this.addStar = addStar;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter != null)
            {
                execute(parameter);
            }

            else
            {
                addStar();
            }
        }

       
    }
}
