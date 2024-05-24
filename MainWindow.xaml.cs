using BreadyToomys.Views;
using System.Windows;

namespace BreadyToomys
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            mainFrame.Navigate(new Home());
        }
    }
}