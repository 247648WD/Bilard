using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dane
{
    internal class BilaPrototyp
    {
        private double posX;
        private double posY;
        private double mass;
        private int size;
        private int vel;
        private int dir;

        public BilaPrototyp Copy(double posX, double posY, double mass, int size, int vel, int dir)
        {
            this.posX = posX;
            this.posY = posY;
            this.vel = vel;
            this.dir = dir;
            this.mass = mass;
            this.size = size;
            return this;
        }
    }
}
