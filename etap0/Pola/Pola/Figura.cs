namespace Pola
{
    public class Figura
    {
        public double prostokat(double a, double b)
        {
            return a * b;
        }

        public double kwadrat(double d1)
        {
            return d1 * d1 * 0.5f;
        }

        public double kolo(double r)
        {
            return r * r * Math.PI;
        }

        public double trojkat(double a, double b, double c)
        {
            double s = 0.5 * (a + b + c);

            return Math.Sqrt(s * (s - a) * (s - b) * (s - c));
        }
    }
}
