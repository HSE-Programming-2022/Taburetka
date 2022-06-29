using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для WindowAddWorkerInTeam.xaml
    /// </summary>
    public partial class WindowAddWorkerInTeam : Window
    {
        public WindowAddWorkerInTeam()
        {
            InitializeComponent();
        }

        public string WorkerID;

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private new void DragMove()
        {
            throw new NotImplementedException();
        }

        private void lblNote_MouseDown(object sender, MouseButtonEventArgs e)
        {
            workerID.Focus();
        }

        private void txtNote_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(workerID.Text) && workerID.Text.Length > 0)
            {
                workerID.Visibility = Visibility.Collapsed;
            }
            else
            {
                workerID.Visibility = Visibility.Visible;
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }


        private void btnAddWorkerInTeam_Click(object sender, RoutedEventArgs e)
        {
            WorkerID = workerID.Text;
            this.Close();
        }
    }
}
