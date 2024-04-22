using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dane
{
    public abstract class StolPrototyp
    {
        protected int width;
        protected int height;
        public StolPrototyp Copy(int width, int height)
        {
            this.width = width;
            this.height = height;
            return this;
        }
    }
}
