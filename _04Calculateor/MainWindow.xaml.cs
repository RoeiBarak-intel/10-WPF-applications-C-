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

namespace _04Calculateor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void OnNumberButtonClick(object sender, RoutedEventArgs e)
        {
            Button clicked = (Button)sender;
            txbInput.Text = txbInput.Text + clicked.Content;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string input = txbInput.Text;
            int number = 0;
            int firstNumber = 0;
            char operation = ' ';
            for (int i = 0; i < input.Length; i++)
            {
                if ('0' <= input[i] && input[i] <= '9')
                {
                    number = number * 10;
                    number = number + (input[i] - '0');
                }
                else if (input[i] == '+' ||
                    input[i] == '-' ||
                    input[i] == '/' ||
                    input[i] == '*')
                {
                    switch (operation)
                    {
                        case '+':
                            number = firstNumber + number;
                            break;
                        case '-':
                            number = firstNumber - number;
                            break;
                        case '/':
                            number = firstNumber / number;
                            break;
                        case '*':
                            number = firstNumber * number;
                            break;
                    }
                    operation = input[i];
                    firstNumber = number;
                    number = 0;
                }
            }
            switch (operation)
            {
                case '+':
                    number = firstNumber + number;
                    break;
                case '-':
                    number = firstNumber - number;
                    break;
                case '*':
                    number = firstNumber * number;
                    break;
                case '/':
                    number = firstNumber / number;
                    break;
            }
            txbInput.Text = number.ToString();
            }
        
    }
}
