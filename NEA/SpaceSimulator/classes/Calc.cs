using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SpaceSimulator.classes
{
    public class Calc
    {
        public static int _precision = 5;
        public static double _gConstant = 6.67 * Math.Pow(10, -11);
        public static double _dConstant = Math.Pow(10, 5); // 10^5 m per pixel

        public static double[] Resolve(double magnitude, double direction)
        {
            double[] result = new double[2];
            result[0] = Math.Round(Math.Cos(direction) * magnitude, _precision);
            result[1] = Math.Round(Math.Sin(direction) * magnitude, _precision);
            return result;
        }

        public static Force Resultant(Object a)
        {
            double xComponent = 0;
            double yComponent = 0;

            foreach (Force f in a.Forces)
            {
                xComponent += f.components[0];
                yComponent += f.components[1];
            }

            return new Force(xComponent, yComponent);
        }

        private static double[] ForceToComponent(Force f)
        {
            double[] components = new double[2];
            components[0] = f.components[0];
            components[1] = f.components[1];
            return components;
        }

        public static double[] GetAcceleration(Object a)
        {
            double[] components = ForceToComponent(Resultant(a));

            //f = ma --> a = f/m
            components[0] = Math.Round(components[0] / a.Mass, _precision);
            components[1] = Math.Round(components[1] / a.Mass, _precision);

            return components;
        }

        /// <summary>
        /// Calculates the force on a given object a, by a second object b.
        /// </summary>
        /// <param name="a">From</param>
        /// <param name="b">To</param>
        /// <returns>Force object with magnitude and direction from a to b.</returns>
        public static Force Gravitational(Object a, Object b)
        {
            // F = Gm1m2 / r^2
            double magnitude;
            double direction;

            // find magnitude from newton's law of gravitation
            double r = Calc.Displacement(a, b);
            double f = (_gConstant*a.Mass*b.Mass)/(Math.Pow(r, 2));
            magnitude = Math.Round(f, _precision);

            // find direction in radians from a to b
            double d = Calc.Direction(a, b);
            direction = d;

            double[] components = Resolve(magnitude, direction);

            Force R = new Force(components[0], components[1]);

            return R;
        }

        public static double DirectionHelper(double x1, double x2, double y1, double y2)
        {
            double dx = x2 - x1;
            double dy = y2 - y1;
            double r = 0;

            if (x1 == x2 && y1 == y2)
            {
                r = 0;
            }
            else if (x1 == x2 && y1 < y2)
            {
                r = 0.5 * Math.PI;
            }
            else if (x1 == x2 && y1 > y2)
            {
                r = -0.5 * Math.PI;
            }
            else if (y1 == y2 && x1 < x2)
            {
                r = 0;
            }
            else if (y1 == y2 && x1 > x2)
            {
                r = Math.PI;
            }
            else if (x1 < x2 && y1 < y2) // NE
            {
                r = Math.Atan(dy / dx);
            }
            else if (x1 < x2 && y1 > y2) // SE
            {
                r = Math.Atan(dy / dx);
            }
            else if (x1 > x2 && y1 > y2) // SW
            {
                r = -(Math.PI - Math.Atan(dy / dx));
            }
            else if (x1 > x2 && y1 < y2) // NW
            {
                r = Math.PI + Math.Atan(dy / dx);
            }

            return Math.Round(r, _precision);
        }

        /// <summary>
        /// Calculates the direction in radians from a to b (-pi to pi)
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static double Direction(Object a, Object b)
        {
            double x1 = a.Position[0];
            double y1 = a.Position[1];
            double x2 = b.Position[0];
            double y2 = b.Position[1];

            return DirectionHelper(x1, x2, y1, y2);
        }

        public static double Displacement(Object a, Object b)
        {
            return Math.Round(Math.Sqrt(Math.Pow(a.Position[0] - b.Position[0], 2) + Math.Pow(a.Position[1] - b.Position[1], 2)), _precision);
            // return round((a**2 + b**2)**0.5)
        }
    }
}
