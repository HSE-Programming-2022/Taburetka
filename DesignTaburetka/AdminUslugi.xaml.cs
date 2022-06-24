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
using System.Windows.Controls.Primitives;

namespace DesignTaburetka
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class AdminUslugi : Window
    {
        public AdminUslugi()
        {
            InitializeComponent();
            fContainer.Navigate(new System.Uri("Pages/MainPageUslugi.xaml", UriKind.RelativeOrAbsolute));
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void BG_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Tg_Btn.IsChecked = false;
        }

        
        // Start: Button Close | Restore | Minimize 
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnRestore_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Normal)
                WindowState = WindowState.Maximized;
            else
                WindowState = WindowState.Normal;
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
        // End: Button Close | Restore | Minimize
        private void btnHome_Checked(object sender, RoutedEventArgs e)
        {
            fContainer.Navigate(new System.Uri("Pages/MainPageUslugi.xaml", UriKind.RelativeOrAbsolute));
        }

        private void btnLogOut_Checked(object sender, RoutedEventArgs e)
        {
            Login _login = new Login();
            _login.Show();
            this.Close();
        }

        private void btnOrderTemp_Checked(object sender, RoutedEventArgs e)
        {
            fContainer.Navigate(new System.Uri("Pages/OrderTask.xaml", UriKind.RelativeOrAbsolute));
        }

        private void btnContracts_Checked(object sender, RoutedEventArgs e)
        {
            fContainer.Navigate(new System.Uri("Pages/Contracts.xaml", UriKind.RelativeOrAbsolute));
        }

        private void btnClients_Checked(object sender, RoutedEventArgs e)
        {
            fContainer.Navigate(new System.Uri("Pages/Clients.xaml", UriKind.RelativeOrAbsolute));

        }

        private void btnToDo_Checked(object sender, RoutedEventArgs e)
        {
            fContainer.Navigate(new System.Uri("Pages/ToDo.xaml", UriKind.RelativeOrAbsolute));
        }

        private void btnNotes_Checked(object sender, RoutedEventArgs e)
        {
            fContainer.Navigate(new System.Uri("Pages/Notes.xaml", UriKind.RelativeOrAbsolute));
        }

        private void btnDashboard_Checked(object sender, RoutedEventArgs e)
        {
            fContainer.Navigate(new System.Uri("Pages/Dashboard.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}
