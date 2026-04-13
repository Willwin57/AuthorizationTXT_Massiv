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
using System.IO;

namespace WpfApp5
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // Событие нажатия на кнопку "Войти"
        private void Button_Enter_Click(object sender, RoutedEventArgs e)
        {
            // Получаем данные из текстовых полей
            string log = LoginBox.Text;
            string pass = PassBox.Password; // Обрати внимание: у PasswordBox свойство называется Password, а не Text

            // Простая проверка: не пустые ли поля
            if (string.IsNullOrWhiteSpace(log) || string.IsNullOrWhiteSpace(pass))
            {
                MessageBox.Show("Пожалуйста, заполните логин и пароль.");
                return;
            }

            try
            {
                // Проверяем, существует ли файл вообще
                if (!File.Exists("users.txt"))
                {
                    MessageBox.Show("Системная ошибка: файл users.txt не найден.");
                    return;
                }

                // Считываем все строки из файла
                string[] lines = File.ReadAllLines("users.txt");

                // Запускаем цикл по каждой строке
                foreach (string line in lines)
                {
                    // Разбиваем строку на части по пробелу. 
                    // Например, строку "admin 123" разобьет на массив: data[0]="admin", data[1]="123"
                    string[] data = line.Split(' ');

                    // Проверяем, что в строке точно есть логин и пароль (2 элемента)
                    if (data.Length == 2)
                    {
                        string fileLogin = data[0];
                        string filePass = data[1];

                        // Сравниваем введенные данные с данными из файла
                        if (log == fileLogin && pass == filePass)
                        {
                            MessageBox.Show("Вы успешно вошли в систему!");

                            // Здесь обычно открывают следующее окно программы
                            // SecondWindow nextWindow = new SecondWindow();
                            // nextWindow.Show();
                            // this.Close(); 

                            return; // Выходим из метода, так как пользователь найден
                        }
                    }
                }

                // Если цикл закончился, а return не сработал — значит совпадений не было
                MessageBox.Show("Неверный логин или пароль.");
            }
            catch (Exception ex)
            {
                // Если файл занят другой программой или поврежден
                MessageBox.Show("Произошла ошибка при чтении данных: " + ex.Message);
            }
        }
    }
}
