using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dane
{
    public class StolPrototyp
    {
        public int _width;
        public int _height;

        public StolPrototyp Copy(int width, int height)
        {
            this._width = width;
            this._height = height;
            return this;
        }
    }
}
