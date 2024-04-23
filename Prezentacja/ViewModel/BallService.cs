using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prezentacja.ViewModel
{
    public class BallService
    {
        private readonly Random _random = new Random();
        private List<int> vels = new List<int>();
        public List<Ball> GenerateBalls(int count, int maxX, int minX, int maxY, int minY)
        {
            var balls = new List<Ball>();
            for (int i = 0; i < count; i++)
            {
                int x = _random.Next(minX, maxX);
                int y = _random.Next(minY, maxY);
                balls.Add(new Ball(x, y));
            }
            return balls;
        }

        public void MoveBalls(List<Ball> balls, int maxX, int minX, int maxY, int minY)
        {
            for (int i = 0; i < balls.Count; i++)
            {
                vels.Add(5);
            }

            for (int i = 0; i < balls.Count; i++)
            {
                /*Przykładowy kod ruchu kul (dla uproszczenia)
                ball.X += _random.Next(-4, 5); // Losowy ruch poziomy
                ball.Y += _random.Next(-4, 5); // Losowy ruch pionowy

                // Odbijanie się od ścian
                if (ball.X < minX || ball.X > maxX)
                    ball.X = Math.Clamp(ball.X, 0, maxX);
                if (ball.Y < minY || ball.Y > maxY)
                    ball.Y = Math.Clamp(ball.Y, 0, maxY);*/
                
                balls[i].X += vels[i];
                if (balls[i].X <= minX || balls[i].X >= maxX)
                {
                    vels[i] *= -1;
                }
            }
        }
    }

}
