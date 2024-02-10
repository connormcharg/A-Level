using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceSimulator.classes
{
    public class Point
    {
        public double[] Position { get; set; }
        public double TimeToLive { get; set; }

        public Point()
        {
            Position = new double[2];
            TimeToLive = 0;
        }

        public Point(double x, double y, double timeToLive)
        {
            Position = new double[2];
            Position[0] = x;
            Position[1] = y;
            TimeToLive = timeToLive;
        }
    }
}
