using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Logika;

namespace Prezentacja.Model
{
    public class ModelBila : INotifyPropertyChanged
    {
        private int _x;
        private int _y;
        private List<Bila> _bilaList = new List<Bila>();

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public List<Bila> GetBilas() { return _bilaList; }

        public int X
        {
            get => _x;
            set
            {
                _x = value;
                OnPropertyChanged(nameof(X));
            }
        }

        public int Y
        {
            get => _y;
            set
            {
                _y = value;
                OnPropertyChanged(nameof(Y));
            }
        }

        public List<ModelBila> InitList(int size)
        {
            Bila temp = new Bila();
            List<ModelBila> model = new List<ModelBila>();
            for (int i = 0; i < size; i++)
            {
                _bilaList.Add(temp.GenerateBall(475, 325, 300, 150));  // ROZMIARY GDZIE MOZE SPAWNOWAC SIE BILA - TROCHE MNIEJSZE NIZ STOL
                model.Add(new ModelBila());
                model[i].X = (int)_bilaList[i].GetX();
                model[i].Y = (int)_bilaList[i].GetY();
            }
            return model;
        }

        public void UpdatePosition(List<ModelBila> balls)
        {
            Bila temp = new Bila();
            for (int i = 0; i < balls.Count; i++)
            {
                //temp = temp.MoveBall(_bilaList[i], 485, 280, 315, 115);  // TRZEBA UZALEZNIC ROZMIARY MAX I MIN OD ROZMIARU STOLU
                balls[i].X = (int)temp.GetX();
                balls[i].Y = (int)temp.GetY();
            }
        }

        public void KeepMoving(int size)
        {
            Bila temp = new Bila();
            for (int i = 0; i < size; i++)
            {
                //_bilaList[i].StartThread(_bilaList[i], 485, 280, 315, 115);
            }
        }
    }
}