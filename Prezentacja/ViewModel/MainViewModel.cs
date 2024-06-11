using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Logika;
using Prezentacja.Model;

namespace Prezentacja.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private ObserwatorKolizji obs;
        private Bila _bila = new Bila();
        private Stol _stockPrototyp = new Stol();
        private string _quantityValue;
        public string QuantityValue
        {
            get { return _quantityValue; }
            set
            {
                _quantityValue = value;
                OnPropertyChanged(nameof(QuantityValue));
            }
        }

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
            set
            {
                _width = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Bila> Balls { get; set; } = new ObservableCollection<Bila>();

        public MainViewModel()
        {
            GenerateBallsCommand = new RelayCommand(GenerateBalls);
            _stockPrototyp = (Stol)_stockPrototyp.Copy(230, 220);
            Width = _stockPrototyp._width;
            Height = _stockPrototyp._height;
        }

        private void GenerateBalls()  // METODA ONCLICK DLA PRZYCISKU
        {
            obs = new ObserwatorKolizji();
            Balls.Clear();
            for (int i = 0; i < Int32.Parse(QuantityValue); i++)
            {
                Bila temp = _bila.GenerateBall(475, 325, 300, 150);
                Balls.Add(temp);
                obs.AddBilas(temp);
            }

        }

        public ICommand GenerateBallsCommand { get; }  // KOMENDA DLA PRZYCISKU 

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }


}