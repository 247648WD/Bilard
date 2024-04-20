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

        private int boundariesRight = 420;
        private int boundariesLeft = -215;
        private int vx = 5;
        private List<Ellipse> ellipseList = new List<Ellipse>();
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(30);
            timer.Tick += timerTicker;
            timer.Start();
        }

        private void timerTicker(object sender, EventArgs e)
        {
            for (int i = 0; i < ellipseList.Count; i++)
            {
                double left = Canvas.GetLeft(ellipseList[i]);
                Canvas.SetLeft(ellipseList[i], left + vx);

                // Sprawdź, czy bila dotarła do granic obszaru zielonego
                if (left <= boundariesLeft || left + ellipseList[i].Width >= boundariesRight)
                {
                    vx *= -1;
                }
            }
        }
        private void add_bila(object sender, RoutedEventArgs e)
        {
            // Pobierz wymiary obszaru zielonego
            double greenAreaWidth = 700;
            double greenAreaHeight = 350;

            // Oblicz granice obszaru zielonego
            double leftBoundary = 30;
            double topBoundary = 10;
            double rightBoundary = leftBoundary + greenAreaWidth;
            double bottomBoundary = topBoundary + greenAreaHeight;

            // Tworzenie nowej elipsy
            Ellipse ellipse = new Ellipse();
            ellipse.Width = 63;
            ellipse.Height = 59;
            ellipse.Fill = Brushes.Beige;
            ellipse.Stroke = Brushes.Black;

            // Ustawienie losowej pozycji dla elipsy w obrębie obszaru zielonego
            Random random = new Random();
            double randomLeft = random.NextDouble() * (rightBoundary - leftBoundary) + leftBoundary;
            double randomTop = random.NextDouble() * (bottomBoundary - topBoundary) + topBoundary;
            Canvas.SetLeft(ellipse, randomLeft);
            Canvas.SetTop(ellipse, randomTop);
            ellipseList.Add(ellipse);
            // Dodanie elipsy do Canvas
            canvas.Children.Add(ellipse);
        }

    }
}