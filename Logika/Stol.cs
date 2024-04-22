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
        public int GetWidth() { return width; }
        public int GetHeight() { return height; }

        public void SetWidth(int width) { this.width = width; }
        public void SetHeight(int height) {  this.height = height; }
    }
}
