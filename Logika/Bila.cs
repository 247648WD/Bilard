using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Dane;

namespace Logika
{
    public class Bila : BilaPrototyp
    {
        private Thread thread;
        public double GetX() { return posX; }
        public double GetY() { return posY; }
        public double GetMass() { return mass; }
        public int GetSize() { return size; }
        public int GetVel() { return vel; }
        public int GetDir() { return dir; }

        public Bila() { }

        public Bila(double posX, double posY, double mass, int size, int vel, int dir)
        {
            this.posX = posX;
            this.posY = posY;
            this.mass = mass;
            this.size = size;
            this.vel = vel;
            this.dir = dir;
        }
        
        private void SetX(double x) { this.posX = x; }
        private void SetY(double y) { this.posY = y; }
        private void SetMass(double mass) { this.mass = mass; }
        private void SetSize(int size) { this.size = size; }
        private void SetVel(int vel) { this.vel = vel; }
        private void SetDir(int dir) { this.dir = dir; }
        
        public void UpdatePos()
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
                    SetX(GetX() + (vel / Math.Sqrt(1 + Math.Tan(dir) * Math.Tan(dir))));
                    SetY(GetY() + (vel * Math.Tan(dir) / Math.Sqrt(1 + Math.Tan(dir) * Math.Tan(dir))));
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
            }*/
        }

        public Bila GenerateBall(int maxX, int minX, int maxY, int minY)
        {
            Random _random = new Random();
            return (Bila)new Bila().Copy(_random.Next(minX, maxX), _random.Next(minY, maxY), 0, 0, 5, 0);  // TUTAJ ZMIANA PREDKOSCI
        }

        public Bila MoveBall(Bila ball, int maxX, int minX, int maxY, int minY)
        {
            
            ball.SetX(ball.GetX() + ball.GetVel());
            if (ball.GetX() <= minX || ball.GetX() >= maxX)
            {
                ball.SetVel(ball.GetVel() * (-1));
            }
            return ball;
        }

        public void Move(int maxX, int minX, int maxY, int minY)
        {
            try
            {
                while (true)
                {
                    this.SetX(this.GetX() + this.GetVel());
                    if (this.GetX() <= minX || this.GetX() >= maxX)
                    {
                        this.SetVel(this.GetVel() * (-1));
                    }
                    // Tutaj możesz dodać więcej logiki, na przykład obsługę kolizji
                    Thread.Sleep(30); // Poczekaj 100 milisekund przed kolejnym ruchem
                }
            }
            catch (ThreadAbortException)
            {
                // Wątek został zatrzymany
            }
        }

        public void StartThread(Bila ball, int maxX, int minX, int maxY, int minY)
        {
            thread = new Thread(() => Move(maxX, minX, maxY, minY));
            thread.Start();
        }
    }
}
