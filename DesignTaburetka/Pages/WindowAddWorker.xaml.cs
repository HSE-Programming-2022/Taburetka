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
    /// Логика взаимодействия для WindowAddWorker.xaml
    /// </summary>
    public partial class WindowAddWorker : Window
    {
        public string WorkerID;
        
        public WindowAddWorker()
        {
            InitializeComponent();
        }

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


        // Start: Button Close | Restore | Minimize 
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
        private void btnAddWorker_Click(object sender, RoutedEventArgs e)
        {

        }

        private void depType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void rankType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

    }
}
