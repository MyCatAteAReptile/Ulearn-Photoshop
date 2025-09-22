using System;

namespace MyPhotoshop
{
	public class GrayscaleFilter : PixelFilter
	{
		public override ParameterInfo[] GetParameters()
		{
			return new ParameterInfo[0];
		}
		
		public override string ToString ()
		{
			return "Оттенки серого";
		}

		public override Pixel ProcessPixel(Pixel pixel, double[] parameters)
		{
            var lightness = pixel.R + pixel.G + pixel.B;
            lightness /= 3;
			return new Pixel(lightness, lightness, lightness);
        }
	}
}

