using System;
using System.Data;
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

namespace pr44
{
    /// <summary>
    /// Логика взаимодействия для login.xaml
    /// </summary>
    public partial class login : Page
    {
        public MainWindow mainWindow;

        public login(MainWindow _mainWindow)
        {
            InitializeComponent();
            mainWindow = _mainWindow;
        }

        private void enter_Click(object sender, RoutedEventArgs e)
        {
            if (t_login.Text.Length > 0)
            {
                if (t_pass.Password.Length > 0)
                {
                    DataTable dt_user = mainWindow.Select("SELECT * FROM [dbo].[User] WHERE [Login] = '" + t_login.Text + "' AND [Password] = '" + t_pass.Password + "'");
                    if (dt_user.Rows.Count > 0) MessageBox.Show("Привет " + t_login.Text);
                    else MessageBox.Show("Пользователь " + t_login.Text + " не найден");
                }
                else MessageBox.Show("Введите пароль");
            }
            else MessageBox.Show("Введите логин");
        }

        private void regin_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.frame.Navigate(new regin(mainWindow));
        }
    }
}
