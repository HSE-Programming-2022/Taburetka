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
            get { return Name.Text; }
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        // Починить!!!!!!!!!!!!!!!!!!!!!!! Я хуй знает, что здесь
        private void clientType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ClientType.SelectionBoxItem.ToString() == "Компания")
            {
                TypeClientId = 1;
            }
            else
            {
                TypeClientId = 2;
            }
        }
    }
}
