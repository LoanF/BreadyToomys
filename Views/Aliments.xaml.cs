using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Navigation;
using BreadyToomys.Models;

namespace BreadyToomys.Views
{
    /// <summary>
    /// Logique d'interaction pour Aliments.xaml
    /// </summary>
    public partial class Aliments : Page
    {
        public Aliments()
        {
            InitializeComponent();
            LoadIngredients();
        }

        private void LoadIngredients()
        {
            List<Aliment> aliments = (new Aliment()).Read();
            listAliments.ItemsSource = aliments;
        }

        private void btnHomeClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Home());
        }

        private void btnAddClick(object sender, RoutedEventArgs e)
        {

        }

        private void btnRemoveClick(object sender, RoutedEventArgs e)
        {

        }
    }
}
