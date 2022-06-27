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
    /// Логика взаимодействия для WindowAddOrder.xaml
    /// </summary>
    public partial class WindowAddOrder : Window
    {
        public string NameOrder
        {
            get { return OrderName.Text; }
        }
        public string ClientID
        {
            get { return Client_id.Text; }
        }
        public string TimeSuppose
        {
            get { return SupposeTime.Text; }
        }
        public string ClientComment
        {
            get { return Comment.Text; }
        }
        public string EmpId
        {
            get { return emp_id.Text; }
        }
        public int OrderTypeId;

        public string TypeEmergency
        {
            get
            {
                return emergencyType.Text;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void orderType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string type = ((ComboBoxItem)OrderType.SelectedItem).Content.ToString();

            if (type.ToString() == "Draft")
            {
                OrderTypeId = 1;
            }
            else
            {
                OrderTypeId = 2;
            }
        }

        private void emergencyType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        public WindowAddOrder()
        {
            InitializeComponent();
        }
    }
}
