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
    /// Логика взаимодействия для Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();
        }

        private void btnCalc_Click(object sender, RoutedEventArgs e)
        {
            string sign = txtSign.Text;

            if (double.TryParse(txtNum1.Text, out double num1) && double.TryParse(txtNum2.Text, out double num2))
            {
                double result = 0;

                switch (sign)
                {
                    case "+": result = num1 + num2; break;
                    case "-": result = num1 - num2; break;
                    case "*": result = num1 * num2; break;
                    case "/":
                        if (num2 == 0)
                        {
                            MessageBox.Show("На ноль делить нельзя!", "Ошибка");
                            return;
                        }
                        result = num1 / num2;
                        break;
                    default:
                        MessageBox.Show("Неизвестный знак операции!", "Ошибка");
                        return;
                }

                // ВОТ ГЛАВНОЕ ИЗМЕНЕНИЕ: Выводим результат во всплывающее окно
                MessageBox.Show("Результат: " + result.ToString(), "Ответ");
            }
            else
            {
                MessageBox.Show("Пожалуйста, введите корректные числа.", "Ошибка ввода");
            }
        }
    }
}
