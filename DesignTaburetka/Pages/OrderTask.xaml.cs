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
    /// Логика взаимодействия для OrderTask.xaml
    /// </summary>
    public partial class OrderTask : Page
    {
        public OrderTask()
        {
            InitializeComponent();
            DataTable DTOrderTask = WPFHelper.Select("SELECT * FROM OrderTask");
            OrderTaskData.DataContext = DTOrderTask;
        }

        private void BtnDeleteOrder_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnAddOrder_Click(object sender, RoutedEventArgs e)
        {
            WindowAddOrder addOrder = new WindowAddOrder();

            addOrder.ShowDialog();
            // check input

            string createdAt = DateTime.Today.ToString("yyyy'-'MM'-'dd");
            string insertCommand = String.Format(
                "INSERT INTO [dbo].[OrderTask] (created_at, comment, order_emergency, project_name," +
                "suppose_days, client_id, order_type_id, added_by)" +
                " VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}')",
                createdAt, addOrder.ClientComment, addOrder.TypeEmergency, addOrder.NameOrder,
                addOrder.TimeSuppose, addOrder.ClientID, addOrder.OrderTypeId, addOrder.EmpId
                );
            WPFHelper.DMLSQL(insertCommand);
            OrderTaskData.DataContext = WPFHelper.Select("SELECT * FROM [dbo].[OrderTask]");

        }
    }
}
