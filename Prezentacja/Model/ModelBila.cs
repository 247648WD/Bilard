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
        private static List<Bila> _bilaList = new List<Bila>();

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public static List<Bila> GetBilas() { return _bilaList; }

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
        public ModelBila(int x, int y)
        {
            X = x;
            Y = y;
        }

        public static List<ModelBila> GetBalls()
        {
            List<ModelBila> model = new List<ModelBila>();
            List<Bila> balls = Bila.GenerateBalls(10, 475, 325, 300, 150);
            for (int i = 0; i < balls.Count; i++)
            {
                model.Add(new ModelBila((int)balls[i].GetX(), (int)balls[i].GetY()));
                // potem usunac konstruktor i bezposrednio do wlasciwosci X Y przekazac wartosci a nie przy tworzeniu noewj modelBila
            }
            return model;
        }

        public static void Init(List<ModelBila> bilas)
        {
            for (int i = 0; i < bilas.Count; i++)
            {
                _bilaList.Add(new Bila((double)bilas[i].X, (double)bilas[i].Y, 0, 0, 5, 0));
            }
        }

        public static void UpdatePosition(List<ModelBila> bilas, List<Bila> balls)
        {   balls = Bila.MoveBalls(balls, 485, 280, 315, 115);
            for(int i = 0;i < bilas.Count; i++)
            {
                bilas[i].X = (int)balls[i].GetX();
            }
        }
    }
}
