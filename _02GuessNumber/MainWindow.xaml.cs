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

namespace _02GuessNumber
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int lives = 10;
        private int random = 0;
        public MainWindow()
        {
            InitializeComponent();
            Random rnd = new Random();
            random = rnd.Next() % 100;
        }

        private void txtInput_KeyDown(object sender, KeyEventArgs e)
        {
            if(lives == 0)
            {
                lblFrom.Content = "You ";
                lblTo.Content = "lose";
                return;
            }
            if(e.Key == Key.Enter)
            {
                lives--;
                int userGuessed = Int32.Parse(txtInput.Text);
                if ( userGuessed == random)
                {
                    lblFrom.Content = "You ";
                    lblTo.Content = "win";
                    return;
                }
                if(userGuessed < random)
                {
                    lblFrom.Content = userGuessed;
                }
                else
                {
                    lblTo.Content = userGuessed;
                }
                lblStatus.Content = "Remaining Lives: " + lives;
                if(lives <= 3)
                {
                    lblStatus.Foreground = new SolidColorBrush(Color.FromRgb(255, 0, 0));
                }
            }
        }
    }
}
