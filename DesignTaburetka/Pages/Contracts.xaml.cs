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
    /// Логика взаимодействия для Contracts.xaml
    /// </summary>
    public partial class Contracts : Page
    {
        public Contracts()
        {
            InitializeComponent();
            DataTable DTOrderProject = WPFHelper.Select("SELECT * FROM [dbo].[OrderTask] inner join [dbo].[OrderProject] " +
                "on [dbo].[OrderTask].order_id = [dbo].[OrderProject].order_id"
                );
            ProjectData.DataContext = DTOrderProject;

            DataTable DTOrderService = WPFHelper.Select("SELECT * FROM [dbo].[OrderTask] inner join [dbo].[OrderService] " +
                "on [dbo].[OrderTask].order_id = [dbo].[OrderService].order_id"
                );
            ServiceData.DataContext = DTOrderService;

        }

        private void BtnAddProject_Click(object sender, RoutedEventArgs e)
        {

        }
        private void BtnDeleteProject_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnDeleteService_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnAddService_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
