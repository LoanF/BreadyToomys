﻿using System;
using System.Collections.Generic;
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

namespace BreadyToomys.Views
{
    /// <summary>
    /// Logique d'interaction pour Home.xaml
    /// </summary>
    public partial class Home : Page
    {
        public Home()
        {
            InitializeComponent();  
        }

        private void btnOrderClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Menu());
        }

        private void btnAdministrationClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Gestion());
        }
    }
}
