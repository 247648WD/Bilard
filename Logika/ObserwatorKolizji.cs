using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logika
{
        public class ObserwatorKolizji
    {
        protected Thread thread;
        protected List<Bila> bilas;
        public ObserwatorKolizji() {
            this.bilas = new List<Bila>();
            thread = new Thread(CheckBilas);
            thread.Start();
        }

        public void AddBilas(Bila bila) {
            bilas.Add(bila);
        }

        public void ClearBilas()
        {
            bilas.Clear();
        }

        public void CheckBilas()
        {
            for (int i = 0; i < bilas.Count - 1; i++)
            {
                for(int j = i + 1; j < bilas.Count; j++) {
                    //if (Math.Pow(bilas[i].GetSize() / 2 + bilas[j].GetSize() / 2, 2) >= Math.Pow(bilas[i].GetX() - bilas[j].GetX(), 2) + Math.Pow(bilas[i].GetY() - bilas[j].GetY(), 2)) {
                    if (i == j + 1) { 
                        bilas[i].ChangeVectors();
                        bilas[j].ChangeVectors();
                    }
                }   
            }
            Thread.Sleep(30);
        }
    }
}
