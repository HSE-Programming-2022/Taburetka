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
    /// Логика взаимодействия для Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public static int emp_id;

        public static string dep_name;

        public Login()
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

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnRestore_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Normal)
                WindowState = WindowState.Maximized;
            else
                WindowState = WindowState.Normal;
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
        // End: Button Close | Restore | Minimize


        // Тут должно быть много елифов для каждого типа работника
        private void btnLogIn_Click(object sender, RoutedEventArgs e)
        {
            var loginUser = loginText.Text;
            var passwordUser = password.Password;

            // Запрос для логина и пароля
            string queryString1 = $"select emp_id, login, password from EmpData where login = '{loginUser}' and password = '{passwordUser}'";

            // Запрос для департамента, имени, фамилии
            string queryString2 = $"select b.emp_name, b.emp_surname, c.dep_name from EmpData a inner join Employee b on a.emp_id = b.emp_id inner join Department c on b.emp_dep_id = c.dep_id where login = '{loginUser}' and password = '{passwordUser}'";

            // Запрос для должности
            string queryString3 = $"select c.rank_name from EmpData a inner join Employee b on a.emp_id = b.emp_id inner join EmployeeRank c on b.rank_id = c.rank_id where login = '{loginUser}' and password = '{passwordUser}'";

            // Запрос для имени
            //string queryString4 = $"select b.emp_name, b.emp_surname from EmpData a inner join Employee b on a.emp_id = b.emp_id where login = '{loginUser}' and password = '{passwordUser}'";


            DataTable table1 = WPFHelper.Select(queryString1);

            DataTable table2 = WPFHelper.Select(queryString2);

            DataTable table3 = WPFHelper.Select(queryString3);

            //DataTable table4 = WPFHelper.Select(queryString4);

            emp_id = int.Parse(table1.Rows[0]["emp_id"].ToString());

            dep_name = table2.Rows[0]["dep_name"].ToString();

            if (table1.Rows.Count == 1 & (table3.Rows[0]["rank_name"].ToString() == "Director" || table3.Rows[0]["rank_name"].ToString() == "Designer"))
            {
                AdminUslugi adminUslugi = new AdminUslugi();
                adminUslugi.UserFullName.Text = $"{table2.Rows[0]["emp_name"].ToString()}\n{table2.Rows[0]["emp_surname"].ToString()}";
                adminUslugi.Department.Text = $"Отдел: {table2.Rows[0]["dep_name"].ToString()}";
                adminUslugi.Position.Text = $"Должность: {table3.Rows[0]["rank_name"].ToString()}";
                adminUslugi.UserNameLetters.Text = $"{table2.Rows[0]["emp_name"].ToString().Substring(0, 1).ToUpper()}" + $"{table2.Rows[0]["emp_surname"].ToString().Substring(0, 1).ToUpper()}";
                //adminUslugi.UserFullName.Text = $"{table4.Rows[0]["emp_name"].ToString()}\n{table4.Rows[0]["emp_surname"].ToString()}";
                adminUslugi.Show();
                this.Close();
            }
            else if (table1.Rows.Count == 1 & table3.Rows[0]["rank_name"].ToString() == "Manager")
            {
                ManagerUslugi managerUslugi = new ManagerUslugi();
                managerUslugi.UserFullName.Text = $"{table2.Rows[0]["emp_name"].ToString()}\n{table2.Rows[0]["emp_surname"].ToString()}";
                managerUslugi.Department.Text = $"Отдел: {table2.Rows[0]["dep_name"].ToString()}";
                managerUslugi.Position.Text = $"Должность: {table3.Rows[0]["rank_name"].ToString()}";
                managerUslugi.UserNameLetters.Text = $"{table2.Rows[0]["emp_name"].ToString().Substring(0, 1).ToUpper()}" + $"{table2.Rows[0]["emp_surname"].ToString().Substring(0, 1).ToUpper()}";
                managerUslugi.Show();
                this.Close();
            }
            else if (table1.Rows.Count == 1 & table3.Rows[0]["rank_name"].ToString() == "Worker")
            {
                WorkerUslugi workerUslugi = new WorkerUslugi();
                workerUslugi.UserFullName.Text = $"{table2.Rows[0]["emp_name"].ToString()}\n{table2.Rows[0]["emp_surname"].ToString()}";
                workerUslugi.Department.Text = $"Отдел: {table2.Rows[0]["dep_name"].ToString()}";
                workerUslugi.Position.Text = $"Должность: {table3.Rows[0]["rank_name"].ToString()}";
                workerUslugi.UserNameLetters.Text = $"{table2.Rows[0]["emp_name"].ToString().Substring(0, 1).ToUpper()}" + $"{table2.Rows[0]["emp_surname"].ToString().Substring(0, 1).ToUpper()}";
                workerUslugi.Show();
                this.Close();
            }
            else if (loginText.Text.Length == 0 || password.Password.Length == 0)
            {
                MessageBox.Show("Вы не ввели все данные.");
                loginText.Focus();
            }
            //else if (loginText.Text == "admin" && password.Password == "123456")
            //{
            //    AdminUslugi _menuAdmin = new AdminUslugi();
            //    _menuAdmin.Show();
            //    this.Close();
            //}
            else
            {
                MessageBox.Show("Ошибка в веденных данных");
            }
        }
    }
}