using DesignTaburetka.Helpers;
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

namespace DesignTaburetka.Pages
{
    /// <summary>
    /// Логика взаимодействия для Clients.xaml
    /// </summary>
    public partial class Clients : Page
    {
        public Clients()
        {
            InitializeComponent();
            DataTable DTClients = WPFHelper.Select("SELECT * FROM [dbo].[Client] full outer Join [dbo].[Physical] on [dbo].[Client].client_id = [dbo].[Physical].client_id " +
                " full outer Join [dbo].[Legal] on [dbo].[Client].client_id = [dbo].[Legal].client_id"
                );
            ClientsData.DataContext = DTClients;

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
                "INSERT INTO dbo.Client (client_name, client_address, client_phone, client_type)" +
                " VALUES ('{0}', '{1}', '{2}', '{3}')",
                addClient.ClientName, addClient.ClientAdresses, addClient.ClientPhones, addClient.TypeClientId
                );
            WPFHelper.DMLSQL(insertCommand);
            ClientsData.DataContext = WPFHelper.Select("SELECT * FROM [dbo].[Client]");
        }

        private void BtnDeleteClient_Click(object sender, RoutedEventArgs e)
        {
            //DataRowView row = (DataRowView)((Button)e.Source).DataContext;

            DataRowView dataRowView = (DataRowView)((Button)e.Source).DataContext;

            string id = dataRowView[0].ToString();

            string deleteCommand = $"delete from Client where client_id = {int.Parse(id)}";
            WPFHelper.DMLSQL(deleteCommand);
            ClientsData.DataContext = WPFHelper.Select("SELECT * FROM [dbo].[Client]");
        }
    }
}
