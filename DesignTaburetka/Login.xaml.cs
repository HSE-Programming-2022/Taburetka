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
using System.Windows.Shapes;

namespace DesignTaburetka
{
    /// <summary>
    /// Логика взаимодействия для Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

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
        


        private void btnLogIn_Click(object sender, RoutedEventArgs e)
        {
            if (loginText.Text.Length == 0 || password.Password.Length == 0)
            {
                MessageBox.Show("Вы не ввели все данные.");
                loginText.Focus();
            }
            else if (loginText.Text == "admin" && password.Password == "123456")
            {
                AdminUslugi _menuAdmin = new AdminUslugi();
                _menuAdmin.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Ошибка в веденных данных");
            }
        }
    }
}
