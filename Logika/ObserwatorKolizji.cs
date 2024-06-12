using Microsoft.Extensions.Logging.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dane;
using System.Text.Json;

namespace Logika
{
    public class ObserwatorKolizji
    {
        private Timer timer;

        private Logger logger;

        private static readonly object SyncObject = new object();
        protected Thread thread;
        protected List<Bila> bilas;
        public ObserwatorKolizji() {
            this.bilas = new List<Bila>();
            thread = new Thread(CheckBilas);
            thread.Start();
            this.logger = new Logger();
            this.timer = new Timer(Logging, null, 1000, 2500);
        }

        public void Logging(object? state)
        {
            logger.Log(DateTime.Now.ToString(), AggregateBilaInfo().ToString());
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

        public string GetBilaInfo(int i)
        {
            string info;
            info = JsonSerializer.Serialize(bilas[i]) + ",";
            return info;
        }

        public StringBuilder AggregateBilaInfo()
        {
            StringBuilder aggregate = new StringBuilder();
            for (int i = 0; i < bilas.Count(); i++)
            {
                aggregate.Append(GetBilaInfo(i));
            }
           
            return aggregate;
        }
        
        public void CheckBilas()
        {
            try
            {
                while (true)
                {
                    
                    for (int i = 0; i < bilas.Count - 1; i++)
                    {
                        for (int j = i + 1; j < bilas.Count; j++)
                        {
                            lock (SyncObject)
                            {
                                double dx = bilas[i].GetX() - bilas[j].GetX();
                                double dy = bilas[i].GetY() - bilas[j].GetY();
                                double distance = Math.Sqrt((dx * dx) + (dy * dy));

                                if (distance <= (bilas[i].GetSize() / 2 + bilas[j].GetSize() / 2))
                                {
                                    double overlap = 0.5 * (distance - bilas[i].GetSize() / 2 - bilas[j].GetSize() / 2);

                                    bilas[i].SetX(bilas[i].GetX() - overlap * (bilas[i].GetX() - bilas[j].GetX()) / distance);
                                    bilas[i].SetY(bilas[i].GetY() - overlap * (bilas[i].GetY() - bilas[j].GetY()) / distance);

                                    bilas[j].SetX(bilas[j].GetX() + overlap * (bilas[i].GetX() - bilas[j].GetX()) / distance);
                                    bilas[j].SetY(bilas[j].GetY() + overlap * (bilas[i].GetY() - bilas[j].GetY()) / distance);

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
                    Thread.Sleep(4);
                }
            }
            catch (ThreadAbortException)
            {
                // Wątek został zatrzymany
            }
        }
    }
}
