using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignTaburetka.Helpers
{
    internal class WPFHelper
    {
        public static DataTable Select(string selectSQL) // функция подключения к базе данных и обработка запросов
        {
            DataTable dataTable = new DataTable("dataBase");                // создаём таблицу в приложении
                                                                            // подключаемся к базе данных
            SqlConnection sqlConnection = new SqlConnection(@"Server=34.174.111.94;Database=testProject;User ID=sqlserver;Password=@dm1n@dm1n");
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
            SqlConnection sqlConnection = new SqlConnection(@"Server=34.174.111.94;Database=testProject;User ID=sqlserver;Password=@dm1n@dm1n");

            sqlConnection.Open();
            SqlCommand sqlCommand = sqlConnection.CreateCommand();          // создаём команду
            sqlCommand.CommandText = insertSQL;                             // присваиваем команде текст
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();

        }
        public static void Delete(string deleteSQL)
        {
            SqlConnection sqlConnection = new SqlConnection(@"Server=34.174.111.94;Database=testProject;User ID=sqlserver;Password=@dm1n@dm1n");

            sqlConnection.Open();
            SqlCommand sqlCommand = sqlConnection.CreateCommand();          // создаём команду
            sqlCommand.CommandText = deleteSQL;                             // присваиваем команде текст
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();

        }
    }
}
