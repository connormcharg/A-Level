namespace SpaceSimulator.classes
{
    public class Force
    {
        public double Magnitude { get; set; } // N
        public double Direction { get; set; } // radians

        public Force()
        {
            Magnitude = 0.0;
            Direction = 0.0;
        }
        
        public Force(double magnitude, double direction)
        {
            Magnitude = magnitude;
            Direction = direction;
        }

        public override string ToString()
        {
            return $"{Magnitude}, {Direction}";
        }
    }
}
