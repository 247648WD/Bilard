using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dane;

namespace Logika
{
    internal abstract class Stol : StolPrototyp
    {
        public int GetWidth() { return _width; }
        public int GetHeight() { return _height; }

        public void SetWidth(int width) { this._width = width; }
        public void SetHeight(int height) {  this._height = height; }
    }
}
