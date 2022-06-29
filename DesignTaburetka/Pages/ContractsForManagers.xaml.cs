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
    /// Логика взаимодействия для ContactsForManagers.xaml
    /// </summary>
    public partial class ContractsForManagers : Page
    {
        public ContractsForManagers()
        {
            InitializeComponent();
            //2 - contracts in work, 3 - planned, 1 - completed
            CompletedData.DataContext = RefreshTable(1);

            InWorkData.DataContext = RefreshTable(2);

            PlannedData.DataContext = RefreshTable(3);

            
        }
        
        private DataTable RefreshTable(int status_id)
        {
            DataTable WorkData = WPFHelper.Select("SELECT work_id, CONVERT(varchar, came_at, 23) came_at, CONVERT(varchar, work_start, 23) work_start, DW.suppose_days, fact_days, project_name, DW.order_id, index_num " +
                "FROM DepartmentWork DW INNER JOIN OrderTask OT ON DW.order_id = OT.order_id " +
                $"WHERE emp_id = {Login.emp_id} AND status_id = {status_id}"
                );
            return WorkData;
        }


        private void BtnMoveToCompleted1_Click(object sender, RoutedEventArgs e)
        {
            DataRowView dataRowView = (DataRowView)((Button)e.Source).DataContext;
            int work_id = int.Parse(dataRowView[0].ToString());
            DataRow dr = RefreshTable(2).Select($"work_id={work_id}")[0];
            int order_id = int.Parse(dr["order_id"].ToString());
            int index_num = int.Parse(dr["index_num"].ToString());

            WPFHelper.DMLSQL($"UPDATE DepartmentWork SET fact_days = DATEDIFF(d, work_start, CONVERT (date, SYSDATETIME())), status_id = 1 WHERE order_id = {order_id} AND index_num={index_num}; "+
                             $"IF EXISTS(SELECT work_id FROM DepartmentWork WHERE order_id = {order_id} AND index_num = {index_num + 1}) " +
                             "BEGIN " +
                                $"UPDATE DepartmentWork SET came_at = CONVERT(date, SYSDATETIME()), status_id=3 WHERE order_id = {order_id} AND index_num = {index_num + 1} " +
                             "END;");
            InWorkData.DataContext = RefreshTable(2);
            CompletedData.DataContext = RefreshTable(1);


        }
        private void BtnMoveToInWork1_Click(object sender, RoutedEventArgs e)
        {
            DataRowView dataRowView = (DataRowView)((Button)e.Source).DataContext;
            int work_id = int.Parse(dataRowView[0].ToString());
            DataRow dr = RefreshTable(3).Select($"work_id={work_id}")[0];
            int order_id = int.Parse(dr["order_id"].ToString());
            int index_num = int.Parse(dr["index_num"].ToString());

            WPFHelper.DMLSQL($"UPDATE DepartmentWork SET work_start = CONVERT (date, SYSDATETIME()), status_id=2 WHERE order_id = {order_id} AND index_num={index_num}; ");
            InWorkData.DataContext = RefreshTable(2);
            PlannedData.DataContext = RefreshTable(3);
        }
        private void BtnDeleteCompleted1_Click(object sender, RoutedEventArgs e)
        {
            DataRowView dataRowView = (DataRowView)((Button)e.Source).DataContext;
            int work_id = int.Parse(dataRowView[0].ToString());
            DataRow dr = RefreshTable(1).Select($"work_id={work_id}")[0];
            int order_id = int.Parse(dr["order_id"].ToString());
            int index_num = int.Parse(dr["index_num"].ToString());

            WPFHelper.DMLSQL($"DELETE FROM DepartmentWork WHERE order_id = {order_id} AND index_num={index_num}; ");
            InWorkData.DataContext = RefreshTable(2);
            CompletedData.DataContext = RefreshTable(1);
        }
    }
}
