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
    /// Логика взаимодействия для SecondWindow.xaml
    /// </summary>
    public partial class SecondWindow : Window
    {
        public SecondWindow()
        {
            InitializeComponent();
        }

        private void Translate_Click(object sender, RoutedEventArgs e)
        {
            // Две строки, где символы идут строго в одинаковом порядке по клавишам
            string eng = "`qwertyuiop[]asdfghjkl;'zxcvbnm,./~QWERTYUIOP{}ASDFGHJKL:\"ZXCVBNM<>?";
            string rus = "ёйцукенгшщзхъфывапролджэячсмитьбю.ЁЙЦУКЕНГШЩЗХЪФЫВАПРОЛДЖЭЯЧСМИТЬБЮ,";

            string text = InputBox.Text; // берем текст из верхнего поля
            string result = ""; // сюда будем собирать готовый текст

            // Запускаем цикл по каждой букве в тексте
            for (int i = 0; i < text.Length; i++)
            {
                char c = text[i]; // текущий символ

                int indexEng = eng.IndexOf(c); // ищем его в английской строке
                int indexRus = rus.IndexOf(c); // ищем его в русской строке

                if (indexEng != -1)
                {
                    // Если символ найден в английской строке, берем букву из русской под тем же номером
                    result += rus[indexEng];
                }
                else if (indexRus != -1)
                {
                    // Если найден в русской, берем из английской
                    result += eng[indexRus];
                }
                else
                {
                    // Если это пробел, цифра или знак вопроса, оставляем как есть
                    result += c;
                }
            }

            // Выводим результат в нижнее поле
            OutputBox.Text = result;
        }
    }
}

