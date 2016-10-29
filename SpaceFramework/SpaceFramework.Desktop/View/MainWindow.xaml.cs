﻿using SpaceFramework.Desktop.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SpaceFramework.Desktop
{
    // todo: read about MVVM

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        public MainWindow()
        {
            InitializeComponent();

        }

      
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var viewModel = DataContext as ViewModel.ViewModelMainWindow;
            viewModel.Remove(sender, e);
        }
    }
}
