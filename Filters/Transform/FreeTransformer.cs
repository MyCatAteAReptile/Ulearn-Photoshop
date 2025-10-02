using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace MyPhotoshop
{
    internal class FreeTransformer : ITransformer<EmptyParameters>
    {
        public Size ResultSize { get; private set; }
        public Size OriginalSize { get; private set; }
        Func<Size, Size> _sizeTransformer;
        Func<Point, Size, Point> _pointTransformer;

        public FreeTransformer(Func<Size, Size> sizeTransformer, Func<Point, Size, Point> pointTransformer)
        {
            _sizeTransformer = sizeTransformer;
            _pointTransformer = pointTransformer;
        }

        public Point? MapPoint(Point newPoint)
        {
            return _pointTransformer(newPoint, OriginalSize);
        }

        public void Prepare(Size size, EmptyParameters parameters)
        {
            OriginalSize = size;
            ResultSize = _sizeTransformer(size);
        }
    }
}
