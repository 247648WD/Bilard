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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(30);
            timer.Tick += timerTicker;
            timer.Start();
        }

        private void timerTicker(object sender, EventArgs e)
        {
            Canvas.SetLeft(bila, Canvas.GetLeft(bila) + vx);
            if (Canvas.GetLeft(bila) == boundariesRight || Canvas.GetLeft(bila) == boundariesLeft)
            {
                vx *= -1;
            }
        }

    }
}