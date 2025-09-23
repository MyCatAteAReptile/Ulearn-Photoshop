using System;
using MyPhotoshop.Filters;

namespace MyPhotoshop
{
	public class GrayscaleFilter : PixelFilter
	{
		public override string ToString ()
		{
			return "Оттенки серого";
		}

		public GrayscaleFilter() : base(new GrayscaleParameters()) { }

		public override Pixel ProcessPixel(Pixel pixel, IParameters parameters)
		{
            var lightness = pixel.R + pixel.G + pixel.B;
            lightness /= 3;
			return new Pixel(lightness, lightness, lightness);
        }
	}
}

