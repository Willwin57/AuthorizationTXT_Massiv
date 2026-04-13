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

namespace WpfApp5
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void Button_Enter_Click(object sender, RoutedEventArgs e)
        {
            // Получаем данные из текстовых полей
            string log = LoginBox.Text;
            string pass = PassBox.Password;

            // Проверка на пустые поля
            if (string.IsNullOrWhiteSpace(log) || string.IsNullOrWhiteSpace(pass))
            {
                MessageBox.Show("Пожалуйста, заполните логин и пароль.");
                return;
            }

            // Создаем двумерный массив (матрицу) пользователей.
            // Левая колонка [0] - логин, правая колонка [1] - пароль.
            string[,] users = new string[,]
            {
                { "admin", "12345" },
                { "student", "qwerty" },
                { "darya", "password123" }
            };

            bool isAuthorized = false; // Флаг успешной авторизации

            // Цикл for для прохода по массиву.
            // users.GetLength(0) берет количество строк в нашем массиве (их тут 3)
            for (int i = 0; i < users.GetLength(0); i++)
            {
                // Вытаскиваем логин и пароль из текущей строки массива
                string arrayLogin = users[i, 0];
                string arrayPass = users[i, 1];

                // Сравниваем то, что ввел пользователь, с тем, что в массиве
                if (log == arrayLogin && pass == arrayPass)
                {
                    isAuthorized = true; // Совпало! Меняем флаг
                    break; // Дальше массив проверять нет смысла, выходим из цикла
                }
            }

            // Проверяем результат после цикла
            if (isAuthorized)
            {
                MessageBox.Show("Вы успешно вошли в систему!");

                // Переход на следующее окно:
                // SecondWindow nextWindow = new SecondWindow();
                // nextWindow.Show();
                // this.Close();
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль.");
            }
        }
    }
}
