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

namespace AdminInterface
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
        public string ClientComment
        {
            get { return comment.Text; }
        }
        public WindowAddClient()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
