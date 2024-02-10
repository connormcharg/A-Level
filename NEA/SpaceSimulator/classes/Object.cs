using System.Collections.Generic;
using System.Drawing;

namespace SpaceSimulator.classes
{
    public class Object
    {
        public double Mass { get; set; }
        public double[] Velocity { get; set; } // x, y
        public double[] Acceleration { get; set; } // x, y
        public double[] Position { get; set; } // x, y
        public List<Force> Forces { get; set; }
        public Brush Color { get; set; }
        public double[] Size { get; set; }

        public Object()
        {
            Velocity = new double[2];
            Acceleration = new double[2];
            Position = new double[2];
            Forces = new List<Force>();
            Color = Brushes.Blue;
            Size = new double[2];
            Size[0] = 25; Size[1] = 25;
        }
    }
}
