using DesignTaburetka.Helpers;
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

namespace DesignTaburetka.Pages
{
    /// <summary>
    /// Логика взаимодействия для WindowAddClient.xaml
    /// </summary>
    public partial class WindowAddClient : Window
    {
        public string ClientName
        {
            get { return clientName.Text; }
        }
        public string ClientPhones
        {
            get { return Phones.Text; }
        }
        public string ClientAdresses
        {
            get { return Adresses.Text; }
        }

        public int TypeClientId;

        public WindowAddClient()
        {
            InitializeComponent();
        }


        private void clientType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string type = ((ComboBoxItem)ClientType.SelectedItem).Content.ToString();

            if (type.ToString() == "Юридическое лицо")
            {
                TypeClientId = 1;
            }
            else
            {
                TypeClientId = 2;
            }
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        // Start: Button Close | Restore | Minimize 
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnAddClient_Click(object sender, RoutedEventArgs e)
        {

        }

        private new void DragMove()
        {
            throw new NotImplementedException();
        }

        private void lblNote_MouseDown(object sender, MouseButtonEventArgs e)
        {
            clientName.Focus();
            Phones.Focus();
            Adresses.Focus();
            ClientType.Focus();
        }

        private void txtNote_TextChanged_clientName(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(clientName.Text) && clientName.Text.Length > 0)
            {
                clientName.Visibility = Visibility.Collapsed;
            }
            else
            {
                clientName.Visibility = Visibility.Visible;
            }
        }

        private void txtNote_TextChanged_Phones(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(Phones.Text) && Phones.Text.Length > 0)
            {
                Phones.Visibility = Visibility.Collapsed;
            }
            else
            {
                Phones.Visibility = Visibility.Visible;
            }
        }

        private void txtNote_TextChanged_Adresses(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(Adresses.Text) && Adresses.Text.Length > 0)
            {
                Adresses.Visibility = Visibility.Collapsed;
            }
            else
            {
                Adresses.Visibility = Visibility.Visible;
            }
        }
    }
}
