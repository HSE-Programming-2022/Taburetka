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
            DataTable DTOrderProject = WPFHelper.Select("SELECT a.order_id, a.project_name, d.client_name, a.created_at, a.suppose_days, a.comment, c.emp_name, c.emp_surname, order_emergency, " +
                "b.design_link, b.measures_link FROM OrderTask a inner join OrderProject b on a.order_id = b.order_id inner join Employee c on a.added_by = c.emp_id inner join Client d on a.client_id = d.client_id" 
                );
            ProjectData.DataContext = DTOrderProject;

            DataTable DTOrderService = WPFHelper.Select("SELECT a.order_id, a.project_name, d.client_name, a.created_at, a.suppose_days, a.comment, c.emp_name, c.emp_surname, a.order_emergency " +
                "FROM OrderTask a inner join OrderService b " +
                "on a.order_id = b.order_id inner join Employee c on a.added_by = c.emp_id inner join Client d on a.client_id = d.client_id"
                );
            ServiceData.DataContext = DTOrderService;

            //DataTable DTOrderTask = WPFHelper.Select("SELECT a.order_id, a.projcet_name, c.client_name, a.created_at, a.suppose_days, " +
            //                                         "a.comment, b.emp_name, b.emp_surname FROM OrderTask a inner join Employee b on a.added_by = b.emp_id inner join Client c on a.client_id = c.client_id");
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
