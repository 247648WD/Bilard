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

        public List<Bila> GenerateBalls(int count, int maxX, int minX, int maxY, int minY)
        {
            Random _random = new Random();
            var balls = new List<Bila>();
            for (int i = 0; i < count; i++)
            {
                int x = _random.Next(minX, maxX);
                int y = _random.Next(minY, maxY);
                balls.Add(new Bila());
                balls[i].Copy(x, y, 0, 0, 0, 0);
            }
            return balls;
        }

        public List<Bila> MoveBalls(List<Bila> balls, int maxX, int minX, int maxY, int minY)
        {
            for (int i = 0; i < balls.Count; i++)
            {
                /*Przykładowy kod ruchu kul (dla uproszczenia)
                ball.X += _random.Next(-4, 5); // Losowy ruch poziomy
                ball.Y += _random.Next(-4, 5); // Losowy ruch pionowy

                // Odbijanie się od ścian
                if (ball.X < minX || ball.X > maxX)
                    ball.X = Math.Clamp(ball.X, 0, maxX);
                if (ball.Y < minY || ball.Y > maxY)
                    ball.Y = Math.Clamp(ball.Y, 0, maxY);*/

                balls[i].SetX(balls[i].GetX() + balls[i].GetVel());
                if (balls[i].GetX() <= minX || balls[i].GetX() >= maxX)
                {
                    balls[i].SetVel(balls[i].GetVel() * (-1));
                }
                if (balls[i].GetY() <= minY || balls[i].GetY() >= maxY)
                {
                    balls[i].SetVel(balls[i].GetVel() * (-1));
                }
            }
            return balls;
        }
    }
}
