using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logika
{
    public class ObserwatorKolizji
    {
        private static readonly object SyncObject = new object();
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

        public int GetAngle(int i, int j)
        {
            double y = Math.Abs(bilas[i].GetY() - bilas[j].GetY());
            double x = Math.Abs(bilas[i].GetX() - bilas[j].GetX());
            return (int)(Math.Asin(Math.Sin(y / x)) * 180 / Math.PI);
        }
        
        public void CheckBilas()
        {
            try
            {
                while (true)
                {
                    lock (SyncObject)
                    {
                        for (int i = 0; i < bilas.Count - 1; i++)
                        {
                            for (int j = i + 1; j < bilas.Count; j++)
                            {
                                double dx = bilas[i].GetX() - bilas[j].GetX();
                                double dy = bilas[i].GetY() - bilas[j].GetY();
                                double distance = Math.Sqrt((dx * dx) + (dy * dy));

                                if (distance <= (bilas[i].GetSize() / 2 + bilas[j].GetSize() / 2))
                                {
                                    double m1 = bilas[i].GetMass();
                                    double vx1 = bilas[i].GetVecX();
                                    double vy1 = bilas[i].GetVecY();
                                    double m2 = bilas[j].GetMass();
                                    double vx2 = bilas[j].GetVecX();
                                    double vy2 = bilas[j].GetVecY();
                                    bilas[i].ChangeVectors(m1, vx1, vy1, m2, vx2, vy2);
                                    bilas[j].ChangeVectors(m2, vx2, vy2, m1, vx1, vy1);
                                }
                            }
                        }
                    }
                    Thread.Sleep(30);
                }
            }
            catch (ThreadAbortException)
            {
                // Wątek został zatrzymany
            }
        }
    }
}
