using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;
using Dane;

namespace Prezentacja.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly BallService _ballService;
        private List<Ball> _balls;
        private StolPrototyp _stockPrototyp = new StolPrototyp();

        private int _height;
        public int Height
        {
            get { return _height; }
            set
            {
                _height = value;
                OnPropertyChanged();
            }
        }
        private int _width;
        public int Width
        {
            get { return _width; }
            set {
                _width = value;
                OnPropertyChanged();
            }
        }

        public List<Ball> Balls
        {
            get => _balls;
            set
            {
                _balls = value;
                OnPropertyChanged(nameof(Balls));
            }
        }


        public MainViewModel(BallService ballService)
        {
            _ballService = ballService;
            GenerateBallsCommand = new RelayCommand(GenerateBalls);
            _stockPrototyp = _stockPrototyp.Copy(230, 220);
            _width = _stockPrototyp._width;
            _height = _stockPrototyp._height;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            _ballService.MoveBalls(Balls, 485, 280, 315, 115);
        }

        private void GenerateBalls()
        {
            Balls = _ballService.GenerateBalls(10, 475, 325, 300, 150);

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(30);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        public ICommand GenerateBallsCommand { get; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName]string propertyName= null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }


}
