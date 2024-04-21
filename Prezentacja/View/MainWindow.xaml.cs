using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Prezentacja
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

        private int boundariesRight = 680;
        private int boundariesLeft = 30;
        private int boundariesTop = 70;
        private int boundariesBottom = 365;
        private int vx = 5;
        private List<Ellipse> ellipseList = new List<Ellipse>();
        private List<int> velos = new List<int>();
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(30);
            timer.Tick += timerTicker;
            timer.Start();
        }

        private void timerTicker(object sender, EventArgs e)
        {
            for (int j = 0; j < ellipseList.Count; j++)
            {
                velos.Add(vx);
            }

            for (int i = 0; i < ellipseList.Count; i++)
            {
                Canvas.SetLeft(ellipseList[i], Canvas.GetLeft(ellipseList[i]) + velos[i]);
                Canvas.SetTop(ellipseList[i], Canvas.GetTop(ellipseList[i]) + velos[i]);

                if ((Canvas.GetLeft(ellipseList[i]) >= boundariesRight || Canvas.GetLeft(ellipseList[i]) <= boundariesLeft) || (Canvas.GetTop(ellipseList[i]) >= boundariesBottom || Canvas.GetTop(ellipseList[i]) <= boundariesTop))
                {
                    velos[i] *= -1;
                }
            }
        }
        private void add_bila(object sender, RoutedEventArgs e)
        {
            
            double greenAreaWidth = 700;
            double greenAreaHeight = 350;

            
            double leftBoundary = 30;
            double topBoundary = 10;
            double rightBoundary = leftBoundary + greenAreaWidth;
            double bottomBoundary = topBoundary + greenAreaHeight;

            
            Ellipse ellipse = new Ellipse();
            ellipse.Width = 50;
            ellipse.Height = 50;
            ellipse.Fill = Brushes.Black;
            ellipse.Stroke = Brushes.Black;

            
            
            Random random = new Random();
            int randomLeft = random.Next(40, 670);
            int randomTop = random.Next(60, 320);
            Canvas.SetLeft(ellipse, randomLeft);
            Canvas.SetTop(ellipse, randomTop);
            ellipseList.Add(ellipse);
            // Dodanie elipsy do Canvas
            canvas.Children.Add(ellipse);
        }

    }
}