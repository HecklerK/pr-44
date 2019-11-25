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
                                if (t_pass.Password.Length >= 6){
	                               bool en = true; // английская раскладка
	                               bool symbol = false; // символ
	                               bool number = false; // цифра
                                    for(int i=0; i<t_pass.Password.Length; i ++){
		                            if (t_pass.Password[i] >= 'А' && t_pass.Password[i] <= 'Я') en = false; // если русская раскладка
		                            if (t_pass.Password[i] >= '0' && t_pass.Password[i] <= '9') number = true; // если цифры
		                            if (t_pass.Password[i] == '_' || t_pass.Password[i] == '-' || t_pass.Password[i] == '!') symbol = true;}
                                    if (!en)
                                        MessageBox.Show("Доступна только английская раскладка"); // выводим сообщение
                                    else if (!symbol)
                                        MessageBox.Show("Добавьте один из следующих символов: _ - !"); // выводим сообщение
                                    else if (!number)
                                        MessageBox.Show("Добавьте хотя бы одну цифру"); // выводим сообщение
                                    if (en && symbol && number) // проверяем соответствие
                                    {
                                        if (t_pass.Password == t_pass_r.Password) // проверка на совпадение паролей
                                        {
                                            MessageBox.Show("Пользователь зарегистрирован");
                                            DataTable dt_user = mainWindow.Select("INSERT INTO [dbo].[User] VALUES ('" + t_login.Text + "', '" + t_pass.Password + "', 'test', 'test', 'test', 'test')");
                                        }
                                        else MessageBox.Show("Пароли не совподают");
                                    }
                                }
                                else MessageBox.Show("пароль слишком короткий, минимум 6 символов");
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
