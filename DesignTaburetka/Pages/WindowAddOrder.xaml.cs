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

        public string TypeEmergency;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void orderType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string ordertype = ((ComboBoxItem)OrderType.SelectedItem).Content.ToString();

            if (ordertype.ToString() == "Draft")
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
            TypeEmergency = ((ComboBoxItem)emergencyType.SelectedItem).Content.ToString();
        }

        public WindowAddOrder()
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

        private void lblNote_MouseDown(object sender, MouseButtonEventArgs e)
        {
            OrderName.Focus();
            Client_id.Focus();
            SupposeTime.Focus();
            Comment.Focus();
            emp_id.Focus();
            OrderType.Focus();
            emergencyType.Focus();
        }

        private void txtNote_TextChanged_OrderName(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(OrderName.Text) && OrderName.Text.Length > 0)
            {
                TxtBlockNameOrder.Visibility = Visibility.Collapsed;
            }
            else
            {
                TxtBlockNameOrder.Visibility = Visibility.Visible;
            }
        }

        private void txtNote_TextChanged_Client_id(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(Client_id.Text) && Client_id.Text.Length > 0)
            {
                TxtBlockClientID.Visibility = Visibility.Collapsed;
            }
            else
            {
                TxtBlockClientID.Visibility = Visibility.Visible;
            }
        }

        private void txtNote_TextChanged_SupposeTime(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(SupposeTime.Text) && SupposeTime.Text.Length > 0)
            {
                TxtBlockSupposeTime.Visibility = Visibility.Collapsed;
            }
            else
            {
                TxtBlockSupposeTime.Visibility = Visibility.Visible;
            }
        }

        private void txtNote_TextChanged_Comment(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(Comment.Text) && Comment.Text.Length > 0)
            {
                TxtBlockComment.Visibility = Visibility.Collapsed;
            }
            else
            {
                TxtBlockComment.Visibility = Visibility.Visible;
            }
        }

        private void txtNote_TextChanged_emp_id(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(emp_id.Text) && emp_id.Text.Length > 0)
            {
                TxtBlockEmp_id.Visibility = Visibility.Collapsed;
            }
            else
            {
                TxtBlockEmp_id.Visibility = Visibility.Visible;
            }
        }

    }
}
