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
        //protected int vel;
        //protected int dir;
        protected double vecX;
        protected double vecY;

        public BilaPrototyp Copy(int posX, int posY, double mass, int size, double vecX, double vecY)
        {
            this.posX = posX;
            this.posY = posY;
            this.vecX = vecX;
            this.vecY = vecY;
            this.mass = mass;
            this.size = size;
            return this;
        }
    }
}
