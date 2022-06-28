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
            DataTable DTInWorkData = WPFHelper.Select("SELECT work_id, CONVERT(varchar, came_at, 23) came_at, CONVERT(varchar, work_start, 23) work_start, DW.suppose_days, fact_days, project_name " +
                "FROM DepartmentWork DW INNER JOIN OrderTask OT ON DW.order_id = OT.order_id " +
                $"WHERE emp_id = {Login.emp_id} AND status_id = 2"
                );
            InWorkData.DataContext = DTInWorkData;

            DataTable DTPlannedData = WPFHelper.Select("SELECT work_id, CONVERT(varchar, came_at, 23) came_at, CONVERT(varchar, work_start, 23) work_start, DW.suppose_days, fact_days, project_name " +
                "FROM DepartmentWork DW INNER JOIN OrderTask OT ON DW.order_id = OT.order_id " +
                $"WHERE emp_id = {Login.emp_id} AND status_id = 3"
                );
            PlannedData.DataContext = DTPlannedData;

            DataTable DTCompletedData = WPFHelper.Select("SELECT work_id, CONVERT(varchar, came_at, 23) came_at, CONVERT(varchar, work_start, 23) work_start, DW.suppose_days, fact_days, project_name " +
                "FROM DepartmentWork DW INNER JOIN OrderTask OT ON DW.order_id = OT.order_id " +
                $"WHERE emp_id = {Login.emp_id} AND status_id = 1"
                );
            CompletedData.DataContext = DTCompletedData;
        }

        private void BtnMoveToCompleted1_Click(object sender, RoutedEventArgs e)
        {

        }
        private void BtnMoveToInWork1_Click(object sender, RoutedEventArgs e)
        {

        }
        private void BtnDeleteCompleted1_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
