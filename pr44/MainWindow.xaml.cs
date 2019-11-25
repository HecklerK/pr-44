using System;
using System.Data;
using System.Data.SqlClient;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Diagnostics;

namespace pr44
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            OpenPage(pages.login);
        }

        public enum pages
        {
            login,
            regin
        }

        void OpenPage(pages pages)
        {
            if (pages == pages.login) frame.Navigate(new login(this));
            else if (pages == pages.regin) frame.Navigate(new regin(this));
        }

        public DataTable Select(string selectSQL)
        {
            DataTable dataTable = new DataTable("dataBase");
            SqlConnection sqlConnection = new SqlConnection("server=KB37-122-C11\\SQLEXPRESS; Trusted_Connection=Yes; DataBase=AviaProm");
            sqlConnection.Open();
            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandText = selectSQL;
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            sqlDataAdapter.Fill(dataTable);
            return dataTable;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string path = "export.txt";
            StreamWriter sw = new StreamWriter(path);
            DataTable dt = Select("SELECT * FROM [dbo].[User]");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                sw.WriteLine("LOGIN: " + dt.Rows[i][0].ToString());
                sw.WriteLine("PASWORD: " + dt.Rows[i][1].ToString());
            }
            sw.Close();
            Process.Start("notepad.exe", path);
        }
    }
}
