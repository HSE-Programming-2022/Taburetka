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
using System.Windows.Shapes;

namespace DesignTaburetka.Pages
{
    /// <summary>
    /// Логика взаимодействия для ContractsForWorkers.xaml
    /// </summary>
    public partial class ContractsForWorkers : Page
    {
        public ContractsForWorkers()
        {
            
            InitializeComponent();
            //2 - tasks in progress, 3 - planned, 1 - completed
            InWorkData.DataContext = RefreshTable(2);

            PlannedData.DataContext = RefreshTable(3);

            CompletedData.DataContext = RefreshTable(1);
        }

        private DataTable RefreshTable(int status_id)
        {
            DataTable WorkData = WPFHelper.Select("SELECT work_id, CONVERT(varchar, came_at, 23) came_at, CONVERT(varchar, work_start, 23) work_start, DW.suppose_days, fact_days, project_name, DW.order_id, CONCAT ( emp_name, ' ', emp_surname) AS manager_name " +
                "FROM DepartmentWork DW INNER JOIN OrderTask OT ON DW.order_id = OT.order_id INNER JOIN Teams ON Teams.manager_id = DW.emp_id INNER JOIN WorkerTeam WT ON WT.team_id = Teams.team_id INNER JOIN Employee E ON DW.emp_id = E.emp_id " +
                $"WHERE worker_id = {Login.emp_id} AND status_id = {status_id}"
                );
            return WorkData;
        }

    }
}
