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

namespace DesignTaburetka
{
    /// <summary>
    /// Логика взаимодействия для WindowAddWorker.xaml
    /// </summary>
    public partial class WindowAddWorker : Window
    {
        public static string WorkerID;

        public DataTable WorkerInfo = WPFHelper.Select("SELECT b.worker_id, c.emp_name, c.emp_surname, d.dep_name FROM Teams a INNER JOIN WorkerTeam b ON a.team_id = b.team_id" +
                                                       "INNER JOIN Employee c ON b.worker_id = c.emp_id" +
                                                       "INNER JOIN Department d ON c.emp_dep_id = d.dep_id" +
                                                      $"WHERE b.worker_id = {int.Parse(WorkerID)}"
                                                      );

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            WorkerID = workerID.Text;
        }
    }
}
