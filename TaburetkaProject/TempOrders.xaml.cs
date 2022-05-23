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

namespace TaburetkaProject
{
    /// <summary>
    /// Логика взаимодействия для Page2.xaml
    /// </summary>
    public partial class TempOrders : Page
    {

        public TempOrders()
        {
            InitializeComponent();
            DataTable DTTempOrders = WPFHelper.Select("SELECT * FROM [dbo].[TempOrder]"); // получаем данные из таблицы
            DG1.DataContext = DTTempOrders;
        }

        private void btnView_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataRowView dataRowView = (DataRowView)((Button)e.Source).DataContext;
                String ProductName = dataRowView[1].ToString();
                String ProductDescription = dataRowView[2].ToString();
                MessageBox.Show("You Clicked : " +  "\nDescription : ");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
