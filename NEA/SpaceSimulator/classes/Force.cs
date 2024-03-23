namespace SpaceSimulator.classes
{
    public class Force
    {
        public double[] components;

        public Force()
        {
            components = new double[2];
        }

        public Force(double x, double y)
        {
            components = new double[2];
            components[0] = x;
            components[1] = y;
        }

        public override string ToString()
        {
            return $"{components[0]}, {components[1]}";
        }
    }
}
