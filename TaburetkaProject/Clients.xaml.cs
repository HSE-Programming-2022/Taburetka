using System;
using System.Collections.Generic;
using System.Data;
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
    /// Логика взаимодействия для Clients.xaml
    /// </summary>
    public partial class Clients : Page
    {
        public Clients()
        {
            InitializeComponent();
            DataTable DTClients = WPFHelper.Select("SELECT * FROM [dbo].[Clients]");
            DG1.DataContext = DTClients;

        }

        private void BtnView_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataRowView dataRowView = (DataRowView)((Button)e.Source).DataContext;
                String ProductName = dataRowView[1].ToString();
                String ProductDescription = dataRowView[2].ToString();
                MessageBox.Show("You Clicked : client");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        
        }

        private void BtnAddClient_Click(object sender, RoutedEventArgs e)
        {
            WindowAddClient addClient = new WindowAddClient();
            
            addClient.ShowDialog();
            // check input

            string insertCommand = String.Format(
                "INSERT INTO dbo.Clients (CompanyName, ClientName, Phones, Adresses, Comment, ClientType)" +
                " VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}')",
                addClient.CompanyIdentificator, addClient.ClientName, addClient.ClientPhones, addClient.ClientAdresses, addClient.ClientComment, addClient.TypeClient
                );
            WPFHelper.Insert(insertCommand);
            DG1.DataContext = WPFHelper.Select("SELECT * FROM [dbo].[Clients]");
        }

        private void BtnDeleteClient_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
