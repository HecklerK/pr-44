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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace pr44
{
    /// <summary>
    /// Логика взаимодействия для regin.xaml
    /// </summary>
    public partial class regin : Page
    {
        public MainWindow mainWindow;
        public regin(MainWindow _mainWindow)
        {
            InitializeComponent();
            mainWindow = _mainWindow;
        }

        private void return_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.frame.Navigate(new login(mainWindow));
        }

        private void regin_Click(object sender, RoutedEventArgs e)
        {
            if (t_login.Text.Length > 0)
            {
                if (t_pass.Password.Length > 0)
                {
                    if (t_pass_r.Password.Length > 0)
                    {
                        string[] dataLogin = t_login.Text.Split('@');
                        if (dataLogin.Length == 2)
                        {
                            string[] data2Login = dataLogin[1].Split('.');
                            if (data2Login.Length == 2)
                            {
                                
                            }
                            else MessageBox.Show("Укажите логин в форме x@x.x");
                        }
                        else MessageBox.Show("Укажите логин в форме x@x.x");
                    }
                    else MessageBox.Show("Повторите пароль");
                }
                else MessageBox.Show("Введите пароль");
            }
            else MessageBox.Show("Введите логин");
        }
    }
}
