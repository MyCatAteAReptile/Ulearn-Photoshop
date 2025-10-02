﻿using System;
using System.Drawing;
using System.Windows.Forms;

namespace MyPhotoshop
{
    class MainClass
    {
        [STAThread]
        public static void Main(string[] args)
        {
            var window = new MainWindow();
            window.AddFilter(new PixelFilter<LighteningParameters>(
                "Осветление/затемнение",
                (pixel, parameters) => pixel * parameters.Coefficient
                ));

            window.AddFilter(new PixelFilter<EmptyParameters>(
                "Оттенки серого",
                (pixel, parameters) =>
                {
                    var lightness = pixel.R + pixel.G + pixel.B;
                    lightness /= 3;
                    return new Pixel(lightness, lightness, lightness);
                }
                ));

            window.AddFilter(new TransformFilter(
                "Отражение", 
                size => size,
                (point, size) => new Point(size.Width - 1 - point.X, point.Y)
                ));

            window.AddFilter(new TransformFilter(
                "Поворот против ч.с.",
                size => new Size(size.Height, size.Width),
                (point, size) => new Point(size.Width - point.Y - 1, point.X)
                ));

            window.AddFilter(new TransformFilter<RotationParameters>(
                "Свободное вращение", new RotateTransformer()));

            Application.Run(window);
        }
    }
}
