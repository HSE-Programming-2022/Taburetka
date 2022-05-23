using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace TaburetkaProject
{
    public class WPFHelper
    {
        public static DataTable Select(string selectSQL) // функция подключения к базе данных и обработка запросов
        {
            DataTable dataTable = new DataTable("dataBase");                // создаём таблицу в приложении
                                                                            // подключаемся к базе данных
            SqlConnection sqlConnection = new SqlConnection("server=DESKTOP-86BHT2G\\SQLEXPRESS;Trusted_Connection=Yes;DataBase=QQMber;");
            sqlConnection.Open();                                           // открываем базу данных
            SqlCommand sqlCommand = sqlConnection.CreateCommand();          // создаём команду
            sqlCommand.CommandText = selectSQL;                             // присваиваем команде текст
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand); // создаём обработчик
            sqlDataAdapter.Fill(dataTable);
            sqlConnection.Close();
            return dataTable;
        }

        public static void Insert(string insertSQL)
        {
            SqlConnection sqlConnection = new SqlConnection("server=DESKTOP-86BHT2G\\SQLEXPRESS;Trusted_Connection=Yes;DataBase=QQMber;");
            sqlConnection.Open();
            SqlCommand sqlCommand = sqlConnection.CreateCommand();          // создаём команду
            sqlCommand.CommandText = insertSQL;                             // присваиваем команде текст
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();

        }
    }
}
