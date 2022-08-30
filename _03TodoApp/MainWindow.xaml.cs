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

namespace _03TodoApp
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
        private void addToListBox(string item)
        {
            lsbTasks.Items.Add(item);
            txbInput.Text = "";
            btnAdd.IsEnabled = false;
        }
        private void txbInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (txbInput.Text.Length == 0)
            {
                btnAdd.IsEnabled = false;
            }
            else
            {
                btnAdd.IsEnabled = true;
                if (e.Key == Key.Enter)
                {
                    addToListBox(txbInput.Text);
                }
            }

        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            addToListBox(txbInput.Text);

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            lsbTasks.Items.Remove(lsbTasks.SelectedItem);
            btnDelete.IsEnabled = false;
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnDelete.IsEnabled = true;
        }
    }
}
