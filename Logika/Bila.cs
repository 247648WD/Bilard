using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Dane;

namespace Logika
{
    public class Bila : BilaPrototyp, INotifyPropertyChanged
    {
        private Thread thread;
        private static readonly object SyncObject = new object();
        private int _x;
        private int _y;

        public int X
        {
            get => _x;
            set
            {
                _x = value;
                OnPropertyChanged(nameof(X));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
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
        public double GetX() { return X; }
        public double GetY() { return Y; }
        public double GetMass() { return mass; }
        public int GetSize() { return size; }
        public double GetVecX() { return vecX; }
        public double GetVecY() { return vecY; }

        public double GetVel() { return vel; }
        public int GetDir() { return dir; }

        public Bila() { }

        public Bila(double posX, double posY, double mass, int size, double vecX, double vecY)
        {
            this.X = (int)posX;
            this.Y = (int)posY;
            this.mass = mass;
            this.size = size;
            this.vecX = vecX;
            this.vecY = vecY;
            //this.vel = vel;
            //this.dir = dir;
            this.thread = new Thread(() => Move(485, 280, 295, 100));
            thread.Start();
        }

        public void SetX(double x) { this.X = (int)x; }
        public void SetY(double y) { this.Y = (int)y; }
        private void SetMass(double mass) { this.mass = mass; }
        private void SetSize(int size) { this.size = size; }
        private void SetVecX(double vecX) { this.vecX = vecX; }
        private void SetVecY(double vecY) { this.vecY = vecY; }

        private void SetVel(double vel) { this.vel = vel; }
        private void SetDir(int dir) { this.dir = dir; }
        public double GetThisVel() { 
            this.SetVel(Math.Sqrt(Math.Pow(this.GetVecX(), 2) + Math.Pow(this.GetVecY(), 2)));
            return GetVel();
        }

        public int GetThisDir() {
            this.SetDir((int)Math.Asin(Math.Sin(this.GetVecY() / this.GetVecX())));
            return GetDir();
        }

        /*public void UpdatePos()
        {
            switch (dir)
            {
                case 0:
                    SetY(GetY() + vel); break;
                case 90:
                    SetX(GetX() + vel); break;
                case 180:
                    SetY(GetY() - vel); break;
                case 270:
                    SetX(GetX() - vel); break;
                default:
                    SetX(GetX() + (vel / Math.Sqrt(1 + (Math.Tan(dir * Math.PI / 180) * Math.Tan(dir * Math.PI / 180)))));
                    SetY(GetY() + ((vel * Math.Tan(dir * Math.PI / 180)) / (Math.Sqrt(1 + (Math.Tan(dir * Math.PI / 180) * Math.Tan(dir * Math.PI / 180))))));
                    break;
            }

            /*if (dir == 361) //dodać warunek na zderzenia
            {
                if (dir == 0) //jeżeli zderzenie jest na jednej płaszczyźnie
                {
                    SetY(GetY() + vel);
                } 
                else
                {
                    int collDir = 180; //Math.Atan((y1 - y2) / (x1 - x2))
                    double m2 = 1; //masa drugiego
                    int newDir = (int)Math.Round(Math.Atan(m2 * Math.Sin(collDir) / (mass + m2) * Math.Sin(collDir)));
                    SetDir(newDir);
                }
            }
        }*/

        public Bila GenerateBall(int maxX, int minX, int maxY, int minY)
        {
            Random _random = new Random();
            return new Bila(_random.Next(minX, maxX), _random.Next(minY, maxY), 0.25, 20, _random.Next(-5, 5), _random.Next(-5, 5));
            //return (Bila)new Bila().Copy(_random.Next(minX, maxX), _random.Next(minY, maxY), 0, 0, 5, 0);  // TUTAJ ZMIANA PREDKOSCI
        }

        /*public void ChangeVectors(double m2, double v2, int dir2, int angle) // odpowiednio modyfikować wektory po zderzeniu
        {

            double m1 = this.GetMass();
            double v1 = this.GetThisVel();
            int dir1 = this.GetThisDir();


            this.SetVecX((((((v1 * Math.Cos((dir1 - angle) * Math.PI / 180) * (m1 - m2)) + (2 * m2 * v2 * Math.Cos((dir2 - angle) * Math.PI / 180))) / (m1 + m2)) * ((Math.Cos(angle * Math.PI / 180)) + (v1 * Math.Sin((dir1 - angle) * Math.PI / 180) * Math.Cos((angle + 90) * Math.PI / 180))))));
            this.SetVecY((((((v1 * Math.Cos((dir1 - angle) * Math.PI / 180) * (m1 - m2)) + (2 * m2 * v2 * Math.Cos((dir2 - angle) * Math.PI / 180))) / (m1 + m2)) * ((Math.Sin(angle * Math.PI / 180)) + (v1 * Math.Sin((dir1 - angle) * Math.PI / 180) * Math.Sin((angle + 90) * Math.PI / 180))))));
            
            //this.SetVecX(-1 * this.GetVecX());
            //this.SetVecY(-1 * this.GetVecY());


        }*/

        public void ChangeVectors(double m1, double vx1, double vy1, double m2, double vx2, double vy2) // odpowiednio modyfikować wektory po zderzeniu
        {

            lock (SyncObject)
            {
                this.SetVecX(((m1 - m2) * vx1 + (2 * m2 * vx2)) / (m1 + m2));
                this.SetVecY(((m1 - m2) * vy1 + (2 * m2 * vy2)) / (m1 + m2));
            }
            /*
                this.SetVecX(-1 * this.GetVecX());
                this.SetVecY(-1 * this.GetVecY());
                
            */
        }

        public void KillThread()
        {
            thread.Interrupt();
        }

        public void Move(int maxX, int minX, int maxY, int minY)
        {
            try
            {
                while (true)
                {
                    if (this.GetX() <= minX)
                    {
                        this.SetX(minX);
                        this.SetVecX(-1 * this.GetVecX());
                    }
                    if (this.GetX() >= maxX)
                    {
                        this.SetX(maxX);
                        this.SetVecX(-1 * this.GetVecX());
                    }
                    if (this.GetY() <= minY)
                    {
                        this.SetY(minY);
                        this.SetVecY(-1 * this.GetVecY());
                    }
                    if (this.GetY() >= maxY)
                    {
                        this.SetY(maxY);
                        this.SetVecY(-1 * this.GetVecY());
                    }
                    SetX(this.GetX() + this.GetVecX());
                    SetY(this.GetY() + this.GetVecY());
                    

                    Thread.Sleep(30);
                    
                }
            }
            catch (ThreadAbortException)
            {
                
            }
        }

        public void MoveTest(int maxX, int minX, int maxY, int minY)
        {
            if (this.GetX() <= minX)
            {
                this.SetX(minX);
                this.SetVecX(-1 * this.GetVecX());
            }
            if (this.GetX() >= maxX)
            {
                this.SetX(maxX);
                this.SetVecX(-1 * this.GetVecX());
            }
            if (this.GetY() <= minY)
            {
                this.SetY(minY);
                this.SetVecY(-1 * this.GetVecY());
            }
            if (this.GetY() >= maxY)
            {
                this.SetY(maxY);
                this.SetVecY(-1 * this.GetVecY());
            }
            SetX(this.GetX() + this.GetVecX());
            SetY(this.GetY() + this.GetVecY());
        }
    }
}