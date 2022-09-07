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

namespace _08Graph
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static double x = 0 , y = 0;
        public static double originX = 0 , originY = 0;

        public static Boolean initialized = false;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void DrawLine(double x1, double y1, double x2, double y2)
        {
            Line ln = new Line();
            ln.X1 = x1;
            ln.Y1 = y1;
            ln.X2 = x2;
            ln.Y2 = y2;
            ln.StrokeThickness = 3;
            ln.Stroke = Brushes.Red;
            cnv.Children.Add(ln);
        }
        private void AddLabel(double x, double y, string content)
        {
            Label lb = new Label();
            lb.Content = content;
            lb.Margin = new Thickness(x, y, this.Width - x - 50, this.Height - y - 100);
            lb.Foreground = Brushes.White;
            lb.FontSize = 10;
            grd.Children.Add(lb);

        }
        private void cnv_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (initialized)
            {
                double tempX = e.GetPosition(cnv).X;
                double tempY = e.GetPosition(cnv).Y;
                DrawLine(x, y, tempX, tempY);
                DrawLine(originX, y, originX, tempY);
                DrawLine(x, originY, tempX, originY);
                AddLabel(tempX, originY + 10, tempX.ToString());
                double temp = cnv.Height - tempY - originY;
                AddLabel(originX - 50, tempY, tempY.ToString());
                x = tempX;
                y = tempY;
            }   
            else
            {
                initialized = true;
                x = e.GetPosition(cnv).X;
                y = e.GetPosition(cnv).Y;
                originX = x;
                originY = y;
            }
        }
    }
}
