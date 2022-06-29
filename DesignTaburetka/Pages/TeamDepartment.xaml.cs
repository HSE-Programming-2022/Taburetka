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
    /// Логика взаимодействия для TeamDepartment.xaml
    /// </summary>
    public partial class TeamDepartment : Page
    {
        private int team_id;

        public int Team_id { get => team_id; set => team_id = value; }

        public string dep_worker_name;

        public TeamDepartment()
        {
            InitializeComponent();
            DataTable DTWorkers = WPFHelper.Select("SELECT b.worker_id, c.emp_surname, emp_name, d.dep_name, a.team_id, ER.rank_name FROM Teams a INNER JOIN WorkerTeam b ON a.team_id = b.team_id " +
                                                   "INNER JOIN Employee c ON b.worker_id = c.emp_id " +
                                                   "INNER JOIN Department d ON c.emp_dep_id = d.dep_id " +
                                                   "INNER JOIN EmployeeRank ER ON c.rank_id = ER.rank_id " +
                                                   $"WHERE a.manager_id = {Login.emp_id}"
                );
            TeamData.DataContext = DTWorkers;

            DataTable DTTeam_ID = WPFHelper.Select("SELECT team_id FROM Teams " +
                                                   $"WHERE manager_id = {Login.emp_id}"
                );

            Team_id = int.Parse(DTTeam_ID.Rows[0]["team_id"].ToString());



        }

        private void BtnView_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataRowView dataRowView = (DataRowView)((Button)e.Source).DataContext;
                String ProductName = dataRowView[1].ToString();
                String ProductDescription = dataRowView[2].ToString();
                MessageBox.Show("You Clicked : worker");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }

        private void BtnAddWorker_Click(object sender, RoutedEventArgs e)
        {
            WindowAddWorker addWorker = new WindowAddWorker();

            addWorker.ShowDialog();
            // check input

            DataTable DTDep_worker_name = WPFHelper.Select("SELECT dep_name FROM Employee a INNER JOIN Department b ON a.emp_dep_id = b.dep_id " +
                                                         $"WHERE emp_id = {int.Parse(addWorker.WorkerID)}"
            );

            if (DTDep_worker_name.Rows[0]["dep_name"].ToString() == $"{Login.dep_name}")
            {
                string insertCommand =
               "INSERT INTO dbo.WorkerTeam (team_id, worker_id)" +
               $" VALUES ('{team_id}', '{int.Parse(addWorker.WorkerID)}') ";

                WPFHelper.DMLSQL(insertCommand);
            }
            else
            {
                MessageBox.Show("Данный сотрудник не из Вашего отдела");
            }   
            
            TeamData.DataContext = WPFHelper.Select("SELECT b.worker_id, c.emp_name, c.emp_surname, d.dep_name FROM Teams a INNER JOIN WorkerTeam b ON a.team_id = b.team_id " +

                                                   "INNER JOIN Employee c ON b.worker_id = c.emp_id " +
                                                   "INNER JOIN Department d ON c.emp_dep_id = d.dep_id " +
                                                   "INNER JOIN EmployeeRank ER ON c.rank_id = ER.rank_id " +
                                                   $"WHERE a.manager_id = {Login.emp_id}");
        }

        private void BtnDeleteWorker_Click(object sender, RoutedEventArgs e)
        {
            DataRowView row = (DataRowView)((Button)e.Source).DataContext;

            DataRowView dataRowView = (DataRowView)((Button)e.Source).DataContext;

            string id = dataRowView[0].ToString();

            string deleteCommand = $"delete from WorkerTeam where worker_id = {int.Parse(id)}";
            WPFHelper.DMLSQL(deleteCommand);
            TeamData.DataContext = WPFHelper.Select("SELECT b.worker_id, c.emp_surname, emp_name, d.dep_name, a.team_id, ER.rank_name FROM Teams a INNER JOIN WorkerTeam b ON a.team_id = b.team_id " +
                                                   "INNER JOIN Employee c ON b.worker_id = c.emp_id " +
                                                   "INNER JOIN Department d ON c.emp_dep_id = d.dep_id " +
                                                   "INNER JOIN EmployeeRank ER ON c.rank_id = ER.rank_id " +
                                                   $"WHERE a.manager_id = {Login.emp_id}"
                                                   );
        }
    }
}
