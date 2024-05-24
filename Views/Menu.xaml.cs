using BreadyToomys.Controlers;
using BreadyToomys.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Logique d'interaction pour Menu.xaml
    /// </summary>
    public partial class Menu : Page
    {
        private List<Product> products;
        public Menu()
        {
            InitializeComponent();
            products = (new Product()).Read();
            foreach (var product in products)
            {
                Debug.WriteLine($"Id: {product.Id}, Name: {product.Name}, Description: {product.Description}, Type: {product.Type}, Price: {product.Price}, Picture: {product.Picture}");
            }
            if (productsListView != null)
            {
                productsListView.ItemsSource = products;
            }
        }

        private void seeCart_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
