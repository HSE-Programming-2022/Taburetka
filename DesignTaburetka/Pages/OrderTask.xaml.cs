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

        }
    }
}
