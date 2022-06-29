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
            DataTable DTOrderTask = WPFHelper.Select("SELECT a.order_id, a.project_name, d.client_name, a.created_at, a.suppose_days, a.comment, c.emp_name, c.emp_surname, order_emergency, order_type_id,  " +
                "b.design_link, b.measures_link FROM OrderTask a inner join OrderProject b on a.order_id = b.order_id inner join Employee c on a.added_by = c.emp_id inner join Client d on a.client_id = d.client_id"
                );
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
            DataTable DTOrderTask = WPFHelper.Select("SELECT a.order_id, a.project_name, d.client_name, a.created_at, a.suppose_days, a.comment, c.emp_name, c.emp_surname, order_emergency, order_type_id,  " +
                "b.design_link, b.measures_link FROM OrderTask a inner join OrderProject b on a.order_id = b.order_id inner join Employee c on a.added_by = c.emp_id inner join Client d on a.client_id = d.client_id"
                );
            OrderTaskData.DataContext = DTOrderTask;

        }

        private void BtnCheckOrder_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
