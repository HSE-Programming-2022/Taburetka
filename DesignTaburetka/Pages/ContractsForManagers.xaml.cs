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
            DataTable DTInWorkData = WPFHelper.Select("SELECT a.work_id, a.came_at, a.work_start, a.suppose_days, a.fact_days, b.status_name, c.dep_name, d.emp_name, d.emp_surname, f.project_name " +
                "FROM DepartmentWork a INNER JOIN OrderStatus b ON a.status_id = b.status_id " +
                "INNER JOIN Department c ON a.dep_id = c.dep_id INNER JOIN Employee d ON a.emp_id = d.emp_id INNER JOIN OrderTask f ON a.order_id = f.order_id"
                );
            InWorkData.DataContext = DTInWorkData;

            DataTable DTPlannedData = WPFHelper.Select("SELECT a.work_id, a.came_at, a.work_start, a.suppose_days, a.fact_days, b.status_name, c.dep_name, d.emp_name, d.emp_surname, f.project_name " +
                "FROM DepartmentWork a INNER JOIN OrderStatus b ON a.status_id = b.status_id " +
                "INNER JOIN Department c ON a.dep_id = c.dep_id INNER JOIN Employee d ON a.emp_id = d.emp_id INNER JOIN OrderTask f ON a.order_id = f.order_id"
                );
            PlannedData.DataContext = DTPlannedData;

            DataTable DTCompletedData = WPFHelper.Select("SELECT a.work_id, a.came_at, a.work_start, a.suppose_days, a.fact_days, b.status_name, c.dep_name, d.emp_name, d.emp_surname, f.project_name " +
                "FROM DepartmentWork a INNER JOIN OrderStatus b ON a.status_id = b.status_id " +
                "INNER JOIN Department c ON a.dep_id = c.dep_id INNER JOIN Employee d ON a.emp_id = d.emp_id INNER JOIN OrderTask f ON a.order_id = f.order_id"
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
