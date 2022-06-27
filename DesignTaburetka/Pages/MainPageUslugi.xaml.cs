using DesignTaburetka.Helpers;
using DesignTaburetka.Pages;
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
using System.Data;

namespace DesignTaburetka
{
    /// <summary>
    /// Логика взаимодействия для mainPage.xaml
    /// </summary>
    public partial class MainPageUslugi : Page
    {
        public MainPageUslugi()
        {
            InitializeComponent();
        }

        private void btnAddOrder_Click(object sender, RoutedEventArgs e)
        {
            WindowAddOrder addOrder = new WindowAddOrder();

            addOrder.ShowDialog();
            //// check input

            //string insertCommand = String.Format(
            //    "INSERT INTO dbo.Client (CompanyName, ClientName, Phones, Adresses, Comment, ClientType)" +
            //    " VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}')",
            //    addOrder.CompanyIdentificator, addOrder.ClientName, addOrder.ClientPhones, addOrder.ClientAdresses, addOrder.ClientComment, addOrder.TypeClient
            //    );
            //WPFHelper.Insert(insertCommand);
            //OrderTaskData.DataContext = WPFHelper.Select("SELECT * FROM Client");
        }

        private void btnAddContract_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
