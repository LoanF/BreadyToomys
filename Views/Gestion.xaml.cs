using System;
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
    /// Logique d'interaction pour Gestion.xaml
    /// </summary>
    public partial class Gestion : Page
    {
        public Gestion()
        {
            InitializeComponent();
        }

        private void btnHomeClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Home());
        }

        private void btnAlimentClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Aliments());
        }

        private void btnRecetteClick(object sender, RoutedEventArgs e)
        {

        }
    }
}
