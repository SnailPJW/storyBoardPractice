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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace storyBoard
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Point> points = null;
        List<Line> lines = null;
        List<Storyboard> boards = null;
        public MainWindow()
        {
            InitializeComponent();
            points = new List<Point>();
            lines = new List<Line>();
            boards = new List<Storyboard>();

            //points集合中 新增 7個point
            points.Add(new Point(0.499939, 48.6606));
            points.Add(new Point(2.42746, 45.1911));
            points.Add(new Point(5.8242, 38.2785));
            points.Add(new Point(6.31174, 38.4952));
            points.Add(new Point(8.01431, 39.2519));
            points.Add(new Point(8.79037, 48.8331));
            points.Add(new Point(10.0613, 50.9936));
            points.Add(new Point(12.5007, 54.7948));
            points.Add(new Point(14.79, 54.4133));
            points.Add(new Point(24.8544, 43.5739));
            points.Add(new Point(25.3094, 43.7445));
            points.Add(new Point(25.8327, 43.9408));
            points.Add(new Point(27.7953, 47.7509));
            points.Add(new Point(28.8089, 47.2441));
            points.Add(new Point(30.3381, 46.4795));
            points.Add(new Point(34.1497, 41.6631));
            points.Add(new Point(34.5582, 41.7448));
            points.Add(new Point(34.8951, 41.8122));
            points.Add(new Point(38.1494, 47.8282));
            points.Add(new Point(39.8075, 47.994));
            points.Add(new Point(43.0506, 48.3183));
            points.Add(new Point(45.0782, 44.0683));
            points.Add(new Point(48.0565, 42.7447));
            points.Add(new Point(51.3824, 41.2665));
            points.Add(new Point(55.0088, 44.9259));
            points.Add(new Point(58.5552, 45.7443));
            points.Add(new Point(61.3347, 46.3857));
            points.Add(new Point(68.9706, 45.4943));
            points.Add(new Point(68.9706, 45.4943));
            points.Add(new Point(76.1363, 26.1634));
            points.Add(new Point(81.3024, 78.6568));
            points.Add(new Point(88.6348, 0.4999));
            points.Add(new Point(94.634, 64.3253));
            points.Add(new Point(105.251, 33.0223));
            points.Add(new Point(105.549, 33.2458));
            points.Add(new Point(106.146, 33.693));
            points.Add(new Point(112.871, 46.313));
            points.Add(new Point(117.298, 46.9941));
            points.Add(new Point(121.597, 47.6555));
            points.Add(new Point(125.611, 44.3467));
            points.Add(new Point(129.546, 42.4947));
            points.Add(new Point(131.287, 41.6756));
            points.Add(new Point(133.221, 40.1366));
            points.Add(new Point(135.046, 40.7449));
            points.Add(new Point(137.558, 41.5823));
            points.Add(new Point(137.558, 41.5823));
            points.Add(new Point(139.66, 43.731));
            points.Add(new Point(142.295, 43.994));
            points.Add(new Point(148.264, 44.5914));
            points.Add(new Point(154.41, 42.8179));
            points.Add(new Point(162.387, 44.4133));
            points.Add(new Point(169.979, 45.9369));
            points.Add(new Point(173.59, 44.7444));
            points.Add(new Point(180.217, 44.7444));

            SetupLines();
            DrawLines();
            //Line line = new Line();
            ////Canvas canvas = new Canvas();
            ////canvas.Height = this.Height;
            ////canvas.Width = this.Width;
            ////this.AddChild(canvas);
            //canvas1.Children.Add(line);
            //line.Stroke = Brushes.Red;
            //line.StrokeThickness = 2;
            //line.X1 = 100;
            //line.Y1 = 100;
            //Storyboard sb = new Storyboard();
            //DoubleAnimation da = new DoubleAnimation(line.Y2, 500, new Duration(new TimeSpan(0, 0, 1)));
            //DoubleAnimation da1 = new DoubleAnimation(line.X2, 150, new Duration(new TimeSpan(0, 0, 1)));
            //Storyboard.SetTargetProperty(da, new PropertyPath("(Line.Y2)"));
            //Storyboard.SetTargetProperty(da1, new PropertyPath("(Line.X2)"));
            //sb.Children.Add(da);
            //sb.Children.Add(da1);
            //line.BeginStoryboard(sb);
        }
        public void SetupLines()
        {
            int speed = 50;//值越大速度越慢
            lines.Add(new Line());
            boards.Add(new Storyboard());

            for (int i = 0; i < points.Count - 1; i++)
            {
                lines.Add(new Line());
                boards.Add(new Storyboard());

                canvas1.Children.Add(lines[i]);
                lines[i].Stroke = Brushes.Red;
                lines[i].StrokeThickness = 1;

                lines[i].X1 = points[i].X;
                lines[i].Y1 = points[i].Y;
                lines[i].X2 = points[i].X;
                lines[i].Y2 = points[i].Y;

                DoubleAnimation da = new DoubleAnimation(points[i].X, points[i + 1].X, new Duration(new TimeSpan(0, 0, 0, 0, speed)));
                DoubleAnimation da1 = new DoubleAnimation(points[i].Y, points[i + 1].Y, new Duration(new TimeSpan(0, 0, 0, 0, speed)));

                Storyboard.SetTargetProperty(da, new PropertyPath("(Line.X2)"));
                Storyboard.SetTargetProperty(da1, new PropertyPath("(Line.Y2)"));

                boards[i].Children.Add(da);
                boards[i].Children.Add(da1);

                da.BeginTime = new TimeSpan(0, 0, 0, 0, i * speed);
                da1.BeginTime = new TimeSpan(0, 0, 0, 0, i * speed);

                //lines.Add(new Line());
                //boards.Add(new Storyboard());
            }
        }

        public void DrawLines()
        {
            for (int i = 0; i < boards.Count - 1; i++)
            {
                lines[i].BeginStoryboard(boards[i]);
            }
        }
    }
}
