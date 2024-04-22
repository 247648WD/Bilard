using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dane;

namespace Logika
{
    internal abstract class Bila : BilaPrototyp
    {
        public double GetX() { return posX; }
        public double GetY() { return posY; }
        public double GetMass() { return mass; }
        public int GetSize() { return size; }
        public int GetVel() { return vel; }
        public int GetDir() { return dir; }
        
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
        }
    }
}
