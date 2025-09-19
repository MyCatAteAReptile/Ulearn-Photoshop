using System;

namespace MyPhotoshop
{
    public class Pixel
    {
        public double R { get; set; }
        public double G { get; set; }
        public double B { get; set; }

        public Pixel(double R = 0, double G = 0, double B = 0)
        {
            this.R = R;
            this.G = G;
            this.B = B;
        }

        public static Pixel operator *(Pixel p, double d)
        {
            return new Pixel(p.R * d, p.G * d, p.B * d);
        }

    }
}

