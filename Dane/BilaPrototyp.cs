using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dane
{
    public abstract class BilaPrototyp
    {
        protected double posX;
        protected double posY;
        protected double mass;
        protected int size;
        protected int vel;
        protected int dir;

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
