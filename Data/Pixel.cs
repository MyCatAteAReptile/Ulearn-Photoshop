using System;
using System.Runtime.InteropServices;

namespace MyPhotoshop
{
    public class Pixel
    {
        double _r;
        public double R { 
            get {  return _r; } 
            set
            {
                _r = CheckChannelValue(value);
            } 
        }
        double _g;
        public double G
        {
            get { return _g; }
            set
            {
                _g = CheckChannelValue(value);
            }
        }
        double _b;
        public double B
        {
            get { return _b; }
            set
            {
                _b = CheckChannelValue(value);
            }
        }

        public Pixel(double R = 0, double G = 0, double B = 0)
        {
            this.R = R;
            this.G = G;
            this.B = B;
        }

        public static Pixel operator* (Pixel p, double d)
        {
            return new Pixel(p.R * d, p.G * d, p.B * d);
        }

        public static double Trim(double value)
        {
            if (value < 0) return 0;
            if (value > 1) return 1;
            return value;
        }

        double CheckChannelValue(double value) {
            if (value < 0 || value > 1)
                throw new ArgumentException("Channel value out of range", nameof(value));
            return value;
        }
    }
}

