﻿using PokeLite.MVVM.ViewModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PokeLite
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindowVM mainWindowVM { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            mainWindowVM = new MainWindowVM();

            //Assign VM to datacontext
            //=> View can acces to variables to VM
            DataContext = mainWindowVM;
        }
    }
}