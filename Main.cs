using System;
using System.Windows.Forms;
using MyPhotoshop.Filters;

namespace MyPhotoshop
{
	class MainClass
	{
        [STAThread]
		public static void Main (string[] args)
		{
			var window=new MainWindow();
			window.AddFilter (new PixelFilter<LighteningParameters>(
				"Осветление/затемнение",
				(pixel, parameters) => pixel * parameters.Coefficient
				));

            window.AddFilter(new PixelFilter<GrayscaleParameters>(
                "Оттенки серого",
                (pixel, parameters) =>
				{
                    var lightness = pixel.R + pixel.G + pixel.B;
                    lightness /= 3;
                    return new Pixel(lightness, lightness, lightness);
                }
				));
            Application.Run (window);
		}
	}
}
