using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesignTaburetka.Helpers
{
    internal class WPFHelper
    {
        public static DataTable Select(string selectSQL) // функция подключения к базе данных и обработка запросов
        {
            DataTable dataTable = new DataTable("dataBase");                // создаём таблицу в приложении
            try
            {
                SqlConnection DBConnection = new SqlConnection(@"Server=34.174.111.94;Database=testProject;User ID=sqlserver;Password=@dm1n@dm1n");
                DBConnection.Open();                                           // открываем базу данных
                SqlCommand DbCommand = DBConnection.CreateCommand();          // создаём команду
                DbCommand.CommandText = selectSQL;                             // присваиваем команде текст
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(DbCommand); // создаём обработчик
                sqlDataAdapter.Fill(dataTable);
                DBConnection.Close();
            }
            catch
            {
                string message = "Невозможно подключиться к базе данных.\n" +
                    "Проверьте работоспособность сервера.";
                MessageBox.Show(message);
            }
            
            return dataTable;
        }

        public static void DMLSQL(string SQLCommand)
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(@"Server=34.174.111.94;Database=testProject;User ID=sqlserver;Password=@dm1n@dm1n");

                sqlConnection.Open();
                SqlCommand sqlCommand = sqlConnection.CreateCommand();          // создаём команду
                sqlCommand.CommandText = SQLCommand;                             // присваиваем команде текст
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
            catch{
                string message = "Не удалось обновить данные или подключиться к базе данных. \n" +
                   "Проверьте корректность введенных данных и работоспособность базы данных на сервере\n" +
                   "Текст SQL-запроса, вызвашего ошибку:\n" + SQLCommand;
                MessageBox.Show(message);
            }
            

        }

        public static void Update(string updateSQL) { 
        }
    }
}
