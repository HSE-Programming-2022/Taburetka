using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

namespace TaburetkaProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void Dashboard_Click(object sender, RoutedEventArgs e)
        {
            MyFrame.Content = new Dashboard();
        }
        private void TempOrders_Click(object sender, RoutedEventArgs e)

        {
            
            MyFrame.Content = new TempOrders();
        }
        private void ToDo_Click(object sender, RoutedEventArgs e)
        {
            MyFrame.Content = new ToDo();
        }
        private void Contracts_Click(object sender, RoutedEventArgs e)
        {
            MyFrame.Content = new Contracts();
        }
        private void Notes_Click(object sender, RoutedEventArgs e)
        {
            MyFrame.Content = new Notes();
        }

        private void Clients_Click(object sender, RoutedEventArgs e)
        {
            
            MyFrame.Content = new Clients();

        }
    }
}
